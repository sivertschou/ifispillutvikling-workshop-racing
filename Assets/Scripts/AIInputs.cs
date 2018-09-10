using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInputs : MonoBehaviour, Inputs {

	private Vector2 movement;
	private Transform [] waypoints;
	private int currPoint = 1;
	private float angleDeadzone = 2;
	private float lengthDeadzone = 1f;

	private int count = 0;
	private int countDrivingSlowly = 10;
	private bool slowedDown = true;


	// Use this for initialization
	void Start () {
		waypoints = GameObject.FindGameObjectWithTag("Waypoints").transform.GetComponentsInChildren<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {

		movement = new Vector2(0, 1);

		Vector2 toPoint = waypoints [currPoint].position - transform.position;
		// Check if we have reached checkpoint, assign new if we have
		if (toPoint.magnitude < lengthDeadzone) {
			currPoint = (currPoint + 1) % waypoints.Length;
			toPoint = waypoints [currPoint].position - transform.position;
		}

		// Calculate angle to waypoint and rotate towards it
		float angleToPoint = Vector2.SignedAngle(transform.up, toPoint);

		if(Mathf.Abs(angleToPoint) > angleDeadzone) {
			if(angleToPoint < 0) {
				movement.x = 1f;
			} else {
				movement.x = -1f;
			}
		}

		// If close to point and angle is to great, slow down
		if(toPoint.magnitude < 10f && angleToPoint > 20) {
			if(!slowedDown) {
				if (count != 0) count--;
				else slowedDown = true;
			} else {
				if(count  < countDrivingSlowly) {
					Debug.Log("Driving slowly");
					movement.y = -1f;
					count++;
				} else {
					slowedDown = false;
				}
			}
		}

	}

	void OnDrawGizmos() {
		if (waypoints == null || waypoints.Length == 0) return;

		Gizmos.color = Color.red;
		Gizmos.DrawLine(transform.position, waypoints [currPoint].position);
		Gizmos.DrawLine(transform.position, transform.position + transform.up * 5);
	}

	public Vector2 getMovement() {
		return movement;
	}
}
