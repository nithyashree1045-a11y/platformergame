using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed = 5f;
	public float rotateSpeed = 100f;

	void Update()
	{
		// Move Forward
		float move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
		transform.Translate(Vector3.forward * move);

		// Rotate Left & Right
		float rotate = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
		transform.Rotate(Vector3.up * rotate);
	}
}
