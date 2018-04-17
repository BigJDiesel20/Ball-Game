using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {
    public GameObject camPos1;
    public GameObject camPos2;
    public GameObject bottomcenterCam;
    public GameObject bottomleftCam;
    public GameObject bottomrightCam;
    public GameObject portalCam;
    public GameObject staircaseCam;
    public GameObject leftcloudCam;
    public GameObject rightcloudCam;
    public GameObject camLocation;
    public GameObject Smasher1Cam;
    public GameObject WinCamera;
    public CameraChanger changer;
    public Quaternion newRotation;
    public float rate;
    public WinScript winScript;

    // Use this for initialization
    void Start () {
        camPos1 = GameObject.FindGameObjectWithTag("Camera Location 1");
        camPos2 = GameObject.FindGameObjectWithTag("Camera Location 2");






        if (changer.isBottomCenterCamera == true)
        {
            //Debug.Log("change true");
            camLocation = camPos2;
            newRotation = Quaternion.Euler(90f, 90f, 0f);
            rate = 2f;
        }
        else
        {
            //Debug.Log("change false");
            camLocation = camPos1;
            newRotation = Quaternion.Euler(25f, 0.0f, 0.0f);
            rate = 2f;
        }
        transform.position = camLocation.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (winScript.isWon == true)
        {
            camLocation = WinCamera;
            newRotation = Quaternion.Euler(25f, 0.0f, 0.0f);
            rate = 2f;
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, rate * Time.deltaTime);
        }
        else if (changer.isBottomCenterCamera == true)
        {
            //Debug.Log("change true");
            camLocation = camPos2;
            newRotation = Quaternion.Euler(90f, 90f, 0f);
            rate = 2f;
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, rate * Time.deltaTime);
        }
        else if (changer.isBottomLeftCamera == true)
        {
            //Debug.Log("BL true");
            camLocation = bottomleftCam;
            newRotation = Quaternion.Euler(25f, -180f, 0.0f);
            rate = 4f;
            GameObject Player = GameObject.FindGameObjectWithTag("Player");
            Vector3 realitivePos = Player.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(realitivePos);
        }
        else if (changer.isBottomRightCamera == true)
        {
            //Debug.Log("BR true");
            camLocation = bottomrightCam;
            newRotation = Quaternion.Euler(25f, 180f, 0.0f);
            rate = 2f;
            GameObject Player = GameObject.FindGameObjectWithTag("Player");
            Vector3 realitivePos = Player.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(realitivePos);
        }
        else if (changer.isPortalCamera == true)
        {
            //Debug.Log("P true");
            camLocation = portalCam;
            newRotation = Quaternion.Euler(25f, 0f, 0.0f);
            rate = 2f;
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, rate * Time.deltaTime);
        }
        else if (changer.isStairCaseCamera == true)
        {
            //Debug.Log("SC true");
            camLocation = staircaseCam;
            newRotation = Quaternion.Euler(25f, 0f, 0.0f);
            rate = 2f;
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, rate * Time.deltaTime);
        }
        else if (changer.isRightCloudCamera == true)
        {
            //Debug.Log("RC true");
            camLocation = rightcloudCam;
            newRotation = Quaternion.Euler(25f, -90f, 0.0f);
            rate = 2f;
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, rate * Time.deltaTime);
        }
        else if (changer.isLeftCloudCamera == true)
        {
            //Debug.Log("LC true");
            camLocation = leftcloudCam;
            newRotation = Quaternion.Euler(25f, -45f, 0.0f);
            rate = 2f;
            GameObject Player = GameObject.FindGameObjectWithTag("Player");
            Vector3 realitivePos = Player.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(realitivePos);
        }
        else if (changer.isSmasher == true)
        {
            camLocation = Smasher1Cam;
            newRotation = Quaternion.Euler(25f, 0.0f, 0.0f);
            rate = 2f;
            GameObject Player = GameObject.FindGameObjectWithTag("Player");
            Vector3 realitivePos = Player.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(realitivePos);
        }
        else
        {
            //Debug.Log("camPos1");
            camLocation = camPos1;
            newRotation = Quaternion.Euler(25f, 0.0f, 0.0f);
            rate = 2f;
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, rate * Time.deltaTime);
        }
        transform.position = Vector3.Lerp(transform.position, camLocation.transform.position, 2f * Time.deltaTime);
        //GameObject Player = GameObject.FindGameObjectWithTag("Player");
        //Vector3 realitivePos = Player.transform.position - transform.position;
        //transform.rotation = Quaternion.LookRotation(realitivePos);
        //transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, rate * Time.deltaTime);
        //transform.position = camLocation.transform.position;
	}
}
