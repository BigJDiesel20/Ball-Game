using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnPlayer : MonoBehaviour {
    public GameObject player;
    public Rigidbody playerRB;
    private Vector3 startposition;
	// Use this for initialization
	void Start () {
        startposition = player.transform.position;
    }

	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter (Collider other) {
        
        if (other.gameObject == player)
        {
            playerRB = player.GetComponent<Rigidbody>();
            StartCoroutine(Waitreturn ());
        }
    }

    IEnumerator Waitreturn () {
        yield return new WaitForSeconds(3f);
        playerRB.isKinematic = true;
        player.transform.position = startposition;
        playerRB.isKinematic = false;

    }
}
