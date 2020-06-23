///-----------------------------------------------------------------
/// Author : Nathan_Pflier
/// Date : 23/06/2020 18:03
///-----------------------------------------------------------------

using Com.HolidayGame.MoveExperience.Objects.Features;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Com.HolidayGame.MoveExperience {
	public class FeatureManager : MonoBehaviour {

		private List<AFeature> featureList = new List<AFeature> ();

		private AFeature currentFeature;
		private int defaultFeatureNumb = 0;

		private void Start () {
			GetDefaultFeature ();
		}

		private void GetDefaultFeature() {
			GetFeature (defaultFeatureNumb);
		}

		private void GetFeature( int feature ) {
			if (currentFeature != null) currentFeature.Off ();
			currentFeature = featureList[feature];
			currentFeature.On ();
		}
	}
}