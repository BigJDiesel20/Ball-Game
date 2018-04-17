using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeonCollision : MonoBehaviour {
    public GameObject Explotion;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter (Collision collision)
    {
        Instantiate(Explotion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
