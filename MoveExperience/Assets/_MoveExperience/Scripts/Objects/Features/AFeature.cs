///-----------------------------------------------------------------
/// Author : Nathan_Pflier
/// Date : 23/06/2020 17:39
///-----------------------------------------------------------------

using Com.HolidayGame.MoveExperience.Objects.PlayerObjects;
using Com.HolidayGame.MoveExperience.Objects.PlayerObjects.Engine;
using UnityEngine;

namespace Com.HolidayGame.MoveExperience.Objects.Features {
	public class AFeature : MonoBehaviour {

		virtual public void On( Player player ) { }

		virtual public void Off( Player player ) { }
	}
}