///-----------------------------------------------------------------
/// Author : Nathan_Pflier
/// Date : 23/06/2020 12:18
///-----------------------------------------------------------------

using UnityEngine;
using System;

namespace Com.HolidayGame.MoveExperience.Objects.Controller {
	[Serializable]
	public class Controller {

        [SerializeField] private string horizontalAxis = "Horizontal";
		[SerializeField] private string verticalAxis = "Vertical";
		[SerializeField] private string jumpAxis = "Jump"; 

		public float GetAxisHorizontal {
			get { return Input.GetAxis(horizontalAxis); }
		}
		public float GetAxisVertical {
			get { return Input.GetAxis(verticalAxis); }
		}
		public bool Jump {
			get { return Input.GetButtonDown(jumpAxis); }
		}
	}
}