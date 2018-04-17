using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtScreen : MonoBehaviour {
    private GameObject screen;
	// Use this for initialization
	void Start () {
        screen = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
        
        transform.rotation = screen.transform.rotation;
	}
}
