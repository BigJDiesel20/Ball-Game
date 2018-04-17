using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarCopy : MonoBehaviour {

    private RectTransform CurrentHealthbar;
    public Image HealthBar;
    private RectTransform HealthBarScale;
    private Text CurrentHealthtext;
    public Text HealthText;
	// Use this for initialization
	void Start () {
        if (gameObject.tag == "HBarCopy")
        {
            CurrentHealthbar = GetComponent<RectTransform>();
            HealthBarScale = HealthBar.GetComponent<RectTransform>();
            CurrentHealthbar.localScale = HealthBarScale.localScale;
        }
        if (gameObject.tag == "HTextCopy")
        {
            CurrentHealthtext = GetComponent<Text>();
            CurrentHealthtext.text = HealthText.text;
        }

	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.tag == "HBarCopy")
        {
            CurrentHealthbar.localScale = HealthBarScale.localScale;
        }
        if (gameObject.tag == "HTextCopy")
        {
            CurrentHealthtext.text = HealthText.text;
        }

	}
}
