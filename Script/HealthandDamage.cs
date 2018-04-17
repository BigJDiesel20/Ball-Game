using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthandDamage : MonoBehaviour {
    public float curhealth;
    public float curhealthRounded;
    public float maxHealth;
    public float healing;
    public float damage;
    public float ratio;
    public Image HealthBar;
    public Image HealthBar2;
    public RectTransform healthbarScale;
    public Text healthText;
    public RawImage gameOver;
    public AudioSource audio;
    public AudioClip deathAudio;
    public bool death;
    private bool isdone;
    public WinScript winScript;
    public GameObject spikeball;
    public int lives;
    public Text lifeCount;
    public GameObject[] buckeyballMeshes;


    //Hazzard Objects
    public GameObject[] spikeBall;
    public GameObject[] walls;
    public FireTrigger fireTrigger;


    //public GameObject otherGameObject;
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
        healthbarScale = HealthBar.GetComponent<RectTransform>();
        curhealth = 100f;
        maxHealth = 100f;
        death = false;
        lives = 3;

 
	}
	
	// Update is called once per frame
	void Update () {
        if (death == true && isdone == false)
        {
            curhealth = 0f;
            gameOver.enabled = true;
            audio.clip = deathAudio;
            audio.Play();
            GameObject.FindGameObjectWithTag("Spikeballs").SetActive(false);
            GameObject.FindGameObjectWithTag("Moving Walls").SetActive(false);
            GameObject.FindGameObjectWithTag("Bomb Spawn").SetActive(false);
            StartCoroutine(winScript.RestartTextFlashDeath ());
            isdone = true;
        }
        if (death == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Minigame");
            }
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (death != true)
        {
            if (other.gameObject.tag == "Collectable")
            {            
                healing = 15f;
                Healing();
            }

            if (other.gameObject.tag == "BombTrigger")
            {
                damage = 30f;
                Damage();
            }

            if (other.gameObject.tag == "Fire")
            {
                damage = 6f;
            }
            if (other.gameObject.tag == "Barbwire")
            {
                damage = 20f;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (death != true)
        {
            if (collision.gameObject == spikeBall[0] || collision.gameObject == spikeBall[1] || collision.gameObject == spikeBall[2] || collision.gameObject == spikeBall[3])
            {
                damage = 20f;
                Damage();
            }

            if (collision.gameObject.tag == "Smasher")
            {
                damage = 25f;
                Damage();

            }

            if (collision.gameObject == walls[0] || collision.gameObject == walls[1] || collision.gameObject == walls[2] || collision.gameObject == walls[3])
            {
                damage = 5f;
                Damage();
            }
        }            
    }

     public void Damage()
        {
        curhealth = curhealth - damage ;
        MinMaxValue();
        ratio = curhealth / maxHealth;
        curhealthRounded = Mathf.Round(curhealth);
        healthText.text = curhealthRounded.ToString()+"%";
        healthbarScale.localScale = new Vector3(ratio,healthbarScale.localScale.y,healthbarScale.localScale.z);
        StartCoroutine(Flashing());
        }
     public void Healing()
        {
        curhealth =  curhealth + healing ;
        MinMaxValue();
        ratio = curhealth / maxHealth;
        curhealthRounded = Mathf.Round(curhealth);
        healthText.text = curhealthRounded.ToString()+"%";
        healthbarScale.localScale = new Vector3(ratio,healthbarScale.localScale.y,healthbarScale.localScale.z);
        }


    public void MinMaxValue()
    {
        if (curhealth <= 0f)
        {   
            curhealth = 0f;

            switch (lives)
            {
                case 1:
                    transform.position = ClosestSpawnLocation (SpawnScript.spawnlocations);
                    curhealth = 100f;
                    lifeCount.text = "x0";
                    break;
                case 2:
                    transform.position = ClosestSpawnLocation (SpawnScript.spawnlocations);
                    curhealth = 100f;
                    lifeCount.text = "x1";
                    break;
                case 3:                    
                    transform.position = ClosestSpawnLocation (SpawnScript.spawnlocations);
                    curhealth = 100f;
                    lifeCount.text = "x2";
                    break;
                default:
                    death = true;
                    break;
            }
            if (death != true)
            {
                StartCoroutine(Flashing());
            }
            lives -= 1;


        }
        if (curhealth >= maxHealth)
        {
            curhealth = 100f;
        }
    }

    public IEnumerator Flashing ()
    { 
        for (int i = 0; i < 20; i++)
        {
            foreach (GameObject buckeyballMesh in buckeyballMeshes)
            {
                buckeyballMesh.GetComponent<Renderer>().enabled = false;

            }
            yield return new WaitForSeconds(.05f);
            foreach (GameObject buckeyballMesh in buckeyballMeshes)
            {
                buckeyballMesh.GetComponent<Renderer>().enabled = true;

            }
            yield return new WaitForSeconds(.05f);
        }
    }

    Vector3 ClosestSpawnLocation (List<SpawnScript> _spawnlocations)
    {
        SpawnScript bestLocation = null;
        float closestLocation = Mathf.Infinity;

        foreach (SpawnScript _spawnlocation in _spawnlocations)
        {
            Vector3 directionSqr = _spawnlocation.transform.position - transform.position;
            float distancesqr = directionSqr.sqrMagnitude;

            if (distancesqr < closestLocation)
            {
                closestLocation = distancesqr;
                bestLocation = _spawnlocation;               
            }
        }
        return bestLocation.transform.position;
    }



    //GameObject.FindGameObjectWithTag("Spikeballs").SetActive(false);
    //GameObject.FindGameObjectWithTag("Spikeballs").SetActive(false);
    //FireSpawn[0].SetActive(false);
    //FireSpawn[2].SetActive(false);
    //GameObject.FindGameObjectWithTag("Player").SetActive(false);
}
