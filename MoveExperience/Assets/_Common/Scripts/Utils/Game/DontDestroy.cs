///-----------------------------------------------------------------
/// Author : Valérian Segado
/// Date : 05/02/2020 14:45
///-----------------------------------------------------------------

using UnityEngine;

namespace Com.IsartDigital.Common {
	public class DontDestroy : MonoBehaviour {
		private void Awake () {
			DontDestroyOnLoad(gameObject);
		}
	}
}