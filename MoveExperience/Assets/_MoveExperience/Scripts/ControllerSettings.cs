///-----------------------------------------------------------------
/// Author : Clément VIEILLY
/// Date : 23/06/2020 12:22
///-----------------------------------------------------------------

using Com.HolidayGame.MoveExperience.Managers;
using UnityEngine;

namespace Com.HolidayGame.MoveExperience {
	
	[CreateAssetMenu(
		menuName = "MoveExperience/Controller",
		fileName = "ControllerSettings",
		order = 0
	)]
	
	public class ControllerSettings : ScriptableObject {
        public float GetAxisHorizontal { get => controller.GetAxisHorizontal; }
        public float GetAxisVertical { get => controller.GetAxisVertical; }
        public bool Jump { get => controller.Jump; }

        private Controller controller = null;  

		public void Init()
        {
            controller = InputManager.Instance.Controller; 
        }
	}
}