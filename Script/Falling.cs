using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour {
    public GameObject startPosition;
    public GameObject sparks1;
    public GameObject sparks2;
    public bool isstartPosition;
    public bool isfalling;
    public bool isinTrigger; 
    public AudioSource audioSource;
    public AudioClip anvilContactClip;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        if (transform.position.y == startPosition.transform.position.y)
        {
            isstartPosition = true;            
        }
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y == startPosition.transform.position.y)
        {
            isstartPosition = true;  
        }

        if (isstartPosition == true && isinTrigger == true)
        {
            isfalling = true;
        }
        else
        {
            isfalling = false;
        }
        

        if (isfalling == true)
        {
            transform.Translate(0, -5 * Time.deltaTime, 0);
            if (transform.position.y <= 2)
            {
                transform.position = new Vector3(transform.position.x,2,transform.position.z);
                GameObject clone1 = Instantiate(sparks1, new Vector3(transform.position.x, transform.position.y - 2f, transform.position.z), Quaternion.identity);
                GameObject clone2 = Instantiate(sparks2, new Vector3(transform.position.x, transform.position.y - 2f, transform.position.z), Quaternion.identity);
                audioSource.clip = anvilContactClip;
                audioSource.Play();
                isstartPosition = false;
                Destroy(clone1, 1f);
                Destroy(clone2, 1f);
                gameObject.GetComponent<BoxCollider>().enabled = false;
                StartCoroutine(BoolDelay());
            }
        }
	}

    IEnumerator BoolDelay()
    {
        yield return new WaitForSeconds(2);
        isinTrigger = false;
    }
}
