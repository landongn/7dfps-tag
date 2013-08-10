using UnityEngine;
using System.Collections;

public class FPSLook : MonoBehaviour {
	
	public float sensitivity = 10.0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3(0, Input.GetAxis("Mouse X")*sensitivity, 0), Space.World);
		transform.Rotate (new Vector3(-Input.GetAxis("Mouse Y")*sensitivity, 0, 0));
	}
}
