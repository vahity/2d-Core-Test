using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace MH2B.Utilities
{
	public static class GeneralUtilities
	{
		public static async Task SetTimer(float timer, System.Action onComplete)
		{
			await Task.Delay((int)(timer * 1000));
			onComplete?.Invoke();

		}
		
	}


}


