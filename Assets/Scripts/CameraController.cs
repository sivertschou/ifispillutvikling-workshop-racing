using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	[SerializeField] Transform carTrans = null;
	
	// Update is called once per frame
	void Update () {
		transform.position = carTrans.position + new Vector3(0f,0f,-10f);
	}
}
