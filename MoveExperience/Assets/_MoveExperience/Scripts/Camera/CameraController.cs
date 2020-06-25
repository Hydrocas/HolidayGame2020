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
		[SerializeField, Range(0, 20)] private float radius;
		private float horizontalAngle = 1;
		private float verticalAngle = 1;
		private Vector3 newDirection;
		private void Update()
		{
			horizontalAngle += player.rotation.y * Time.deltaTime * 1;
		
			//transform.position = new Vector3(player.position.x, player.position.y + offSetY, player.position.z - offSetZ);

			newDirection.x = radius * Mathf.Cos(verticalAngle) * Mathf.Cos(horizontalAngle);
			newDirection.y = radius * Mathf.Sin(verticalAngle);
			newDirection.z = radius * Mathf.Cos(verticalAngle) * Mathf.Sin(horizontalAngle);


			transform.position = newDirection;
			transform.rotation = Quaternion.LookRotation(player.position - transform.position, Vector3.up);
		}

		private void OnValidate()
		{
			transform.position = new Vector3(player.position.x, player.position.y + offSetY, player.position.z - offSetZ);
			transform.rotation = Quaternion.LookRotation(player.position - transform.position, Vector3.up);

		}
	}
}