﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoller : MonoBehaviour {
    private Vector3 offset;
    public GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - player.transform.position;

	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = offset + player.transform.position;
    } 
}
