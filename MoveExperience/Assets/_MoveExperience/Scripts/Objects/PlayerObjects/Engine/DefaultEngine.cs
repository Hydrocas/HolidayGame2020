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
			float lSpeed = settings.Speed;
			float lDeltaTime = Time.deltaTime;

			rigidBody.transform.position += Vector3.forward * (lSpeed * lDeltaTime * controller.GetAxisVertical);
			rigidBody.transform.position += Vector3.right * (lSpeed * Time.deltaTime * controller.GetAxisHorizontal);

			//Use AddForce avec un autre forcemode pour le bouger ?

			if (controller.Jump) {
				rigidBody.AddForce(Vector3.up * settings.JumpForce, ForceMode.VelocityChange);
			}
		}
	}
}