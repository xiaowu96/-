﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasures : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collisionInfo)
	{
		if (collisionInfo.collider.tag == "myBoat")
		{
			Destroy(gameObject);
		}

	}
}
