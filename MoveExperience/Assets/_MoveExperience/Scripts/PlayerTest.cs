///-----------------------------------------------------------------
/// Author : Clément VIEILLY
/// Date : 23/06/2020 12:46
///-----------------------------------------------------------------

using Com.HolidayGame.MoveExperience.Objects.Controller;
using UnityEngine;

namespace Com.HolidayGame.MoveExperience {
	public class PlayerTest : MonoBehaviour {

        [SerializeField] private ControllerSettings controller = null; 

		private void Update () {
			Debug.Log(controller.Start); 
		}
	}
}