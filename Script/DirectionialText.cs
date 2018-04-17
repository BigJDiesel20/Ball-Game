using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectionialText : MonoBehaviour {
    public bool isRight;
    public bool inPosition;
    public int casenumber;
    public Text displayText;
    public GameObject Right;
    public GameObject Left;

    void Start () {
        displayText = GameObject.FindGameObjectWithTag("Directional Text").GetComponent<Text>();
    }

    void Update () {
        if (inPosition == true && isRight == true)
        {
            casenumber = 1;
        }
        else if (inPosition == true && isRight == false)
        {
            casenumber = 2;
        }
        else
        {
            casenumber = 3;
        }

        switch (casenumber)
        {
            case 1:
                displayText.text = "Press A to move to the left";
                break;
            case 2:
                displayText.text = "Press S to move to the right";
                break;
            default:
                displayText.text = "";
                break;

        }
    }

    void OnTriggerStay (Collider other) {        
        if (other.gameObject == Right)
        {
            isRight = true;

        }
        else if (other.gameObject == Left)
        {
            isRight = false;

        }
    }

    void OnCollisionEnter (Collision other) {
        if (other.gameObject.tag == "Player")
        {
            inPosition = true;
        }
    }
    void OnCollisionExit (Collision other) {
        if (other.gameObject.tag == "Player")
        {
            inPosition = false;
        }
    }
}
