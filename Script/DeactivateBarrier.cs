using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateBarrier : MonoBehaviour {
    public GameObject Player;
    public GameObject magicRing;
    private GameObject clonemagicRing;
    public PlayerController Playerscript;
    public bool isexicuted;


	// Use this for initialization
	void Start () {
        Playerscript = Player.GetComponent<PlayerController>();
        isexicuted = false;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Playerscript.displayCount == 33 && isexicuted == false)
        {
            isexicuted = true;
            clonemagicRing = Instantiate(magicRing,new Vector3(-16.78f,3.131201f,23.8f), Quaternion.Euler(-90f,0f,0f));
            StartCoroutine(BarrierOff());
        }
	}
    IEnumerator BarrierOff()
    {
        yield return new WaitForSeconds(3);
        Destroy(clonemagicRing);
        gameObject.SetActive(false);
    }
}
