using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// vi krever at bilen har både en Inputs- og Rigidbody2D-komponent på seg
[RequireComponent(typeof(Inputs), typeof(Rigidbody2D))]
public class Car : MonoBehaviour {
	Rigidbody2D rb = null;
	Inputs inputs;

	[Header("Variabler")]
	[SerializeField] float handling = 150.0f;
	[SerializeField] float acceleration = 1.5f;
	[SerializeField] float deceleration = 4.0f;
	[SerializeField] float maxSpeed = 5.0f;
	[SerializeField] float offroadMultiplier = .6f;
	float velocity = 0.0f;

	bool isOnRoad = true;

	Vector2 inputVector = Vector2.zero;
	private Vector3 lastMovementVector = Vector3.zero;

	// Use this for initialization
	void Start () {
		//henter ut Rigidbody2D-komponenten som ligger på objektet.
		rb = GetComponent<Rigidbody2D> ();

		//henter ut Inputs-script-komponenten som ligger på objektet
		inputs = GetComponent<Inputs>();
	}
	
	// Update is called once per frame
	void Update () {
		//henter input fra Inputs-komponenten
		inputVector = inputs.getMovement();
	}

	void FixedUpdate() {

		if(inputVector.y > 0){ // gi gass
			velocity = velocity + (acceleration * Time.deltaTime);
		}else if(inputVector.y < 0){ // brems
			velocity = velocity - (deceleration * Time.deltaTime);
		} else{ // hverken gass eller brems
			velocity = velocity - ((deceleration/2f) * Time.deltaTime);
		}

		// setter bilens max-speed basert på om bilen er på veien eller ikke
		if(isOnRoad){
			velocity = Mathf.Clamp (velocity, 0f, maxSpeed);
		}else{
			velocity = Mathf.Clamp (velocity, 0f, maxSpeed*offroadMultiplier);
		}

		// beregner rotasjonen basert på x-input
		float rotateAmount = Vector3.Cross (new Vector3(-inputVector.x, 0f, 0f), Vector3.up).z;

		// setter bilens rotasjonshastighet
		rb.angularVelocity = rotateAmount * handling * (Mathf.Min(1f, velocity));
		// setter bilens fartsvektor til å være rett frem basert på bilens rotasjon
		rb.velocity = transform.up * velocity;
		

	}

	public void SetOnRoad(bool value){
		isOnRoad = value;
		Debug.Log ("offroad: " + value);
	}
}
