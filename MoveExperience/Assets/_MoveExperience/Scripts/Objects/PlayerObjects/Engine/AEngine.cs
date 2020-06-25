///-----------------------------------------------------------------
/// Author : Valérian Segado
/// Date : 23/06/2020 15:44
///-----------------------------------------------------------------

using Com.HolidayGame.Common.Utils.Game;
using Com.HolidayGame.MoveExperience.Objects.Controller;
using System;
using UnityEngine;

namespace Com.HolidayGame.MoveExperience.Objects.PlayerObjects.Engine {
	public abstract class AEngine : ADestroyObject {
		protected Action _doAction;
		public Action DoAction => _doAction;

		protected Rigidbody rigidBody;
		protected ControllerSettings controller;

		public virtual void Init(Rigidbody rb, ControllerSettings controller) {
			SetModeVoid();

			rigidBody = rb;
			this.controller = controller;
		}

		// ============================================================================
		//							 ***** PAUSE / RESUME *****
		// ============================================================================
		public virtual void Pause() {

		}

		public virtual void Resume() {

		}

		// ============================================================================
		//							   ***** DOACTIONS *****
		// ============================================================================
		protected void SetModeVoid() {
			_doAction = DoActionVoid;
		}

		protected void DoActionVoid() {}
	}
}