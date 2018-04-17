using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPatrole : MonoBehaviour {
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

    public bool isbottomleft()
    {
        if (curxaxisPosition >= 14.82 && curxaxisPosition < 25f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator LefttoRightMovement()
    {
        if (isbottomleft())
        {

            while (14.82f < 25f && isbottomleft() == true)
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
                    Debug.Log(isbottomleft());
                }
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
