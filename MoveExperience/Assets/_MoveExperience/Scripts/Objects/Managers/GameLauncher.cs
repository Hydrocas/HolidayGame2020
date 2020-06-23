///-----------------------------------------------------------------
/// Author : Hugo TEYSSIER
/// Date : 23/06/2020 16:26
///-----------------------------------------------------------------

using UnityEngine;

namespace Com.HolidayGame.MoveExperience.Objects.Managers {
	public class GameLauncher : MonoBehaviour {

		[SerializeField] private GameManager gameManager;
		[SerializeField] private FeaturesScreen featuresScreen;

		private static bool isStarted;

		private void Awake()
		{
			if (isStarted) Destroy(gameObject);
			else
			{
				isStarted = true;
				Init();
			}
		}

		private void Init()
		{
			gameManager = Instantiate(gameManager);
			featuresScreen = Instantiate(featuresScreen);

			//gameManager.Init();
		}
	}
}