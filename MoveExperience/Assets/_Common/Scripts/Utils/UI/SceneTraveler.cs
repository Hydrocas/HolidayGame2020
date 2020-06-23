///-----------------------------------------------------------------
/// Author : Hugo TEYSSIER
/// Date : 27/04/2020 17:02
///-----------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;

namespace Com.IsartDigital.Four.Common.UI {
	public class SceneTraveler : MonoBehaviour {

		static private List<SceneTraveler> sceneTravelers = new List<SceneTraveler>();

		private void Awake()
		{
			for (int i = sceneTravelers.Count - 1; i >= 0; i--)
			{
				if (sceneTravelers[i].CompareTag(tag))
				{
					Destroy(gameObject);
					return;
				}
			}

			sceneTravelers.Add(this);
			DontDestroyOnLoad(gameObject);
		}
	}
}