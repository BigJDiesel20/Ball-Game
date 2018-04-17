using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionRotator : MonoBehaviour {
    private GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 relativePos = player.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(new Vector3(relativePos.x, 0f, relativePos.z));
	}
}
