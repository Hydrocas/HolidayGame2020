///-----------------------------------------------------------------
/// Author : Valérian Segado
/// Date : 23/06/2020 17:26
///-----------------------------------------------------------------

using Com.HolidayGame.MoveExperience.Objects.Controller;
using Com.HolidayGame.MoveExperience.SettingsPlayer;
using UnityEngine;

namespace Com.HolidayGame.MoveExperience.Objects.PlayerObjects.Engine {
	public class DefaultEngine : AEngine {
		[SerializeField] protected DefaultEngineSettings settings;

		public override void Init(Rigidbody rb, ControllerSettings controller) {
			base.Init(rb, controller);
			SetModeMove();
		}

		protected void SetModeMove() {
			_doAction = DoActionMove;
		}

		protected void DoActionMove() {
			float speed = settings.Speed;

			rigidBody.transform.position += Vector3.forward * (speed * Time.deltaTime * controller.GetAxisVertical);
			rigidBody.transform.position += Vector3.right * (speed * Time.deltaTime * controller.GetAxisHorizontal);

			if (controller.Jump) {
				rigidBody.AddForce(Vector3.up * settings.JumpForce);
			}
		}
	}
}