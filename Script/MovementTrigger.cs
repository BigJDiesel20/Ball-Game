using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTrigger : MonoBehaviour {


    public bool moveleft;
    public bool moveright;
    public GameObject lastGameObject;
    // Use this for initialization
    void Start () {
        moveleft = false;
        moveright = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    

    private void OnTriggerEnter(Collider other)
    {
        lastGameObject = other.gameObject;
        if (other.gameObject.tag == "leftPlatform")
        {
            moveleft = false;
        }
        if (other.gameObject.tag == "rightPlatform")
        {
            moveright = false;
        }
    }
}
