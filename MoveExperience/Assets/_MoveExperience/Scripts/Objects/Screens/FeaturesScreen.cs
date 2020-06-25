///-----------------------------------------------------------------
/// Author : Hugo TEYSSIER
/// Date : 23/06/2020 16:54
///-----------------------------------------------------------------

using Com.HolidayGame.MoveExperience.Objects.Features;
using Com.IsartDigital.Four.Common.UI.Object;
using System.Collections.Generic;
using UnityEngine;

namespace Com.HolidayGame.MoveExperience.Objects.Screens {
	public class FeaturesScreen : ScreenObject {
		private static FeaturesScreen instance;
		public static FeaturesScreen Instance => instance;

		[SerializeField] public Transform circleFeature;
		public TextMesh floatingText;
		private float radius = 500f;

		private void Awake(){
			if (instance){
				Destroy(gameObject);
				return;
			}
			
			instance = this;
		}
		private void Start() {
			circleFeature.gameObject.SetActive (false);
		}

		public void FeatureWheel(List<AFeature> list) {
			TextMesh lFloatingText = new TextMesh();
			circleFeature.gameObject.SetActive (true);
			float lNumber = Mathf.PI * 2 / list.Count;
			Vector3 lVector3 = new Vector3 ();

			for (int i = 1; i <= list.Count; i++) {
				lFloatingText = Instantiate (lFloatingText); 
				//lFloatingText.text = "bite";
				lVector3.Set (Mathf.Cos (lNumber * i) * radius, Mathf.Sin (lNumber * i) * radius, 0);
				lFloatingText.transform.position = transform.TransformPoint (lVector3 - circleFeature.position);
			}
		}
		
		private void OnDestroy(){
			if (this == instance) instance = null;
		}
	}
}