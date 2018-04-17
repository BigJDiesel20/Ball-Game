using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    private bool reached;


    // Use this for initialization
	void Start () {
        StartCoroutine(CanvasMover());

	}
	
	// Update is called once per frame
	void Update () {
        
        
	}
    IEnumerator CanvasMover () {
        
        while (true)
        {
            transform.localPosition = transform.localPosition + new Vector3(0, 5, 0) * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

}
