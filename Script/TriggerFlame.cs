using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFlame : MonoBehaviour {
    public GameObject campfire;
    public GameObject smallfire;
    public GameObject clonecampfire;
    public GameObject clonesmallfire;
    public GameObject FireTrigger;
    public FireTrigger fireTrigger;
    public FireDamage fireDamage;
    public bool isTriggered;

	// Use this for initialization
	void Start () {
        isTriggered = false;
    }
	
	// Update is called once per frame
	void Update () {

        isTriggered = fireTrigger.isTriggered;

        if (isTriggered == true)
        {
            if (fireTrigger.isTriggered == true)
            {
                fireTrigger.isTriggered = false;
            }
            else
            {
                isTriggered = false;
            }
            if (clonecampfire == null && clonesmallfire == null)
            {
                StartCoroutine(OnFire());
            }
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == FireTrigger)
        {
            StartCoroutine(OnFire());
            
        }
    }

    public IEnumerator OnFire()
    {        
        clonecampfire = Instantiate(campfire, transform.position, Quaternion.identity);
        clonesmallfire = Instantiate(smallfire, transform.position, Quaternion.identity);
        clonecampfire.transform.parent = gameObject.transform;
        clonesmallfire.transform.parent = gameObject.transform;
        fireDamage.enabled = true;
        yield return new WaitForSeconds(5);
        fireDamage.enabled = false;
        clonecampfire.transform.parent = null;
        clonesmallfire.transform.parent = null;
        yield return new WaitForSeconds(5);
        Destroy(clonecampfire);
        Destroy(clonesmallfire);
        
    }
}
