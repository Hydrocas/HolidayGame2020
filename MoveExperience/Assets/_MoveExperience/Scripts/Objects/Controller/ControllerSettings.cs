///-----------------------------------------------------------------
/// Author : Clément VIEILLY
/// Date : 23/06/2020 12:22
///-----------------------------------------------------------------

using UnityEngine;

namespace Com.HolidayGame.MoveExperience.Objects.Controller {
	
	[CreateAssetMenu(
		menuName = "MoveExperience/Controller",
		fileName = "ControllerSettings",
		order = 0
	)]
	
	public class ControllerSettings : ScriptableObject {
        public float GetAxisHorizontal { get => controller.GetAxisHorizontal; }
        public float GetAxisVertical { get => controller.GetAxisVertical; }
        public bool Jump { get => controller.Jump; }

		[SerializeField] private Controller controller = null;  
	}
}