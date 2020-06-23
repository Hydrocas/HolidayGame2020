///-----------------------------------------------------------------
/// Author : Nathan_Pflier
/// Date : 23/06/2020 12:18
///-----------------------------------------------------------------

using UnityEngine;

namespace Com.HolidayGame.MoveExperience {
	public class Controller : MonoBehaviour {

		[SerializeField] private string horizontalAxis;
		[SerializeField] private string verticalAxis;
		[SerializeField] private string jumpAxis;

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
		
		private void Update () {
			_getAxisHorizontal = Input.GetAxis (horizontalAxis);
			_getAxisVertical = Input.GetAxis (verticalAxis);
			_jump = Input.GetAxis (jumpAxis) == 1;
		}
	}
}