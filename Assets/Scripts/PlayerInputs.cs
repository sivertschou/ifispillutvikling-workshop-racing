using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour, Inputs {

	private Vector2 movement;
	
	[SerializeField]
	KeyCode up = KeyCode.W, down = KeyCode.S, left = KeyCode.A, right = KeyCode.D;

	// Use this for initialization
	void Start () {
		movement = Vector2.zero;
	}
	
	// Update is called once per frame
	void Update () {
		float x = 0;
		float y = 0;

		if (Input.GetKey(up)) { /* Up */
			y = 1f;
		} else if(Input.GetKey(down)) { /* Down */
			y = -1f;
		}

		if (Input.GetKey(left)) { /* Left */
			x = -1f;
		} else if (Input.GetKey(right)) { /* Right */
			x = 1f;
		}
		movement = new Vector2(x, y);
	}


	public Vector2 getMovement() {
		return movement;
	}
}
