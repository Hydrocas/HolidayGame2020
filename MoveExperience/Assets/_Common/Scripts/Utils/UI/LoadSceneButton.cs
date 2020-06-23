///-----------------------------------------------------------------
/// Author : Hugo TEYSSIER
/// Date : 21/04/2020 16:45
///-----------------------------------------------------------------

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Com.IsartDigital.Four.Common.UI {
	[RequireComponent(typeof(Button))]
	public class LoadSceneButton : MonoBehaviour {

		[SerializeField] private int sceneIndex = 0;

		private void Awake()
		{
			GetComponent<Button>().onClick.AddListener(Button_OnClick);
		}

		private void Button_OnClick()
		{
			SceneManager.LoadSceneAsync(sceneIndex);
		}
	}
}