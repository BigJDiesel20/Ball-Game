using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {
    public GameObject Smasher;
    public Falling falling;
    public CameraChanger changer;


    // Use this for initialization
    void Start () {
        falling = Smasher.GetComponent<Falling>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            falling.isinTrigger = true;
        }
        if (other.gameObject.tag == "Player" && gameObject.tag == "AnvilTrigger1" || gameObject.tag == "AnvilTrigger2" ||gameObject.tag == "AnvilTrigger3" ||  gameObject.tag == "AnvilTrigger4")
        { 
            Debug.Log("Entered");
            changer.isSmasher = true;

        }

       

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && gameObject.tag == "AnvilTrigger1" || gameObject.tag == "AnvilTrigger2" ||gameObject.tag == "AnvilTrigger3" ||  gameObject.tag == "AnvilTrigger4")
        { 
            Debug.Log("Exit");
            changer.isSmasher = false;

        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && falling.isstartPosition == true)
        {
            falling.isinTrigger = true;
        }

        
    }

    


}
