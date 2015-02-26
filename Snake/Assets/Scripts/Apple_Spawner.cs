using UnityEngine;
using System.Collections;

public class Apple_Spawner : MonoBehaviour {
	
	public GameObject[] Apples;
	public GameObject effect;

	void Start() {
		Instantiate_Apple (10);
	}

	void Update() {
		if (noApplesLeft()) {
			Instantiate_Apple (1);
		}
	}

	public void Instantiate_Apple (int number) {
		for(int i = 0; i < number; i++) {
			Vector3 pos = new Vector3(random_value(), random_value(), 10);
			pos = Camera.main.ViewportToWorldPoint(pos);
			int rnum = Random.Range(0, Apples.Length);
			Apples[rnum].gameObject.transform.position = pos;
			GameObject go = (GameObject)Instantiate (Apples[rnum]);
			GameObject ps = Instantiate(effect, new Vector2(go.transform.position.x, go.transform.position.y), Quaternion.identity) as GameObject;
			ps.transform.parent = go.transform;
		}
	}

	float random_value() {
		bool ok = false;
		float rnum = 0.0f;

		while (!ok) {
			rnum = Random.value;
		
			if(rnum < 0.9f && rnum > 0.1f) {
				ok = true;
			}
		}
		return(rnum);
	}
	
	bool noApplesLeft() {
		bool apples = false;

		if (!GameObject.FindGameObjectWithTag ("Apple")) {
			apples = true;
		}
		return (apples);
	}
}
