using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inputs), typeof(Rigidbody2D))]
public class Car : MonoBehaviour {
	Rigidbody2D rb = null;
	Inputs inputs;

	[Header("Variabler")]
	[SerializeField] float handling = 50.0f;
	[SerializeField] float acceleration = 1.5f;
	[SerializeField] float deceleration = 4.0f;
	[SerializeField] float maxSpeed = 3.0f;
	[SerializeField] float offroadMultiplier = .6f;
	float velocity = 0.0f;

	bool isOnRoad = true;

	Vector2 inputVector = Vector2.zero;
	private Vector3 lastMovementVector = Vector3.zero;

	// Use this for initialization
	void Start () {
		//henter ut Rigidbody2D-komponenten som ligger på objektet.
		rb = GetComponent<Rigidbody2D> ();
		inputs = GetComponent<Inputs>();
	}
	
	// Update is called once per frame
	void Update () {
		inputVector = inputs.getMovement();
	}

	void FixedUpdate() {
		//velocity = Mathf.Min (velocity / Mathf.Pow (Time.deltaTime, 2), maxSpeed);
		/*
		if(isOffroad){
			velocity *= offroadMultiplier;
		}
		*/
		if(inputVector.y > 0){ //accelerate
			velocity = velocity + (acceleration * Time.deltaTime);
		}else if(inputVector.y < 0){ //brake
			velocity = velocity - (deceleration * Time.deltaTime);
		} else{
			velocity = velocity - ((deceleration/2f) * Time.deltaTime);
		}

		if(isOnRoad){
			velocity = Mathf.Clamp (velocity, 0f, maxSpeed);
		}else{
			velocity = Mathf.Clamp (velocity, 0f, maxSpeed*offroadMultiplier);
		}



		//Debug.Log(velocity);

		Vector3 newMovementVector = new Vector3(-inputVector.x, 0f, 0f);
		if(newMovementVector != Vector3.zero){
			//Debug.Log (newMovementVector);	
			newMovementVector = newMovementVector.normalized;
			//Debug.Log (" normalized: " + newMovementVector);
		}
		lastMovementVector = newMovementVector;

		float rotateAmount = Vector3.Cross (newMovementVector, Vector3.up).z;

		//Debug.Log (transform.right);

		rb.angularVelocity = rotateAmount * handling * (Mathf.Min(1f, velocity));
		rb.velocity = transform.up * velocity;


	}

	public void SetOnRoad(bool value){
		isOnRoad = value;
		Debug.Log ("offroad: " + value);
	}
}
