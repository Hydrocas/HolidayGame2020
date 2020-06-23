///-----------------------------------------------------------------
/// Author : Valérian Segado
/// Date : 23/06/2020 15:44
///-----------------------------------------------------------------

using Com.HolidayGame.MoveExperience.Objects.Controller;
using UnityEngine;

namespace Com.HolidayGame.MoveExperience.Objects.Managers {
	public class GameManager : MonoBehaviour {

		[SerializeField] private ControllerSettings controller; 
		public void Init()
		{
			//Appeler le Init dans le GameLauncher 
			//InitFeatureManager
			//Instancier Player 
		}
		private void Start () {
			Init(); 
		}
		
		private void Update () {
			if(controller.Cancel) ControllerOnCancel(); 
		}

		private void ControllerOnCancel()
		{
			//Roue cranté 
		}
	}
}