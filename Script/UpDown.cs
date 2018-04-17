using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour {
    private Vector3 yaxis;
    private Vector3 a;
    private Vector3 b;

    public float ystart;
    public float yend;
    public AudioSource audioSource;
    public AudioClip movingWall;
    public AudioClip StopingWall;
    public bool hasPlayed;





    // Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        yaxis.y = 2.53f;
        if (gameObject.tag == ("StartUp"))
        {
            StartCoroutine(DownUp());
        }
        if (gameObject.tag == ("StartDown"))
        {
            StartCoroutine(UpandDown());
        }
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    IEnumerator DownUp()
    {
        bool isTrue = true;
        while (true)
        {
            audioSource.Stop();
            audioSource.clip = movingWall;
            audioSource.Play();
            while (isTrue)
            {                
                a = new Vector3(0f, 2.51f, 0f) * Time.deltaTime;

                transform.position = transform.position - a;

                if (transform.position.y <= -yaxis.y)
                {
                    audioSource.Stop();
                    audioSource.clip = StopingWall;
                    audioSource.Play();
                    Vector3 transpo = transform.position;
                    transpo.y = -2.51f;
                    transform.position = transpo;
                    isTrue = false;
                }
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForSeconds(1);
            audioSource.Stop();
            audioSource.clip = movingWall;
            audioSource.Play();
            while (isTrue == false)
            {
                a = new Vector3(0f, 2.51f, 0f) * Time.deltaTime;
                transform.position = transform.position + a;
                if (transform.position.y >= 0)
                {
                    audioSource.Stop();
                    audioSource.clip = StopingWall;
                    audioSource.Play();
                    Vector3 transpo = transform.position;
                    transpo.y = 0f;
                    transform.position = transpo;
                    isTrue = true;
                }
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForSeconds(1);
        }
    }
    IEnumerator UpandDown()
    {
        bool isTrue = false;
        while (true)
        {
            audioSource.Stop();
            audioSource.clip = movingWall;
            audioSource.Play();
            while (isTrue == false)
            {
                a = new Vector3(0f, 251f, 0f) * Time.deltaTime;
                b.y = Mathf.Round(a.y);                
                transform.position = transform.position + b / 100;
                if (transform.position.y >= 0)
                {
                    audioSource.Stop();
                    audioSource.clip = StopingWall;
                    audioSource.Play();
                    Vector3 transpo = transform.position;
                    transpo.y = 0f;
                    transform.position = transpo;
                    isTrue = true;
                }
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForSeconds(1);
            audioSource.Stop();
            audioSource.clip = movingWall;
            audioSource.Play();
            while (isTrue)
            {
                a = new Vector3(0f, 251f, 0f) * Time.deltaTime;
                b.y = Mathf.Round(a.y);                
                transform.position = transform.position - b / 100;
                if (transform.position.y <= -yaxis.y)
                {
                    audioSource.Stop();
                    audioSource.clip = StopingWall;
                    audioSource.Play();
                    Vector3 transpo = transform.position;
                    transpo.y = -2.51f;
                    transform.position = transpo;
                    isTrue = false;
                }
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForSeconds(1);
        }
            
    }

}
