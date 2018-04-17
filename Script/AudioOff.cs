using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOff : MonoBehaviour {
    private AudioSource audioSource;
    public WinScript winScript;
    public HealthandDamage healthandDamage;
    private bool isDone;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        isDone = false;
	}
	
	// Update is called once per frame
	void Update () {
        

        if (winScript.isWon == true && isDone == false)
        {
            audioSource.Stop();
            isDone = true;
        }

        if (healthandDamage.death == true && isDone == false)
        {
            audioSource.Stop();
            isDone = true;
        }
    }
}
		
	
   