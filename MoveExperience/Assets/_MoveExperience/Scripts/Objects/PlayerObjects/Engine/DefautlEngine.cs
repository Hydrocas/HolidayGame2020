///-----------------------------------------------------------------
/// Author : Valérian Segado
/// Date : 23/06/2020 17:26
///-----------------------------------------------------------------

using Com.HolidayGame.MoveExperience.Objects.Controller;
using UnityEngine;

namespace Com.HolidayGame.MoveExperience.Objects.PlayerObjects.Engine {
	public class DefautlEngine : AEngine {

		public override void Init(Rigidbody rb, ControllerSettings controller) {
			base.Init(rb, controller);
			SetModeMove();
		}

		protected void SetModeMove() {
			_doAction = DoActionMove;
		}

		protected void DoActionMove() {
			Debug.Log("Move");
		}
	}
}