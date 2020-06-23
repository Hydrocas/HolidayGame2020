///-----------------------------------------------------------------
/// Author : Nathan_Pflier
/// Date : 23/06/2020 12:18
///-----------------------------------------------------------------

using UnityEngine;

namespace Com.HolidayGame.MoveExperience {
	public class Controller : MonoBehaviour {

        private string horizontalAxis = "Horizontal"; 
		private string verticalAxis = "Vertical";
        private string jumpAxis = "Jump"; 

		private float _getAxisHorizontal;
		private float _getAxisVertical;
		private bool _jump;

		public float GetAxisHorizontal {
			get { return _getAxisHorizontal; }
		}
		public float GetAxisVertical {
			get { return _getAxisVertical; }
		}
		public bool Jump {
			get { return _jump; }
		}

		private void Start () {
			
		}
		
		public void Update () {
			_getAxisHorizontal = Input.GetAxis (horizontalAxis);
			_getAxisVertical = Input.GetAxis (verticalAxis);
			_jump = Input.GetAxis (jumpAxis) == 1;
		}
	}
}