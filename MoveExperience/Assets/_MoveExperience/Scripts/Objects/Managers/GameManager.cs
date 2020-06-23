///-----------------------------------------------------------------
/// Author : Valérian Segado
/// Date : 23/06/2020 15:44
///-----------------------------------------------------------------

using Com.HolidayGame.MoveExperience.Objects.Controller;
using Com.HolidayGame.MoveExperience.Objects.PlayerObjects;
using Com.HolidayGame.MoveExperience.Objects.Screens;
using UnityEngine;

namespace Com.HolidayGame.MoveExperience.Objects.Managers {
	public class GameManager : MonoBehaviour {

		[SerializeField] private ControllerSettings controller = null;
		[SerializeField] private Player playerPrefab = null;

		public void Init()
		{
			//InitFeatureManager
			//Instantiate(playerPrefab);
			FeaturesScreen.Instance.Init();

			DontDestroyOnLoad(gameObject);
		}
		
		private void Update () 
		{
			if(controller.Start) ControllerOnStart();
		}

		private void ControllerOnStart()
		{
			//Roue cranté 
		}
	}
}