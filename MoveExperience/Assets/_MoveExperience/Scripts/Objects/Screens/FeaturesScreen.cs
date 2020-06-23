///-----------------------------------------------------------------
/// Author : Hugo TEYSSIER
/// Date : 23/06/2020 16:54
///-----------------------------------------------------------------

using Com.IsartDigital.Four.Common.UI.Object;
using UnityEngine;

namespace Com.HolidayGame.MoveExperience.Objects.Screens {
	public class FeaturesScreen : ScreenObject {
		private static FeaturesScreen instance;
		public static FeaturesScreen Instance => instance;
		
		private void Awake(){
			if (instance){
				Destroy(gameObject);
				return;
			}
			
			instance = this;
		}
		
		private void Start () {
			
		}
		
		private void Update () {
			
		}
		
		private void OnDestroy(){
			if (this == instance) instance = null;
		}
	}
}