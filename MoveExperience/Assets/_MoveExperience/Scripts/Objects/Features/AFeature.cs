///-----------------------------------------------------------------
/// Author : Nathan_Pflier
/// Date : 23/06/2020 17:39
///-----------------------------------------------------------------

using Com.HolidayGame.MoveExperience.Objects.PlayerObjects;
using UnityEngine;

namespace Com.HolidayGame.MoveExperience.Objects.Features {
	public class AFeature : MonoBehaviour {

		
		private void Start () {
			
		}

		virtual public void On(Player player) {
			//player.InitEngine ();
		}

		virtual public void Off( Player player ) { 
		}
	}
}