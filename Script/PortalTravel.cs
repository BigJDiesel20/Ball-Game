using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTravel : MonoBehaviour
{
    public GameObject player;
    public Rigidbody rb;
    public GameObject endLocation;
    public GameObject teleportLocation;
    public GameObject exitPortal;
    public GameObject newPortal;
    public CameraChanger changer;
    public float tp;
    public float zsnapBack;
    public float xsnapBack;
    public bool enter;
    public bool exit;

    // Use this for initialization
    void Start()
    {
        zsnapBack = endLocation.transform.position.z - .1f;
        xsnapBack = endLocation.transform.position.x + .3f;
        rb = player.GetComponent<Rigidbody>();
        tp = teleportLocation.transform.position.y - 1f;
        enter = false;
        exit = false;


    }

    // Update is called once per frame
    void Update()
    {        
        transform.Rotate(new Vector3(0, 0, -500) * Time.deltaTime);

        if (gameObject.transform.parent.tag == "Portal 1")
        {

            if (enter == true)
            {
                EnterancePortal1();
            }
            if (exit == true)
            {
                ExitPoral1();
            }
        }

        if (gameObject.transform.parent.tag == "Portal 2")
        {

            if (enter == true)
            {
                EnterancePortal2();
            }
            if (exit == true)
            {
                ExitPoral2();
            }
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.isKinematic = true;
            enter = true;
            
        }
    }

    void EnterancePortal1()
    {
        player.transform.position = Vector3.Lerp(player.transform.position, endLocation.transform.position, 1 * Time.deltaTime);
        if (player.transform.position.z > zsnapBack)
        {
            player.transform.position = new Vector3(teleportLocation.transform.position.x, tp, teleportLocation.transform.position.z);
            enter = false;
            exit = true;
            changer.isPortalCamera = false;
            changer.isRightCloudCamera = true;
            newPortal = Instantiate(exitPortal, new Vector3(teleportLocation.transform.position.x, 22.13f, teleportLocation.transform.position.z), Quaternion.Euler(90f, 0f, 0f));

        }
    }

    void ExitPoral1()
    {
        player.transform.position = Vector3.Lerp(player.transform.position, teleportLocation.transform.position, 1 * Time.deltaTime);
        if (player.transform.position.y > teleportLocation.transform.position.y - .1f)
        {
            player.transform.position = teleportLocation.transform.position; ;
            exit = false;


            Destroy(newPortal,1);
            rb.isKinematic = false;
        }
    }

    void EnterancePortal2()
    {
        player.transform.position = Vector3.Lerp(player.transform.position, endLocation.transform.position, 1 * Time.deltaTime);
        if (player.transform.position.x < xsnapBack)
        {
            player.transform.position = new Vector3(teleportLocation.transform.position.x, tp, teleportLocation.transform.position.z);
            enter = false;
            exit = true;
            newPortal = Instantiate(exitPortal, new Vector3(teleportLocation.transform.position.x, .1f, teleportLocation.transform.position.z), Quaternion.Euler(90f, 0f, 0f));

        }
    }

    void ExitPoral2()
    {
        player.transform.position = Vector3.Lerp(player.transform.position, teleportLocation.transform.position + new Vector3(0f,.5f,0), 1 * Time.deltaTime);
        if (player.transform.position.y > .4)
        {
            player.transform.position = teleportLocation.transform.position; ;
            exit = false;
            Destroy(newPortal,1);
            rb.isKinematic = false;
        }
    }
}