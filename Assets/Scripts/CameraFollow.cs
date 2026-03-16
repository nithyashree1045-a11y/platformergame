using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform player;      // Player to follow
	public Vector3 offset;        // Distance between camera and player
	public float smoothSpeed = 5f;

	void LateUpdate()
	{
		Vector3 desiredPosition = player.TransformPoint(offset);
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
		transform.position = smoothedPosition;

		transform.LookAt(player); // Camera always looks at player
	}
}