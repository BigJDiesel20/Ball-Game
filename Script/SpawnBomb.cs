using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBomb : MonoBehaviour {

    public GameObject bomb;
    public GameObject portal;
    public Vector3 spawnPositions;
    public float zPlus;

	// Use this for initialization
	void Start () {
        zPlus = 20.16f;
        spawnPositions = transform.position;
        StartCoroutine(SpawnLoop());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            for (int i = 1; i < 9; i++)
            {
                GameObject clone = Instantiate(portal, new Vector3(spawnPositions.x, spawnPositions.y, zPlus), Quaternion.Euler(90f,0f,0f));
                Instantiate(bomb, new Vector3(spawnPositions.x, spawnPositions.y, zPlus), Quaternion.identity);
                if (i < 8)
                {
                    zPlus = zPlus - 5.36f;
                }
                else
                {
                    zPlus = zPlus;
                }
                Destroy(clone, 1f);
                yield return new WaitForSeconds(2);
            }
            yield return new WaitForSeconds(3);
            for (int i = 1; i < 9; i++)
            {
                GameObject clone = Instantiate(portal, new Vector3(spawnPositions.x, spawnPositions.y, zPlus), Quaternion.Euler(90f,0f,0f));
                Instantiate(bomb, new Vector3(spawnPositions.x, spawnPositions.y, zPlus), Quaternion.identity);
                if (i < 8)
                {
                    zPlus = zPlus + 5.36f;
                }
                else
                {
                    zPlus = zPlus;
                }
                Destroy(clone, 1f);
                yield return new WaitForSeconds(2);
            }
        }
    }
}
