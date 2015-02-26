using UnityEngine;
using System.Collections;

public class collider_controller : MonoBehaviour {

	public GameObject gm;							// Get the GameMaster prefab
	public Growth_Manager grow_m;					// Get the Growth_manager script from player_head
	public movement_controller mov_ctr;				// Get the movement_controller script from player_head
	public floating_text_handler fth;				// Get the floating text handler script from gamemaster

	void OnTriggerEnter2D (Collider2D col) {

		if (col.gameObject.tag == "Apple") {
			Destroy(col.gameObject); 				// Destroy apple
			grow_m.Grow(col.name);							// Add part to snake (Maybe pass a col.name -> in growth manager if (col.name == "Apple_01") instantiate(body_01); )
			mov_ctr.movementSpeed += 1.5f;			// Add speed
			fth.enable_text();						// Call method to show text to player
		}

		if (col.gameObject.tag == "Wall" || col.gameObject.tag == "Body") {
			gm.GetComponent<Respawner>().respawn();
		}

		if (col.gameObject.tag == "powerup_speed") {
			//TODO add movementspeed for 10 seconds? and add trail renderer
			//TODO random powerup respawner 
			//TODO add animation to powerup
		}

	}
}
