using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lighthouse_rotation : MonoBehaviour {
    int speed = 50;//10;
	// Use this for initialization
	void Start () {
		this.transform.localEulerAngles = new Vector3(30,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		//transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
		this.transform.Rotate(Vector3.up * Mathf.Cos(30 * Mathf.Deg2Rad) * Time.deltaTime * speed,Space.World);//*Mathf.Cos(30*Mathf.Deg2Rad)
	}
}
