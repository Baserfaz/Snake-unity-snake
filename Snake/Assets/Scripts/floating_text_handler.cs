using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class floating_text_handler : MonoBehaviour {

	public GameObject ftext;			// Get the floating text prefab
	public Respawner respawner;			// Get respawner to gain access to the instantiated player
	static GameObject inst_ftext;		// This is the instantiated floating text
	GameObject player;					// Instantiated player
	float offset = 0.5f;				// Text offset
	string theText = "+1";				// The text what is shown to player
	float text_timer = 1f;				// Timer time
	float timer;						// Stores the text_timer time

	void Start() {
		inst_ftext = Instantiate (ftext, new Vector2(0f,0f), Quaternion.identity) as GameObject;		// Instantiate ftext
		inst_ftext.GetComponentInChildren<Text> ().enabled = false;										// Disable it
		player = respawner.get_player_inst ();															// Get the instantiated player
		timer = text_timer;

	}

	// Make the instantiated floating text to follow the instantiated player
	void Update() {

		inst_ftext.transform.position = Camera.main.WorldToScreenPoint(new Vector2(player.transform.position.x, player.transform.position.y + offset));

		inst_ftext.GetComponentInChildren<Text> ().text = theText;										// Change the text

		if (text_timer <= 0) {
			inst_ftext.GetComponentInChildren<Text> ().enabled = false;
			text_timer = timer;
		} else { text_timer -= Time.deltaTime; }


	}

	public void enable_text() {
		if (inst_ftext.GetComponentInChildren<Text> ().enabled == false) {
			inst_ftext.GetComponentInChildren<Text> ().enabled = true;									// Enable text
		}
	}
}
