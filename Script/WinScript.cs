using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class WinScript : MonoBehaviour {
    public Text winText;
    public AudioSource audioSource;
    public AudioClip winClip;
    public bool gameWon;
    public bool isWon;
    private char R;
    public Text restartText;
    private GameObject Player;
    private Collider otherCollider;
    private Rigidbody otherrb;
    public GameObject Dancing;
    public GameObject Location; 

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = winClip;
        winText.text = "";
        gameWon = false;
        restartText.text = "";
        R = 'R';
	}
	
	// Update is called once per frame
	void Update () {
        


        
	}

    void OnTriggerEnter(Collider other) {
        Player = other.gameObject;

        if (gameWon == true)
        {
            isWon = true;
            Instantiate(Dancing, Location.transform.position, Quaternion.identity);
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            StartCoroutine(WinTextFlash());
            StartCoroutine(RestartTextFlash ());


        }
        else if (other.gameObject.tag == "Player" && gameWon != true)
        {
            otherCollider = other;

            otherrb = otherCollider.gameObject.GetComponent<Rigidbody>();

            StartCoroutine(ReturnPlayer ());

        }
    }

    public IEnumerator WinTextFlash () {
        audioSource.Play();
        for (int i = 0; i < 20; i++)
        {
            winText.text = "You Win!!";
            yield return new WaitForSeconds(1f);
            winText.text = "";
            yield return new WaitForSeconds(1f);
        }
    }

    public IEnumerator RestartTextFlash () {
        audioSource.Play();
        for (int i = 0; i < 20; i++)
        {
            restartText.text = "Press "+R+" to Restart";
            yield return new WaitForSeconds(1f);
            restartText.text = "Press   to Restart";
            yield return new WaitForSeconds(.5f);
        }
    }

    public IEnumerator RestartTextFlashDeath () {
        for (int i = 0; i < 20; i++)
        {
            restartText.text = "Press "+R+" to Restart";
            yield return new WaitForSeconds(1f);
            restartText.text = "Press   to Restart";
            yield return new WaitForSeconds(.5f);
        }
    }
    IEnumerator ReturnPlayer () 
    {
        if (Player.transform.position != new Vector3 (-22.55f,3.37f,23.14f))
        {
            otherrb.isKinematic = true;
            switch (Mathf.FloorToInt(Random.Range(1f, 5f)))
            {
                case 1:
                    winText.text = "Cheater!";
                    break;
                case 2:
                    winText.text = "Get Back Over there!";
                    break;
                case 3:
                    winText.text = "Stop it!!";
                    break;
                default:
                    winText.text = "Cheater!";
                    break;
            }
            yield return new WaitForSeconds(1f);
            Player.transform.position = new Vector3(-22.55f, 3.37f, 23.14f);
            otherrb.isKinematic = false;
            winText.text = "";
        }


    }
}
