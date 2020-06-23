///-----------------------------------------------------------------
/// Author : Clément VIEILLY
/// Date : 23/06/2020 12:46
///-----------------------------------------------------------------

using UnityEngine;

namespace Com.HolidayGame.MoveExperience {
	public class PlayerTest : MonoBehaviour {

        [SerializeField] private ControllerSettings controller; 

		private void Update () {
            Debug.Log(controller.Jump); 
		}
	}
}