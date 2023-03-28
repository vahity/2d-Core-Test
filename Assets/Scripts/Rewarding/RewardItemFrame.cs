using MH2B.GameModules.ResourceManagment;
using MH2B.Utilities;
using RTLTMPro;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace MH2B.Rewarding
{
	public class RewardItemFrame : MonoBehaviour
	{
		[SerializeField] private RectTransform rectTransform;
		[SerializeField] private CanvasGroup canvasGroup;
		[SerializeField] private Image rewardIcon;
		[SerializeField] private RTLTextMeshPro rewardAmount;
		[SerializeField] private float speed = 20f;

		private TransactionStep transactionStep;

		public void Setup(TransactionStep transaction)
		{
			transactionStep = transaction;
			rewardIcon.sprite = transaction.RewardIcon;
			rewardIcon.SetNativeSize();
			rewardAmount.text = transaction.RewardAmount.ToString();
		}

		public void MoveToTarget(Vector2 targetPos, float timer)
		{
			StartCoroutine(MoveToTargetRoutine(targetPos , timer));
		}

		private IEnumerator MoveToTargetRoutine(Vector2 targetPos, float timer)
		{
			yield return new WaitForSeconds(timer);
			while(Vector2.Distance(rectTransform.anchoredPosition, targetPos) > 1)
			{
				rectTransform.anchoredPosition = Vector2.MoveTowards(rectTransform.anchoredPosition, targetPos, Time.deltaTime * speed);
				yield return null;
			}
			yield return new WaitForSeconds(1f);
			Reward();
		}

		private void Reward()
		{
			canvasGroup.alpha = 0;
			canvasGroup.interactable = false;
			canvasGroup.blocksRaycasts = false;
			ResourcesUtilities.OperationResult(transactionStep.RewardResourceName , transactionStep.RewardOperation , transactionStep.RewardAmount);
			GeneralUtilities.SetTimer(1f, () => RewardingManager.onShowNextReward?.Invoke());
			Destroy(gameObject, 1);
		}
	}
}


