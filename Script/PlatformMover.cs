using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformMover : MonoBehaviour {
    public Transform leftPosition;
    public Transform rightPosition;
    public Vector3 newPosition;
    public float smooth;
    public float resetTime;
    public string currentState;

    //public int casenumber;

    public bool lerpLeft;
    public bool lerpRight;
	// Use this for initialization
	void Start () {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            lerpLeft = true;
            lerpRight = false;
            //casenumber = 1;
            //directionalText.text = "Press S to move Right";
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            lerpRight = true;
            lerpLeft = false;
            //casenumber = 2;
            //directionalText.text = "Press A to move left";
        }
    }
           
            
	void FixedUpdate () {
        if (lerpLeft == true)
        {
            transform.position = Vector3.Lerp(transform.position, leftPosition.position, smooth * Time.deltaTime);
        }
        if (lerpRight == true)
        {
            transform.position = Vector3.Lerp(transform.position, rightPosition.position, smooth * Time.deltaTime);
        }
    }

    


}

