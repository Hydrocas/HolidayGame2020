///-----------------------------------------------------------------
/// Author : Valérian Segado
/// Date : 25/06/2020 11:15
///-----------------------------------------------------------------

using UnityEngine;

namespace Com.HolidayGame.MoveExperience.SettingsPlayer {
	
	[CreateAssetMenu(
		menuName = "MoveExperience/Engines/DefaultEngine",
		fileName = "DefaultEngine"
	)]
	
	public class DefaultEngineSettings : ScriptableObject {
		[Header("Settings")]
		[SerializeField] protected float _speed = 5;
		[SerializeField] protected float _jumpForce = 200;

		public float Speed => _speed;
		public float JumpForce => _jumpForce;
	}
}