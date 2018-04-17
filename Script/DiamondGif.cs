using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiamondGif : MonoBehaviour {
    public Texture[] textures;
    public RawImage rawImage;

	// Use this for initialization
    IEnumerator Start () {
        rawImage = GetComponent<RawImage>();
        while (true)
        {
            foreach (Texture texture in textures)
            {                
                rawImage.texture = texture;
                yield return new WaitForSeconds(.01f);
            }
        }

        //StartCoroutine( Gif());

	}
	
	// Update is called once per frame
	void Update () {
		
	}



}
