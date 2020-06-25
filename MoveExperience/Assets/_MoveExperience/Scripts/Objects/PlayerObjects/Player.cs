///-----------------------------------------------------------------
/// Author : Valérian Segado
/// Date : 23/06/2020 15:43
///-----------------------------------------------------------------

using Com.HolidayGame.MoveExperience.Objects.Controller;
using Com.HolidayGame.MoveExperience.Objects.PlayerObjects.Engine;
using Com.IsartDigital.Common.Utils.Game;
using System;
using UnityEngine;

namespace Com.HolidayGame.MoveExperience.Objects.PlayerObjects {
	public class Player : AStateMachine {
		[SerializeField] protected ControllerSettings controller = default;
		[SerializeField] protected Rigidbody rb = default;
		[SerializeField] protected Transform enginesTranform = default;
		[Space]
		[SerializeField] protected Engines[] engines = default;

		protected AEngine engine;

		// ============================================================================
		//					        ***** PAUSE / RESUME *****
		// ============================================================================
		protected override void SetResume() {
			base.SetResume();
			//rb
		}

		protected override void SetPause() {
			base.SetPause();
			//rb
		}

		// ============================================================================
		//							   ***** DOACTIONS *****
		// ============================================================================
		protected override void Start() {
			base.Start();
			if (engine == null) InitEngine("DefaultEngine");
		}

		/// <summary>
		/// Permet de donner un moteur au Player
		/// </summary>
		/// <param name="engine"> Le moteur donné au player </param>
		public void InitEngine(string engineName) {
			if (engine != null) {
				engine.DestroyGameObject();
				//Réfléchir a un ResetEngine
			}
			engine = null;

			for (int i = engines.Length - 1; i >= 0; i--) {
				if (engines[i].EngineName == engineName) {
					engine = Instantiate(engines[i].EnginePrefab, enginesTranform);
					break;
				}
			}

			if (engine == null) {
				Debug.LogError("[Player] IL n'y pas d'engine avec ce nom: " + engineName);
				return;
			}

			engine.Init(rb, controller);
			SetModeNormal();
		}

		protected void SetModeNormal() {
			doAction = DoActionNormal;
		}

		protected void DoActionNormal() {
			engine.DoAction();
		}

		[Serializable]
		protected class Engines {
			[SerializeField] protected string _engineName = default;
			[SerializeField] protected AEngine _enginePrefab = default;

			public string EngineName => _engineName;
			public AEngine EnginePrefab => _enginePrefab;
		}
	}
}