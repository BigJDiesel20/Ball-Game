using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {
    public GameObject exitPortal;
    public GameObject childGameObject;
    public GameObject spawnPos;
    public GameObject Player;
    private GameObject newProtal;
    public Rigidbody rb;

    //
    //private float z;
    private float playerZ;
    private float playerX;
    private float driftx;
    private float drifty;
    private float driftz;
    // Use this for initialization
    void Start () {
        complete = false;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 0, -500) * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Player = collision.gameObject;
        //z = 1;
        playerZ = Player.transform.position.z + 1f;
        playerX = Player.transform.position.x - 1f;
        if (Player.transform.position.x < childGameObject.transform.position.x)
        {
            driftx = 1f;
        }
        else
        {
            driftx = -1f;
        }
        if (Player.transform.position.y < childGameObject.transform.position.y)
        {
            drifty = 1f;
        }
        else
        {
            drifty = -1f;
        }
        if (Player.transform.position.z < childGameObject.transform.position.z)
        {
            driftz = 1f;
        }
        else
        {
            driftz = -1f;
        }
        StartCoroutine(Teleport());
    }
    public bool complete;
    public bool isComplete()
    {
        if (complete == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    IEnumerator Teleport()
    {
        if (Player.tag == "Player")
        {
            complete = false;
            rb = Player.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            if (gameObject.tag == "Portal 1")
            {
                while (Player.transform.position.z <= playerZ)
                {                
                    Player.transform.position += new Vector3(driftx * Time.deltaTime, drifty * Time.deltaTime, 1f * Time.deltaTime);
                    yield return new WaitForEndOfFrame();
                    if (Player.transform.position.z >= playerZ)
                    {
                        complete = true;
                    }
                }
            }
            if (gameObject.tag == "Portal 2")
            {
                while (Player.transform.position.x >= playerX)
                {
                    Player.transform.position -= new Vector3(1f * Time.deltaTime, -drifty * Time.deltaTime, driftz * Time.deltaTime);
                    yield return new WaitForEndOfFrame();
                    if (Player.transform.position.x <= playerX)
                    {
                        complete = true;
                    }
                }
            }
            yield return new WaitUntil(isComplete);
            if (gameObject.tag == "Portal 1")
            {
                complete = false;
                //Player.SetActive(false);
                Player.transform.position = new Vector3(spawnPos.transform.position.x, spawnPos.transform.position.y - 1f, spawnPos.transform.position.z);
                newProtal = Instantiate(exitPortal, new Vector3(-10.21f, 22.13f, -11.57f), Quaternion.Euler(90, 0, 0));
                float c = Player.transform.position.y + 1f;

                while (Player.transform.position.y <= c)
                {
                    Player.transform.position += new Vector3(0, 1f * Time.deltaTime, 0);
                    yield return new WaitForEndOfFrame();
                    if (Player.transform.position.y >= c)
                    {
                        complete = true;
                    }
                }
            }
            
            if (gameObject.tag == "Portal 2")
            {
                complete = false;
                //Player.SetActive(false);
                Player.transform.position = new Vector3(spawnPos.transform.position.x, spawnPos.transform.position.y, spawnPos.transform.position.z);
                newProtal = Instantiate(exitPortal, new Vector3(0f, .5f, 0f), Quaternion.Euler(90, 0, 0));
                float c = Player.transform.position.y + 1f;
                while (Player.transform.position.y <= c)
                {
                    Player.transform.position += new Vector3(0, 1f * Time.deltaTime, 0);
                    yield return new WaitForEndOfFrame();
                    if (Player.transform.position.y >= c)
                    {
                        complete = true;
                    }
                }
            }
            yield return new WaitForSeconds(1f);
            yield return new WaitUntil(isComplete);
            Destroy(newProtal);
            complete = false;
            rb.isKinematic = false;
            //Player.SetActive(true);

        }
    }
}
