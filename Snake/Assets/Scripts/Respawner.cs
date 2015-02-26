using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Respawner : MonoBehaviour {

	public GameObject head;
	GameObject inst_player;

	//Instantiate the player 
	void Awake() {
		Vector3 pos = new Vector3 (-1, -1, 0); 		// Starting point
		inst_player = Instantiate (head, pos, Quaternion.identity) as GameObject;
	}
	            
	public void respawn() {
		Application.LoadLevel ("Scene_01");
	}

	public GameObject get_player_inst() {
		return (inst_player);
	}
}
