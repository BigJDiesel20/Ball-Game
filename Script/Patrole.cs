using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrole : MonoBehaviour
{
    //Spark
    public GameObject sparkTrail;
    //public GameObject sparkPosition;
    //public GameObject sparkx;
    //public GameObject sparkz;
    public GameObject clone1;
    public GameObject clone2;
    public GameObject clone3;
    public GameObject clone4;
    // x Axis
    public float curxaxisPosition;
    public float curzaxisPosition;


    // Left to right movement variables
    public float ltrstartPosition;
    public float ltrendPosition;


    // Bottom to Top movement variables
    public float bttstartPosition;
    public float bttendPosition;

    // Right to left movement
    public float Movement;
    public float rtlstartPosition;
    public float rtlendPosition;

    // Top to Bottom movement variables
    public float ttbstartPosition;
    public float ttbendPosition;


    // bool gates
    public bool completed;

    public bool isCompleted()
    {
        if (completed == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    

    private float startOriginX;
    private float startOriginZ;
    // Use this for initialization
    void Start()
    {
        startOriginX = transform.position.x;
        curxaxisPosition = startOriginX;
        startOriginZ = transform.position.z;
        curzaxisPosition = startOriginZ;
            
            completed = true;
        if (gameObject.tag == "Start Bottom Left")
        {
            ltrstartPosition = startOriginX;
            ltrendPosition = ltrstartPosition + 10.18f;
            
            StartCoroutine(BoxPatroleBL());
        }
        if (gameObject.tag == "Start Top Right")
        {
            rtlstartPosition = startOriginX;
            rtlendPosition = rtlstartPosition - 10.18f;
            StartCoroutine(BoxPatroleTR());
        }
        if (gameObject.tag == "Start Top Left")
        {
            ttbstartPosition = startOriginZ;
            ttbendPosition = ttbstartPosition - 10.18f;
            StartCoroutine(BoxPatroleTL());
        }
        if (gameObject.tag == "Start Bottom Right")
        {
            bttstartPosition = startOriginZ;
            bttendPosition = bttstartPosition + 10.18f;
            StartCoroutine(BoxPatroleBR());
        }



    }

    // Update is called once per frame
    void Update()
    {

        //if (curxaxisPosition <= rtlstartPosition)
        // {

        // }




    }

    IEnumerator BoxPatroleBL()
    {
        
        while (true)
        {
            yield return new WaitUntil(isCompleted);
            LTRSpark();             
            StartCoroutine(LefttoRightMovement());
            yield return new WaitUntil(isCompleted);
            BTMSpark();   
            StartCoroutine(BottomtoTopMovement());
            yield return new WaitUntil(isCompleted);
            RTLSpark();
            StartCoroutine(RighttoLeftMovement());
            yield return new WaitUntil(isCompleted);
            TTBSpark();
            StartCoroutine(ToptoBottomMovement());
            
        }        
    }
   
    IEnumerator BoxPatroleTR()
    {
        while (true)
        {
            yield return new WaitUntil(isCompleted);
            RTLSpark();
            StartCoroutine(RighttoLeftMovement());
            yield return new WaitUntil(isCompleted);
            TTBSpark();
            StartCoroutine(ToptoBottomMovement());
            yield return new WaitUntil(isCompleted);
            LTRSpark();
            StartCoroutine(LefttoRightMovement());
            yield return new WaitUntil(isCompleted);
            BTMSpark();
            StartCoroutine(BottomtoTopMovement());
        }
    }

    IEnumerator BoxPatroleTL()
    {
        while (true)
        {
            yield return new WaitUntil(isCompleted);
            TTBSpark();
            StartCoroutine(ToptoBottomMovement());
            yield return new WaitUntil(isCompleted);
            LTRSpark();
            StartCoroutine(LefttoRightMovement());
            yield return new WaitUntil(isCompleted);
            BTMSpark();
            StartCoroutine(BottomtoTopMovement());
            yield return new WaitUntil(isCompleted);
            RTLSpark();
            StartCoroutine(RighttoLeftMovement());
        }
    }


    IEnumerator BoxPatroleBR()
    {
        while (true)
        {
            yield return new WaitUntil(isCompleted);
            BTMSpark();
            StartCoroutine(BottomtoTopMovement());
            yield return new WaitUntil(isCompleted);
            RTLSpark();
            StartCoroutine(RighttoLeftMovement());
            yield return new WaitUntil(isCompleted);
            TTBSpark();
            StartCoroutine(ToptoBottomMovement());
            yield return new WaitUntil(isCompleted);
            LTRSpark();
            StartCoroutine(LefttoRightMovement());
        }
    }





    IEnumerator LefttoRightMovement()
    {
        if (isCompleted())
        {
            completed = false;
            while (curxaxisPosition < ltrendPosition)
            {
                transform.position = transform.position + new Vector3(Movement * Time.deltaTime, 0, 0);
                curxaxisPosition = transform.position.x;
                if (curxaxisPosition >= ltrendPosition)
                {
                    curxaxisPosition = ltrendPosition;
                    transform.position = new Vector3(curxaxisPosition, transform.position.y, transform.position.z);
                    curzaxisPosition = transform.position.z;
                    bttstartPosition = curzaxisPosition;
                    bttendPosition = bttstartPosition + 10.18f;
                    completed = true;
                }
                yield return new WaitForEndOfFrame();
            }
        }
    }
    IEnumerator BottomtoTopMovement()
    {
        if (isCompleted())
        {
            completed = false;
            curzaxisPosition = bttstartPosition;
            while (curzaxisPosition < bttendPosition)
            {
                transform.position = transform.position + new Vector3(0, 0, Movement * Time.deltaTime);
                curzaxisPosition = transform.position.z;
                if (curzaxisPosition >= bttendPosition)
                {                    
                    curzaxisPosition = bttendPosition;
                    transform.position = new Vector3(transform.position.x, transform.position.y, curzaxisPosition);
                    rtlstartPosition = curxaxisPosition;
                    rtlendPosition = rtlstartPosition - 10.18f;
                    completed = true;
                }
                yield return new WaitForEndOfFrame();
            }
        }
    }

    IEnumerator RighttoLeftMovement()
    {
        if (isCompleted())
        {
            completed = false;
            curxaxisPosition = rtlstartPosition;
            while (curxaxisPosition > rtlendPosition)
            {
                transform.position = transform.position - new Vector3(Movement * Time.deltaTime, 0, 0);
                curxaxisPosition = transform.position.x;
                if (curxaxisPosition <= rtlendPosition)
                {
                    curxaxisPosition = rtlendPosition;
                    transform.position = new Vector3(curxaxisPosition, transform.position.y, transform.position.z);                    
                    ttbstartPosition = curzaxisPosition;
                    ttbendPosition = ttbstartPosition - 10.18f;
                    completed = true;
                }
                yield return new WaitForEndOfFrame();
            }
        }
    }


    IEnumerator ToptoBottomMovement()
    {
        if (isCompleted())
        {
            completed = false;
            curzaxisPosition = ttbstartPosition;
            while (curzaxisPosition > ttbendPosition)
            {
                transform.position -= new Vector3(0, 0, Movement * Time.deltaTime);
                curzaxisPosition = transform.position.z;
                if (curzaxisPosition <= ttbendPosition)
                {
                    curzaxisPosition = ttbendPosition;
                    transform.position = new Vector3(transform.position.x, transform.position.y, curzaxisPosition);
                    ltrstartPosition = curxaxisPosition;
                    ltrendPosition = ltrstartPosition + 10.18f;
                    completed = true;
                }
                yield return new WaitForEndOfFrame();
            }
        }
    }

    void LTRSpark()
    {
        if (clone4 != null)
        {
            Destroy(clone4);
        }
        clone1 = Instantiate(sparkTrail, new Vector3(transform.position.x - 1f, .2f, transform.position.z), Quaternion.Euler(0,-90,0));
        clone1.transform.parent = gameObject.transform; 
    }
    void BTMSpark()
    {
        if (clone1 != null)
        {
            Destroy(clone1);
        }
        clone2 = Instantiate(sparkTrail, new Vector3(transform.position.x, .2f, transform.position.z - 1f), Quaternion.Euler(0,-180,0));
        clone2.transform.parent = gameObject.transform;
    }
    void RTLSpark()
    {
        if (clone2 != null)
        {
            Destroy(clone2);
        }
        clone3 = Instantiate(sparkTrail, new Vector3(transform.position.x + 1, .2f, transform.position.z), Quaternion.Euler(0,90,0));
        clone3.transform.parent = gameObject.transform;
    }
    void TTBSpark()
    {
        if (clone3 != null)
        {
            Destroy(clone3);
        }
        clone4 = Instantiate(sparkTrail, new Vector3(transform.position.x, .2f, transform.position.z + 1), Quaternion.Euler(0,180,0));
        clone4.transform.parent = gameObject.transform;  
    }

}
