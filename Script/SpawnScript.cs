using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {
    public static List<SpawnScript> spawnlocations;

    //pulbic static spawnlocation



	// Use this for initialization


    void Start() {
        if (spawnlocations == null)
        {
            spawnlocations = new List<SpawnScript>();
        }

        spawnlocations.Add(this);


    }


}