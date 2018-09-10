using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour, Inputs {

	private Vector2 movement;
	
	[SerializeField]
	KeyCode forward = KeyCode.W, brake = KeyCode.S, left = KeyCode.A, right = KeyCode.D;

	// Use this for initialization
	void Start () {
		movement = Vector2.zero;
	}
	
	// Update is called once per frame
	void Update () {
		float x = 0;
		float y = 0;

		// beregner input-vektoren basert på brukerinput
		if (Input.GetKey(forward)) { /* Forward */
			y = 1f;
		} else if(Input.GetKey(brake)) { /* Brake */
			y = -1f;
		}

		if (Input.GetKey(left)) { /* Left */
			x = -1f;
		} else if (Input.GetKey(right)) { /* Right */
			x = 1f;
		}

		movement = new Vector2(x, y);
	}

	// returnerer input-vektoren
	public Vector2 getMovement() {
		return movement;
	}
}
