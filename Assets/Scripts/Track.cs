using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track: MonoBehaviour {


	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Car")){
			other.GetComponent<Car>().SetOnRoad (true);
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if(other.CompareTag("Car")){
			other.GetComponent<Car>().SetOnRoad (false);
		}
	}
}
