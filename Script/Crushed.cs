using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crushed : MonoBehaviour {
    public Rigidbody rb;
    public bool crushed;
    private AudioSource audioSource;
    public AudioClip Pop;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        crushed = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (crushed == true)
        StartCoroutine(ReturntoShape());
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Smasher")
        {
            rb.isKinematic = true;
            transform.rotation = Quaternion.identity;
            transform.localScale = new Vector3(transform.localScale.x, .1f, transform.localScale.z);
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
            crushed = true;
        }
    } 

    IEnumerator ReturntoShape()
    {
        crushed = false;
        yield return new WaitForSeconds(2);
        rb.isKinematic = false;
        Vector3 scaleReturn = new Vector3(transform.localScale.x, 1f, transform.localScale.z);
        float scalesnapBack = scaleReturn.y - .1f;
        Vector3 positionReturn = new Vector3(transform.position.x, .5f, transform.position.z);
        float positionsnapBack = positionReturn.y - .01f;
        while (transform.localScale.y != scaleReturn.y)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, scaleReturn, .1f * Time.deltaTime);
            if (transform.localScale.y > scalesnapBack)                
            {
                audioSource.PlayOneShot(Pop, 1f);
                transform.localScale = new Vector3(transform.localScale.x, 1f, transform.localScale.z);
                Debug.Log("exicuted");
                Debug.Log(transform.localScale.y);
            }
            yield return new WaitForEndOfFrame();
        }
        while (transform.position.y != positionReturn.y)
        {
            if (transform.position.y > positionReturn.y)
            {
                break;
            }
            transform.position = Vector3.Lerp(transform.position, positionReturn, .1f * Time.deltaTime);
            if (transform.position.y > positionsnapBack)
            {                
                    transform.position = new Vector3(transform.position.x, .5f, transform.position.z);
            }
            yield return new WaitForEndOfFrame();
        }
        
    }
}
