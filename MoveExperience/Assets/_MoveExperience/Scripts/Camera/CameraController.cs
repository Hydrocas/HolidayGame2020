///-----------------------------------------------------------------
/// Author : Clément VIEILLY
/// Date : 25/06/2020 11:36
///-----------------------------------------------------------------

using Com.HolidayGame.MoveExperience.Objects.PlayerObjects;
using UnityEngine;

namespace Com.HolidayGame.MoveExperience.Camera {
	public class CameraController : MonoBehaviour {

		[SerializeField] private Transform player = default;
		[SerializeField] private float offSetY = 10f;
		[SerializeField] private float offSetZ = 8f; 
		private void Update()
		{
			transform.rotation = Quaternion.LookRotation(player.position - transform.position, Vector3.up);
			transform.position = new Vector3(player.position.x, player.position.y + offSetY, player.position.z - offSetZ);
		}

		private void OnValidate()
		{
			transform.position = new Vector3(player.position.x, player.position.y + offSetY, player.position.z - offSetZ);
			transform.rotation = Quaternion.LookRotation(player.position - transform.position, Vector3.up);

		}
	}
}