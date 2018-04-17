using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairCameraMover : MonoBehaviour {
    public CameraChanger changer;
    public GameObject player;
    public Vector3 startPosition;
    public float zOffset;
    public Vector3 Offset;

	// Use this for initialization
	void Start () {
        startPosition = transform.position; 
	}
	
	// Update is called once per frame
	void Update () {
        if (changer.isStairCaseCamera == true && gameObject.tag == "StairCam" || changer.isPortalCamera == true && gameObject.tag == "PortalCam")
        {
            transform.position = new Vector3(startPosition.x, startPosition.y, zOffset + player.transform.position.z);
        }
        if (changer.isSmasher == true && gameObject.tag == "SmasherCam")
        {
            transform.position = new Vector3 (player.transform.position.x,player.transform.position.y + 5f,player.transform.position.z - 7f);
        }

	}


}
