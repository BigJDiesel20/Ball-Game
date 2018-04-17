using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resting : MonoBehaviour {
    public GameObject startPosition;
    public GameObject Smasher;
    public Falling falling;
    public float yresetPoint;
    public bool isWaiting;
    public bool inprocess;
    public AudioSource audioSource;
    public AudioClip resetingClip;
    private bool isPlaying;
    // Use this for initialization
    void Start () {
        isWaiting = true;
        inprocess = false;
        isPlaying = false;
        falling = Smasher.GetComponent<Falling>();
        yresetPoint = startPosition.transform.position.y - .15f;
        audioSource = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
        if (falling.isstartPosition == false && falling.isinTrigger == false)
        {            
            if (transform.position != startPosition.transform.position)
            {   
                if (isPlaying == false)
                {
                    audioSource.clip = resetingClip;
                    audioSource.Play();
                    isPlaying = true;
                }
                transform.position = Vector3.Lerp(transform.position, startPosition.transform.position, 1 * Time.deltaTime);
                if (transform.position.y > yresetPoint)
                {
                    transform.position = startPosition.transform.position;
                    gameObject.GetComponent<BoxCollider>().enabled = true;
                    audioSource.Stop();
                    isPlaying = false;
                }
            }
        }
        if (falling.isstartPosition == true && falling.isinTrigger == false)
        {
            
            if (transform.position != startPosition.transform.position)
            {
                if (isPlaying == false)
                {
                    audioSource.clip = resetingClip;
                    audioSource.Play();
                    isPlaying = true;
                }
                transform.position = Vector3.Lerp(transform.position, startPosition.transform.position, 1 * Time.deltaTime);
                if (transform.position.y > yresetPoint)
                {
                    transform.position = startPosition.transform.position;
                    gameObject.GetComponent<BoxCollider>().enabled = true;
                    audioSource.Stop();
                    isPlaying = false;
                }
            }
        }
        if (falling.isstartPosition == false && falling.isinTrigger == true && transform.position.y > 2)
        {            
            if (transform.position != startPosition.transform.position)
            {
                if (isPlaying == false)
                {
                    audioSource.clip = resetingClip;
                    audioSource.Play();
                    isPlaying = true;
                }
                transform.position = Vector3.Lerp(transform.position, startPosition.transform.position, 1 * Time.deltaTime);
                if (transform.position.y > yresetPoint)
                {
                    transform.position = startPosition.transform.position;
                    gameObject.GetComponent<BoxCollider>().enabled = true;
                    audioSource.Stop();
                    isPlaying = false;
                }
            }
        }

    }
    


    
}
