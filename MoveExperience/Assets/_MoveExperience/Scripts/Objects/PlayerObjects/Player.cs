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
		[SerializeField] protected EngineObject[] engineObjects = default;

		protected AEngine engine;

		// ============================================================================
		//					        ***** PAUSE / RESUME *****
		// ============================================================================
		protected override void SetResume() {
			base.SetResume();
			if (engine != null) engine.Resume();
			//rb
		}

		protected override void SetPause() {
			base.SetPause();
			if (engine != null) engine.Pause();
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

			EngineObject lEngineObject;
			for (int i = engineObjects.Length - 1; i >= 0; i--) {
				lEngineObject = engineObjects[i];

				if (lEngineObject.EngineName == engineName) {
					engine = Instantiate(lEngineObject.EnginePrefab, enginesTranform);
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
		protected class EngineObject {
			[SerializeField] protected string _engineName = default;
			[SerializeField] protected AEngine _enginePrefab = default;

			public string EngineName => _engineName;
			public AEngine EnginePrefab => _enginePrefab;
		}
	}
}