///-----------------------------------------------------------------
/// Author : Hugo TEYSSIER
/// Date : 23/06/2020 16:26
///-----------------------------------------------------------------

using Com.HolidayGame.MoveExperience.Objects.Screens;
using UnityEngine;

namespace Com.HolidayGame.MoveExperience.Objects.Managers {
	public class GameLauncher : MonoBehaviour {

		[SerializeField] private GameManager gameManager = null;
		[SerializeField] private GameObject rootCanvas = null;

		private static bool isStarted;

		private void Awake()
		{
			if (!isStarted) 
			{
				isStarted = true;
				Init();
			}

			Destroy(gameObject);
		}

		private void Init()
		{
			gameManager = Instantiate(gameManager);
			DontDestroyOnLoad(Instantiate(rootCanvas));

			gameManager.Init();
		}
	}
}