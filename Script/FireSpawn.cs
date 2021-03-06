using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawn : MonoBehaviour {

    public GameObject flameThrower;
    public GameObject flamethrowerSpawn;
    public GameObject cloneFlame;
    public GameObject flameWall;
    public GameObject flamewallSpawn;
    public GameObject cloneflameWall;
    public GameObject fireTrigger;
    public AudioSource flameSound;
    public float angleY;
    public float v;
    public bool isreset;
    public HealthandDamage healthandDamage;

	// Use this for initialization
	void Start () {
        healthandDamage = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthandDamage>();
        isreset = false;
        v = 1f;
        if (fireTrigger != null)
        {
            fireTrigger.SetActive(false);
        }
        StartCoroutine(FlameTimer());
	}
	
	// Update is called once per frame
	void Update () {
		if (cloneflameWall != null)
        {
            if (flameSound == null)
            {
                flameSound = cloneflameWall.GetComponentInChildren<AudioSource>();
            }
            cloneflameWall.transform.Translate(0, -.01f, 0);
        }

          

        if (cloneflameWall != null)
        {    
            if (isreset == true)
            {
                v = 1f;
                flameSound.volume = v;
                isreset = false;
            }  
            if (v >= .1f)
            {
                v = v - .003f;
                flameSound.volume = v;
            }
            else
            {
                v = 0;
                flameSound.volume = v;
            }

        }
        if (healthandDamage.death == true)
        {
            Destroy(cloneflameWall);
            gameObject.SetActive(false);
        }



    }

    IEnumerator FlameTimer()
    {
        while (true)
        {
            if (gameObject.tag == "Dragon 1")
            {
                angleY = -90f;
            }
            else if (gameObject.tag == "Dragon 2")
            {
                angleY = 90f;
            }

            cloneFlame = Instantiate(flameThrower, flamethrowerSpawn.transform.position, Quaternion.Euler(20f, angleY, 0f));
            if (cloneflameWall == null)
            {
                cloneflameWall = Instantiate(flameWall, flamewallSpawn.transform.position, Quaternion.identity);
            }
            else
            {
                cloneflameWall.transform.position = flamewallSpawn.transform.position;
            }
            if (fireTrigger != null)
            {
                fireTrigger.SetActive(true);
            }
            if (flameSound != null)
            {
                flameSound.volume = 1f; 
            }
            Destroy(cloneFlame, 5f);
            isreset = true;

                
            yield return new WaitForSeconds(7);
            if (fireTrigger != null)
            {
                fireTrigger.SetActive(false);
            }
            yield return new WaitForSeconds(3);
        }

    }



}
