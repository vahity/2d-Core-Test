using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MH2B.Rewarding
{

	public enum RewardItemType
	{
		None,
		Currency,
		Item
	}

	[Serializable]
	public class RewardItemInfo
	{
		public RewardItemType RewardItemType;
		public RewardItemFrame RewardItemFrame;
	}
}


