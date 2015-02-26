using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Growth_Manager : MonoBehaviour {

	public GameObject[] body_parts;
	GameObject instantiated_bpart;
	GameObject player_head;
	GameObject previous;
	bool isSecond = false;

	void Start() {
		player_head = GameObject.FindGameObjectWithTag ("Player");
	}

	public void Grow(string name) {

		if (previous == null) {

			//instantiate body part

			Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
			instantiated_bpart = (GameObject)Instantiate (get_body(name), pos, transform.rotation);				// Call method to figure which body part will be instantiated

			//Disable the collider on the first body part
			instantiated_bpart.collider2D.enabled = false;

			//create a spring joint & add attributes to it

			SpringJoint2D joint = instantiated_bpart.AddComponent<SpringJoint2D>();
			joint.connectedBody = player_head.rigidbody2D;
			joint.distance = 0.2f;
			joint.frequency = 0f;
			joint.connectedAnchor = new Vector2(-0.14f, 0f);
			joint.dampingRatio = 0f;

			//set the previous' value to newest instantiated body part.

			previous = instantiated_bpart;

			isSecond = true;

		} else if (previous != null) {

			//instantiate body part at the position of previous body part

			Vector3 pos = new Vector3(previous.transform.position.x, previous.transform.position.y, previous.transform.position.z);
			instantiated_bpart = (GameObject)Instantiate (get_body(name), pos, previous.transform.rotation);										// TODO Call method to figure which body part will be instantiated

			if (isSecond) {
				instantiated_bpart.collider2D.enabled = false;
			}

			isSecond = false;

			//create a spring joint & add attributes to it

			SpringJoint2D joint = instantiated_bpart.AddComponent<SpringJoint2D>();
			joint.connectedBody = previous.rigidbody2D;
			joint.distance = 0.2f;
			joint.frequency = 0f;
			joint.dampingRatio = 0f;

			//set the previous' value to newest instantiated body part.

			previous = instantiated_bpart;

		}
	}

	GameObject get_body (string applename) {

		GameObject selectedBody;

		switch (applename) {

			case ("Apple(Clone)"):
				selectedBody = body_parts[3];
				break;

			case ("Apple_01(Clone)"):
				selectedBody = body_parts[6];
				break;
			
			case ("Apple_02(Clone)"):
				selectedBody = body_parts[1];
				break;

			case ("Apple_03(Clone)"):
				selectedBody = body_parts[4];
				break;

			case ("Apple_04(Clone)"):
				selectedBody = body_parts[5];
				break;

			case ("Apple_05(Clone)"):
				selectedBody = body_parts[0];
				break;

			case ("Apple_06(Clone)"):
				selectedBody = body_parts[2];
				break;

			case ("Apple_07(Clone)"):
				selectedBody = body_parts[7];
				break;

			case ("Apple_08(Clone)"):
				selectedBody = body_parts[9];
				break;

			case ("Apple_09(Clone)"):
				selectedBody = body_parts[10];
				break;

			case ("Apple_10(Clone)"):
				selectedBody = body_parts[8];
				break;

			case ("Apple_11(Clone)"):
				selectedBody = body_parts[11];
				break;

			default:
				selectedBody = body_parts[0];
				break;
		}	

		return(selectedBody);
	}


}
