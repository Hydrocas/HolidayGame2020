///-----------------------------------------------------------------
/// Author : Valérian Segado
/// Date : 30/03/2020 10:58
///-----------------------------------------------------------------

using UnityEngine;

namespace Com.HolidayGame.Common.Utils.Game {
	public abstract class ADestroyObject : MonoBehaviour {
		/// <summary>
		/// Méthode qui permet de détruire un gameObject plus rapidement
		/// </summary>
		public void DestroyGameObject() {
			Destroy(gameObject);
		}
	}
}