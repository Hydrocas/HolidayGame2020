///-----------------------------------------------------------------
/// Author : Valérian Segado
/// Date : 30/03/2020 11:51
///-----------------------------------------------------------------

using Com.HolidayGame.Common.Utils.Game;
using System;
using UnityEngine;

namespace Com.IsartDigital.Common.Utils.Game {
	public abstract class AStateMachine : APauseObject {
		/// <summary>
		/// Sauvegarde le dernier doAction avant une pause. (Private pour qu'il ne soit pas utiliser dans des classes filles.)
		/// </summary>
		private Action lastDoActionBeforePause;

		/// <summary>
		/// Machine à états
		/// </summary>
		protected Action doAction;

		protected override void Start() {
			base.Start();
			if (doAction == null) SetModeVoid();
		}

		virtual protected void Update () {
			doAction();
		}

		// ============================================================================
		//							   ***** DOACTIONS *****
		// ============================================================================
		
		protected void SetModeVoid() {
			doAction = DoActionVoid;
		}

		/// <summary>
		/// Mode void
		/// </summary>
		protected void DoActionVoid() {}

		protected void SetModePause() {
			doAction = DoActionPause;
		}

		/// <summary>
		/// Mode pause pour permettre aux objets de ne pas faire leurs derniers doAction après une pause
		/// </summary>
		virtual protected void DoActionPause() {

		}

		// ============================================================================
		//							***** PAUSE / RESUME *****
		// ============================================================================

		protected override void SetPause() {
			base.SetPause();

			if (doAction == DoActionPause) Debug.LogWarning("Warning, this object is already in SetModePause");

			lastDoActionBeforePause = doAction;
			SetModePause();
		}

		protected override void SetResume() {
			base.SetResume();

			if (lastDoActionBeforePause == DoActionPause)	Debug.LogWarning("Warning, he stays in SetModePause");
			else if	(lastDoActionBeforePause == null)		Debug.LogError("Uses Resume and not SetResume !");

			doAction = lastDoActionBeforePause;
			lastDoActionBeforePause = null;
		}
	}
}