using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour {
    public CameraChanger changer;
    public GameObject Camera;
    public GameObject player;
    public StairCameraMover scMover;
    public StairCameraMover pMover;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && gameObject.tag == "BCC Trigger")
        {
            changer.isBottomCenterCamera = true;
            if (changer.isBottomCenterCamera == true)
            {
                changer.isBottomLeftCamera = false;
                changer.isBottomRightCamera = false;
                changer.isPortalCamera = false;
                changer.isStairCaseCamera = false;
                changer.isLeftCloudCamera = false;
                changer.isRightCloudCamera = false;


            }

            //Camera.transform.eulerAngles = new Vector3(Camera.transform.eulerAngles.x, Camera.transform.eulerAngles.y + 90f, Camera.transform.eulerAngles.z);
            //Camera.transform.position = new Vector3(Camera.transform.position.x - 16f, Camera.transform.position.y, Camera.transform.position.z);
        }
        if (other.gameObject == player && gameObject.tag == "BLC Trigger")
        {
            changer.isBottomLeftCamera = true;


            if (changer.isBottomLeftCamera == true)
            {

                changer.isBottomCenterCamera = false;
                changer.isBottomRightCamera = false;
                changer.isPortalCamera = false;
                changer.isStairCaseCamera = false;
                changer.isLeftCloudCamera = false;
                changer.isRightCloudCamera = false;


            }
            //Camera.transform.eulerAngles = new Vector3(Camera.transform.eulerAngles.x, Camera.transform.eulerAngles.y + 90f, Camera.transform.eulerAngles.z);
            //Camera.transform.position = new Vector3(Camera.transform.position.x - 16f, Camera.transform.position.y, Camera.transform.position.z);
        }
        if (other.gameObject == player && gameObject.tag == "BRC Trigger")
        {
            changer.isBottomRightCamera = true;


            if (changer.isBottomRightCamera == true)
            {
                changer.isBottomLeftCamera = false;
                changer.isBottomCenterCamera = false;
                changer.isPortalCamera = false;
                changer.isStairCaseCamera = false;
                changer.isLeftCloudCamera = false;
                changer.isRightCloudCamera = false;


            }
            //Camera.transform.eulerAngles = new Vector3(Camera.transform.eulerAngles.x, Camera.transform.eulerAngles.y + 90f, Camera.transform.eulerAngles.z);
            //Camera.transform.position = new Vector3(Camera.transform.position.x - 16f, Camera.transform.position.y, Camera.transform.position.z);
        }
        if (other.gameObject == player && gameObject.tag == "P Trigger")
        {
            changer.isPortalCamera = true;
            pMover.startPosition = pMover.transform.position;
            pMover.zOffset = -5;

            if (changer.isPortalCamera == true)
            {
                changer.isBottomLeftCamera = false;
                changer.isBottomRightCamera = false;
                changer.isBottomCenterCamera = false;
                changer.isStairCaseCamera = false;
                changer.isLeftCloudCamera = false;
                changer.isRightCloudCamera = false;


            }
            //Camera.transform.eulerAngles = new Vector3(Camera.transform.eulerAngles.x, Camera.transform.eulerAngles.y + 90f, Camera.transform.eulerAngles.z);
            //Camera.transform.position = new Vector3(Camera.transform.position.x - 16f, Camera.transform.position.y, Camera.transform.position.z);
        }
        if (other.gameObject == player && gameObject.tag == "SC Trigger")
        {
            changer.isStairCaseCamera = true;
            scMover.startPosition = scMover.transform.position;
            scMover.zOffset = -8;

            if (changer.isStairCaseCamera == true)
            {
                changer.isBottomLeftCamera = false;
                changer.isBottomRightCamera = false;
                changer.isPortalCamera = false;
                changer.isBottomCenterCamera = false;
                changer.isLeftCloudCamera = false;
                changer.isRightCloudCamera = false;


            }
            //Camera.transform.eulerAngles = new Vector3(Camera.transform.eulerAngles.x, Camera.transform.eulerAngles.y + 90f, Camera.transform.eulerAngles.z);
            //Camera.transform.position = new Vector3(Camera.transform.position.x - 16f, Camera.transform.position.y, Camera.transform.position.z);
        }
        if (other.gameObject == player && gameObject.tag == "LC Trigger")
        {
            changer.isLeftCloudCamera = true;


            if (changer.isLeftCloudCamera == true)
            {
                changer.isBottomLeftCamera = false;
                changer.isBottomRightCamera = false;
                changer.isPortalCamera = false;
                changer.isStairCaseCamera = false;
                changer.isBottomCenterCamera = false;
                changer.isRightCloudCamera = false;


            }
            //Camera.transform.eulerAngles = new Vector3(Camera.transform.eulerAngles.x, Camera.transform.eulerAngles.y + 90f, Camera.transform.eulerAngles.z);
            //Camera.transform.position = new Vector3(Camera.transform.position.x - 16f, Camera.transform.position.y, Camera.transform.position.z);
        }
        if (other.gameObject == player && gameObject.tag == "RC Trigger")
        {
            changer.isRightCloudCamera = true;


            if (changer.isRightCloudCamera == true)
            {
                changer.isBottomLeftCamera = false;
                changer.isBottomRightCamera = false;
                changer.isPortalCamera = false;
                changer.isStairCaseCamera = false;
                changer.isLeftCloudCamera = false;
                changer.isBottomCenterCamera = false;

            }
            //Camera.transform.eulerAngles = new Vector3(Camera.transform.eulerAngles.x, Camera.transform.eulerAngles.y + 90f, Camera.transform.eulerAngles.z);
            //Camera.transform.position = new Vector3(Camera.transform.position.x - 16f, Camera.transform.position.y, Camera.transform.position.z);
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player && gameObject.tag == "BCC Trigger")
        {
            changer.isBottomCenterCamera = false;
        }
        if (other.gameObject == player && gameObject.tag == "BLC Trigger")
        {
            changer.isBottomLeftCamera = false;
        }
        if (other.gameObject == player && gameObject.tag == "BRC Trigger")
        {
            changer.isBottomRightCamera = false;
        }
        if (other.gameObject == player && gameObject.tag == "P Trigger")
        {
            changer.isPortalCamera = false;
            changer.isStairCaseCamera = false;
            pMover.transform.position = pMover.startPosition;
        }
        if (other.gameObject == player && gameObject.tag == "SC Trigger")
        {
            changer.isStairCaseCamera = false;
            scMover.transform.position = scMover.startPosition;
            }
        if (other.gameObject == player && gameObject.tag == "LC Trigger")
        {
            changer.isLeftCloudCamera = false;
        }
        if (other.gameObject == player && gameObject.tag == "RC Trigger")
        {
            changer.isRightCloudCamera = false;
        }

    }
}
