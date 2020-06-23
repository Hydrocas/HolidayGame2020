///-----------------------------------------------------------------
/// Author : Nathan_Pflier
/// Date : 23/06/2020 18:03
///-----------------------------------------------------------------

using Com.HolidayGame.MoveExperience.Objects.Features;
using Com.HolidayGame.MoveExperience.Objects.PlayerObjects;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Com.HolidayGame.MoveExperience {
	public class FeatureManager : MonoBehaviour {

		private List<AFeature> featureList = new List<AFeature> ();

		private AFeature currentFeature;
		private Player player; 
		private int defaultFeatureNumb = 0;

		private void Start () {
			GetDefaultFeature ();
		}

		private void Init() {
			//prend un player
			player = null;
		}

		private void GetDefaultFeature() {
			GetFeature (defaultFeatureNumb);
		}

		private void GetFeature( int feature ) {
			if (currentFeature != null) currentFeature.Off (player);
			currentFeature = featureList[feature];
			currentFeature.On (player);
		}
	}
}