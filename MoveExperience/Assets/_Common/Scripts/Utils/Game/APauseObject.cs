///-----------------------------------------------------------------
/// Author : Valérian Segado
/// Date : 30/03/2020 11:02
///-----------------------------------------------------------------

using System.Collections.Generic;

namespace Com.HolidayGame.Common.Utils.Game {
	public abstract class APauseObject : ADestroyObject {
		//Ils sont en private pour que les classes filles ne puissent pas les manipuler.
		private static readonly List<APauseObject> instances = new List<APauseObject>();
		private bool _isResume = true;
		protected bool IsResume => _isResume;
		private bool isAddInInstances = false;

		/// <summary>
		/// Pause tout les gameobject, instance de APauseObject
		/// </summary>
		public static void PauseAll() {
			for (int i = instances.Count - 1; i >= 0; i--) {
				instances[i].Pause();
			}
		}

		/// <summary>
		/// Resume tout les gameobject, instance de APauseObject
		/// </summary>
		public static void ResumeAll() {
			for (int i = instances.Count - 1; i >= 0; i--) {
				instances[i].Resume();
			}
		}

		protected virtual void Start () {
			AddInInstances();
		}

		/// <summary>
		/// Permet d'ajouter un élément dans instances même sans avoir accès à la liste
		/// (Ne peut le faire qu'une fois)
		/// </summary>
		protected void AddInInstances() {
			if (isAddInInstances) return;

			isAddInInstances = true;
			instances.Add(this);
		}

		/// <summary>
		/// Pause le GameObject (Protection pour éviter de faire deux fois un pause)
		/// </summary>
		public void Pause() {
			if (_isResume) {
				SetPause();
				_isResume = false;
			}
		}
		/// <summary>
		/// UnPause le GameObject (Protection pour éviter de faire deux fois un resume)
		/// </summary>
		public void Resume() {
			if (!_isResume) {
				SetResume();
				_isResume = true;
			}
		}

		/// <summary>
		/// C'est dans cette méthode qu'on donne toutes les actions pour mettre le GameObject en pause
		/// </summary>
		protected virtual void SetPause() {

		}

		/// <summary>
		/// C'est dans cette méthode qu'on donne toutes les actions pour mettre le GameObject en resume
		/// </summary>
		protected virtual void SetResume() {

		}

		protected virtual void OnDestroy() {
			instances.Remove(this);
		}
	}
}