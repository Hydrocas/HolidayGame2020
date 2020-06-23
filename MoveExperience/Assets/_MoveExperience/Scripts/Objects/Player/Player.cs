///-----------------------------------------------------------------
/// Author : Valérian Segado
/// Date : 23/06/2020 15:43
///-----------------------------------------------------------------

using Com.HolidayGame.MoveExperience.Objects.Controller;
using Com.HolidayGame.MoveExperience.Objects.Player.Engine;
using Com.IsartDigital.Common.Utils.Game;
using UnityEngine;

namespace Com.HolidayGame.MoveExperience.Objects.Player {
	public class Player : AStateMachine {
		[SerializeField] protected ControllerSettings controller = default;
		[SerializeField] protected Rigidbody rb;

		protected AEngine engine;

		// ============================================================================
		//					        ***** PAUSE / RESUME *****
		// ============================================================================
		protected override void SetResume() {
			base.SetResume();

			if (engine != null) engine.Resume();
		}

		protected override void SetPause() {
			base.SetPause();

			if (engine != null) engine.Pause();
		}

		// ============================================================================
		//							   ***** DOACTIONS *****
		// ============================================================================

		/// <summary>
		/// Permet de donner un moteur au Player
		/// </summary>
		/// <param name="engine"> Le moteur donné au player </param>
		public void InitEngine(AEngine engine) {
			this.engine = engine;
			engine.Init(rb, controller);

			SetModeNormal();
		}

		protected void SetModeNormal() {
			doAction = DoActionNormal;
		}

		protected void DoActionNormal() {
			engine.DoAction();
		}
	}
}