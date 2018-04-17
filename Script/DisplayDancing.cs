using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDancing : MonoBehaviour {
    public Material[] materials;
    public Renderer rend;
	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        StartCoroutine(Animation());
	}
	
	// Update is called once per frame
	void Update () {
        

    }

    IEnumerator Animation()
    {
        while (true)
        {
            rend.sharedMaterial = materials[0];
            yield return new WaitForSeconds(.1f);
            rend.sharedMaterial = materials[1];
            yield return new WaitForSeconds(.1f);
            rend.sharedMaterial = materials[2];
            yield return new WaitForSeconds(.1f);
            rend.sharedMaterial = materials[3];
            yield return new WaitForSeconds(.1f);
            rend.sharedMaterial = materials[4];
            yield return new WaitForSeconds(.1f);
            rend.sharedMaterial = materials[5];
            yield return new WaitForSeconds(.1f);
            rend.sharedMaterial = materials[6];
            yield return new WaitForSeconds(.1f);
            rend.sharedMaterial = materials[7];
            yield return new WaitForSeconds(.1f);
            rend.sharedMaterial = materials[8];
            yield return new WaitForSeconds(.1f);
            rend.sharedMaterial = materials[9];
            yield return new WaitForSeconds(.1f);
            rend.sharedMaterial = materials[10];
            yield return new WaitForSeconds(.1f);
            rend.sharedMaterial = materials[11];
            yield return new WaitForSeconds(.1f);
            rend.sharedMaterial = materials[12];
            yield return new WaitForSeconds(.1f);
            rend.sharedMaterial = materials[13];
            yield return new WaitForSeconds(.1f);
            rend.sharedMaterial = materials[14];
            yield return new WaitForSeconds(.1f);
            rend.sharedMaterial = materials[15];
            yield return new WaitForSeconds(.1f);
        }


    }
}
