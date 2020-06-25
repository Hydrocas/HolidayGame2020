///-----------------------------------------------------------------
/// Author : Nathan_Pflier
/// Date : 23/06/2020 17:57
///-----------------------------------------------------------------

using Com.HolidayGame.MoveExperience.Objects.PlayerObjects;

namespace Com.HolidayGame.MoveExperience.Objects.Features {
	public class DefaultFeature : AFeature {

		public override void On( Player player ) {
			base.On (player);
			player.InitEngine ("DefaultEngine");
		}
	}
}