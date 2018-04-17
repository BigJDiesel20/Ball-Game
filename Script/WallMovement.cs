using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour {
    public AudioSource audioSource;
    public AudioClip movingWall;
    public AudioClip StopingWall;
    public float upPos;
    public float downPos;
    public bool completed;
    public bool iscompleted()
    {
        if (completed == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        upPos = 7.49f;
        downPos = 2.42f;
        if (gameObject.tag == "StartUp")
        {
            transform.localScale = new Vector3(transform.localScale.x, upPos, transform.localScale.z);
            StartCoroutine(DownUp());
        }
        if (gameObject.tag == "StartDown")
        {
            transform.localScale = new Vector3(transform.localScale.x, downPos, transform.localScale.z);
            StartCoroutine(UpDown());
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator UpDown()
    {        
        while (true)
        {
            audioSource.Stop();
            audioSource.clip = movingWall;
            audioSource.Play();
            StartCoroutine(MoveUp());
            yield return new WaitUntil(iscompleted);
            audioSource.Stop();
            audioSource.clip = StopingWall;
            audioSource.Play();
            yield return new WaitForSeconds(1f);
            audioSource.Stop();
            audioSource.clip = movingWall;
            audioSource.Play();
            StartCoroutine(MoveDown());
            yield return new WaitUntil(iscompleted);
            audioSource.Stop();
            audioSource.clip = StopingWall;
            audioSource.Play();
            yield return new WaitForSeconds(1f);
        }
    }
    IEnumerator DownUp()
    {
        while (true)
        {
            audioSource.Stop();
            audioSource.clip = movingWall;
            audioSource.Play();
            StartCoroutine(MoveDown());

            yield return new WaitUntil(iscompleted);
            audioSource.Stop();
            audioSource.clip = StopingWall;
            audioSource.Play();
            yield return new WaitForSeconds(1f);
            audioSource.Stop();
            audioSource.clip = movingWall;
            audioSource.Play();
            StartCoroutine(MoveUp());

            yield return new WaitUntil(iscompleted);
            audioSource.Stop();
            audioSource.clip = StopingWall;
            audioSource.Play();
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator MoveDown()
    {
        while (transform.localScale.y >= 2.42)
        {
            completed = false;
            transform.localScale = transform.localScale - new Vector3(0, 5 * Time.deltaTime, 0);
            yield return new WaitForEndOfFrame();
        }
        transform.localScale = new Vector3(transform.localScale.x, 2.42f, transform.localScale.z);
        completed = true;
    }

    IEnumerator MoveUp()
    {
        while (transform.localScale.y <= 7.49f)
        {
            completed = false;
            transform.localScale = transform.localScale + new Vector3(0, 5* Time.deltaTime, 0);
            yield return new WaitForEndOfFrame();
        }
        transform.localScale = new Vector3(transform.localScale.x, 7.49f,transform.localScale.z);
        completed = true;
    }
}
