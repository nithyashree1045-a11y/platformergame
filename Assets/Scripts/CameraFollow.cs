using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform player;
	public float smoothSpeed = 5f;
	public Vector3 offset;

	void Start()
	{
		offset = transform.position - player.position;
	}

	void LateUpdate()
	{
		// Smooth position follow
		Vector3 desiredPosition = player.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
		transform.position = smoothedPosition;

		// Camera rotates with player
		transform.LookAt(player);
	}
}