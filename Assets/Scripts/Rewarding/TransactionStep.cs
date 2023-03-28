using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MH2B.Rewarding
{
	public enum RewardOperation
	{
		None,
		AddValue,
		SetValue,
	}

	[Serializable]
	public class TransactionStep
	{
		public string RewardResourceName;
		public RewardItemType RewardItemType;
		public int RewardAmount;
		public Sprite RewardIcon;
		public RewardOperation RewardOperation;
	}
}


