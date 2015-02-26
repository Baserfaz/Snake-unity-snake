using UnityEngine;
using System.Collections;

public class movement_controller : MonoBehaviour {

	//Vector3 mousePos;
	public float movementSpeed = 1f;
	public float rotateSpeed = 5f;
	public float start_timer = 2f;

	void FixedUpdate() {
		if (start_timer <= 0f) {
			//add constant force to the player.
			rigidbody2D.AddRelativeForce (Vector2.right * movementSpeed);
		} else { start_timer -= Time.deltaTime; }

	}

	void Update () {
	
		//rotation handler
		//transform.Rotate (Vector3.forward * -Input.GetAxisRaw("Horizontal") * rotateSpeed);

		Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		diff.Normalize();
		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
	}
}
