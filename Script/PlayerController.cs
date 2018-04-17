using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public Transform[] cameraPos;
    private Transform camera;
    private Rigidbody rb;
    private AudioSource audioSource;
    public AudioClip movementClip;
    public AudioClip collisionClip;
    public AudioClip collectibleClip;
    private Vector3 movement;
    public float speed;
    private bool playOnce;
    private bool speedIncrease;
    private bool speedDecrease;
    private bool touchGround;
    public float displayCount;
    public float displayScore;
    public Text countText;
    public Text scoreText;
    private float ratio;
    private float maxCount;
    public GameObject pointCanvas;
    public Text points;
    private Vector3 otherObject;
    //private Rigidbody otherRB;
    private GameObject cloneCanvas;
    private GameObject newcloneCanvas;
    private bool cloneAtive;
    public GameObject wintriggerObject;
    public WinScript winTrigger;
    private float countTime;
    private GameObject Collectable;
    public CameraChanger changer;
    public GameObject shine;
    private HealthandDamage healthandDamage;
    private float startTime;
    private float endTime;
     



    // Use this for initialization
    void Start () {        
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        healthandDamage = GetComponent<HealthandDamage>();
        speed = 5;
        playOnce = false;
        speedIncrease = false;
        speedDecrease = false;
        touchGround = true;
        displayCount = 0;
        displayScore = 0;
        countText.text = displayCount.ToString() + " Diamonds";
        scoreText.text = "Score: " + displayScore.ToString();
        maxCount = 33;
        wintriggerObject = GameObject.FindGameObjectWithTag("Win");
        winTrigger = wintriggerObject.GetComponent<WinScript>();




       

	}
	
	// Update is called once per frame
	void Update () {   
               
        if (movement != new Vector3 (0,0,0))
        {
            if (playOnce == false)
                //audioSource.Play(movementClip);
            playOnce = true;
        }

        else
        {

            //audioSource.Stop();
            playOnce = false;
        }
          

         
        if (displayCount == 33)
        {
            winTrigger.gameWon = true;
        }
        

	}

    void FixedUpdate () {

        if (Input.GetKeyDown(KeyCode.S))
        {
            speedIncrease = true;
            speedDecrease = false;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            speedIncrease = false;
            speedDecrease = true;
        }

        if (speedIncrease == true)
        {
            if (speed < 30)
            {
                SpeedUp();
            }
            else if (speed >= 30)
            {
                speed = 30;
                speedIncrease = false;
            }
        }

        if (speedDecrease == true)
        {
            if (speed > 5)
            {
                SpeedDown();
            }
            else if (speed <= 5)
            {
                speed = 5;
                speedDecrease = false;
            }
        }


        /////////////////////

        if (changer.isBottomCenterCamera == true)
        {
            camera = cameraPos[3];
            
            //    if (Input.GetAxis("Horizontal") == 1 || Input.GetAxis("Horizontal") == -1)
            //    {
            //        movement.z = -Input.GetAxis("Horizontal") * speed;
            //    }
            //    else
            //    {
            //        movement.z = 0;
            //    }
            //    if (Input.GetAxis("Vertical") == 1 || Input.GetAxis("Vertical") == -1)
            //    {
            //        movement.x = Input.GetAxis("Vertical") * speed;
            //    }
            //    else
            //    {
            //        movement.x = 0;
            //   }
        }
        else if (changer.isBottomLeftCamera == true)
        {
            camera = cameraPos[0];
        }
            else if (changer.isBottomRightCamera == true)
        {
            camera = cameraPos[1];
        //    if (Input.GetAxis("Horizontal") == 1 || Input.GetAxis("Horizontal") == -1)
        //    {
        //        movement.x = -Input.GetAxis("Horizontal") * speed;
        //    }
        //    else
        //    {
        //        movement.x = 0;
        //    }
        //    if (Input.GetAxis("Vertical") == 1 || Input.GetAxis("Vertical") == -1)
        //    {
        //        movement.z = -Input.GetAxis("Vertical") * speed;
        //    }
        //    else
        //    {
        //        movement.z = 0;
        //    }
        }
        else if (changer.isRightCloudCamera == true)
        {
            camera = cameraPos[8];
        //    if (Input.GetAxis("Horizontal") == 1 || Input.GetAxis("Horizontal") == -1)
        //    {
        //        movement.z = Input.GetAxis("Horizontal") * speed;
        //    }
        //    else
        //    {
        //        movement.z = 0;
        //    }
        //    if (Input.GetAxis("Vertical") == 1 || Input.GetAxis("Vertical") == -1)
        //    {
        //        movement.x = -Input.GetAxis("Vertical") * speed;
        //    }
        //    else
        //    {
        //        movement.x = 0;
        //    }
        }

        else
        {
            camera = cameraPos[2];
        //    if (Input.GetAxis("Horizontal") == 1 || Input.GetAxis("Horizontal") == -1)
        //    {
        //        movement.x = Input.GetAxis("Horizontal") * speed;
        //    }
        //    else
        //    {
        //        movement.x = 0;
        //    }
        //    if (Input.GetAxis("Vertical") == 1 || Input.GetAxis("Vertical") == -1)
        //    {
        //        movement.z = Input.GetAxis("Vertical") * speed;
        //    }
        //    else
        //    {
        //        movement.z = 0;
        //    }
        }
        movement.x = Input.GetAxis("Horizontal") * speed;
        movement.z = Input.GetAxis("Vertical") * speed;

        movement.y = Jump(0f);
        movement = camera.TransformDirection(movement);



        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Press Spacebar");
            movement.y = 20f;
        }
        rb.AddForce(movement);
        if (healthandDamage.death == true)
        {
            rb.isKinematic = true;
        }



        if (winTrigger.gameWon == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }
    }




    void SpeedUp () 
    {
        speed = speed + 5 * Time.deltaTime;
    }

    void SpeedDown () 
    {
        speed = speed - 5 * Time.deltaTime;
    }


    void OnCollisionEnter (Collision other) 
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            audioSource.PlayOneShot(collisionClip);
            touchGround = true;
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            touchGround = true;
        }
        if (other.gameObject.CompareTag("rightPlatform"))
        {
            touchGround = true;
        }
        if (other.gameObject.CompareTag("leftPlatform"))
        {
            touchGround = true;
        }
        if (other.gameObject.CompareTag("Platform"))
        {
            touchGround = true;
        } 
    }

    void OnCollisionExit (Collision other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            
            touchGround = false;
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            touchGround = false;
        }
        if (other.gameObject.CompareTag("rightPlatform"))
        {
            touchGround = false;
        }
        if (other.gameObject.CompareTag("leftPlatform"))
        {
            touchGround = false;
        }
        if (other.gameObject.CompareTag("Platform"))
        {
            touchGround = false;
        } 
    }
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            Collectable = other.gameObject;
            ScoreContainer scoreContainer = Collectable.GetComponent<ScoreContainer>();
            //otherRB = other.gameObject.GetComponent<Rigidbody>();
            displayCount = displayCount + scoreContainer.count;
            displayScore = displayScore + scoreContainer.score;
            UpdateProgressbar();
            otherObject = other.gameObject.transform.position;
            CollectablePointTrigger();
            other.gameObject.SetActive(false);
            audioSource.PlayOneShot(collectibleClip,1f);
            GameObject clone = Instantiate(shine, other.gameObject.transform.position, Quaternion.identity);
            Destroy(clone, 2f);
        }
    }



    void CollectablePointTrigger () 
    {        
        otherObject = otherObject + new Vector3(0,1.43f,0);
        newcloneCanvas = Instantiate(pointCanvas, otherObject, Quaternion.identity);
        Destroy(newcloneCanvas, 1f);
    }



    void UpdateProgressbar () {
        ratio = displayCount / maxCount;
        string diamonds;
        if (displayCount == 1)
        {
            diamonds = " Diamond";
        }
        else
        {
            diamonds = " Diamonds";
        }
        countText.text = displayCount.ToString() + diamonds;
        scoreText.text = "Score: " + displayScore.ToString();
    }




    float Jump(float verticalvelocity)
    {
        

        if (Input.GetKeyDown(KeyCode.Space) && touchGround == true)
        {
            //startTime = Time.time;
            endTime = Time.time + .5f;
        }
            if (Input.GetKey(KeyCode.Space))
            {
            
            if (Time.time < endTime)
                {                
                    verticalvelocity = 20f; 
                }
                else
                {
                    verticalvelocity = 0f;
                }   
            }
            else
            {
                verticalvelocity = 0f;
            }
        
        return verticalvelocity;
    }




    //IEnumerator Jump ()
    //{
    //    bool jumpOn = false;
    //    if (touchGround == true)
    //    {
    //        if (Input.GetKeyDown(KeyCode.Space))
    //        {
    //            jumpOn = true;
    //            Debug.Log(jumpOn);
     //   
     //           if (jumpOn == true)
     //           {
     //               movement.y = 20f;
     //               touchGround = false;

     //               yield return new WaitForSeconds(.5f);
      //              jumpOn = false;
     //               movement.y = 0f;
      //          }
     //       }
      //      if (Input.GetKeyUp(KeyCode.Space))
      //      {
     //           jumpOn = false;
     //           movement.y = 0f;
     //       }
     //   }

    //}
}
