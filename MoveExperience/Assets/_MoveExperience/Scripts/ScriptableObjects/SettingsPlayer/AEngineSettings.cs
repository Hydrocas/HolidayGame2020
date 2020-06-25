///-----------------------------------------------------------------
/// Author : Valérian Segado
/// Date : 25/06/2020 11:21
///-----------------------------------------------------------------

using UnityEngine;

namespace Com.HolidayGame.MoveExperience.SettingsPlayer {
	
	public abstract class AEngineSettings : ScriptableObject {
		[SerializeField] private uint _test = 42;
		public uint Test => _test;
	}
}