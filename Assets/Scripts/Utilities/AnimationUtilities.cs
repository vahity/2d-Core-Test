using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace MH2B.Utilities
{
	public static class AnimationUtilities
	{
		public static async Task SetTriggerDelayed(this Animator anim, string triggerName, float delay)
		{
			await GeneralUtilities.SetTimer(delay , () => anim.SetTrigger(triggerName));
		}
	}
}


