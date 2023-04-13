using MH2B.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEditor.Progress;

namespace MH2B.Rewarding
{
	public class RewardingManager : PersistentSingleton<RewardingManager>
	{
		[SerializeField] private GameObject rewardPackage;
		[SerializeField] private Animator rewardAnimator;
		[SerializeField] private Transform rewardItemsParent;
		[SerializeField] private RectTransform rewardMoveTargetPos;
		[SerializeField] private List<RewardItemInfo> rewardInfos = new List<RewardItemInfo>();
		private Queue<TransactionStep> rewardTransactions = new Queue<TransactionStep>();
		private Queue<List<TransactionStep>> nextRewardTransactions = new Queue<List<TransactionStep>>();
		private bool isInRewardingProcces = false;

		public static System.Action onShowNextReward;
		public static System.Action onFinishedReward;

		protected override void Awake()
		{
			base.Awake();
			onShowNextReward += ShowNextReward;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			onShowNextReward -= ShowNextReward;
		}

		public List<TransactionStep> testSteps;

		[ContextMenu("test")]
		private void test()
		{
			Reward(testSteps);
		}

		public async void Reward(List<TransactionStep> transactions)
		{
			if(isInRewardingProcces)
			{
				nextRewardTransactions.Enqueue(transactions);
				return;
			}

			isInRewardingProcces = true;
			rewardPackage.SetActive(true);
			await rewardAnimator.SetTriggerDelayed("Open", 1f);
			await Task.Delay(1000);
			
			foreach (var item in transactions)
			{
				rewardTransactions.Enqueue(item);
			}

			ShowNextReward();
		}

		private void ShowNextReward()
		{
			if(rewardTransactions.Count == 0)
			{
				FinishedRewarding();
				return;
				
			}
			TransactionStep step = rewardTransactions.Dequeue();
			RewardItemInfo foundInfo = rewardInfos.Find(x => x.RewardItemType.Equals(step.RewardItemType));
			if(foundInfo != null)
			{
				RewardItemFrame newRewardItem = Instantiate(foundInfo.RewardItemFrame, rewardItemsParent);
				newRewardItem.Setup(step);
				newRewardItem.MoveToTarget(rewardMoveTargetPos.position, 1);
			}
			else
			{
				ShowNextReward();
			}
		}

		private async Task FinishedRewarding()
		{
			await rewardAnimator.SetTriggerDelayed("Close", 1f);
			await Task.Delay(1000);
			rewardPackage.SetActive(false);
			isInRewardingProcces = false;

			if(nextRewardTransactions.Count == 0)
			{
				onFinishedReward?.Invoke();
				return;
			}

			Reward(nextRewardTransactions.Dequeue());
		}

	}
}

