using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashFade : MonoBehaviour {
    public RawImage splashImage;
    public RawImage ballGame;
    public RawImage diamondGIf;
    public RawImage startScreen;
    public RawImage controlInstuctions;
    public AudioSource audioSource;
    public bool isSpacebar;
    public bool readytoStart;
    private int number;
    public string loadLevel;
    bool StartGame()
    {
        if (isSpacebar == true && readytoStart == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

	// Use this for initialization
    IEnumerator Start () {
        isSpacebar = false;
        readytoStart = false;
        splashImage = GetComponent<RawImage>();
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        splashImage.canvasRenderer.SetAlpha(0.0f);
        ballGame.canvasRenderer.SetAlpha(0.0f);
        diamondGIf.canvasRenderer.SetAlpha(0.0f);
        startScreen.canvasRenderer.SetAlpha(0.0f);
        controlInstuctions.canvasRenderer.SetAlpha(0.0f);
        number = 1;
        FadeIn();
        yield return new WaitForSeconds(4f);
        FadeOut();
        yield return new WaitForSeconds(2f);
        number = 2;
        FadeIn();
        yield return new WaitForSeconds(4f);
        FadeOut();
        yield return new WaitForSeconds(2f);
        number = 3;
        FadeIn();
        yield return new WaitForSeconds(4f);
        FadeOut();
        yield return new WaitForSeconds(4);
        number = 4;
        FadeIn();
        readytoStart = true;
        yield return new WaitUntil(StartGame);
        FadeOut();
        yield return new WaitForSeconds(4f);
        number = 5;
        FadeIn();
        yield return new WaitForSeconds(10f);
        FadeOut();
        StartCoroutine(FadeOutAudio());
        yield return new WaitForSeconds(4f);

        SceneManager.LoadScene(loadLevel);
	}

    void Update(){
        if (readytoStart == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isSpacebar = true;
            }
        }
        StartGame();
    }

    void FadeIn()
    {
       
        switch (number)
        {
            case 1:
                ballGame.CrossFadeAlpha(1.0f, 2.0f, false);
                break;
            case 2:
                splashImage.CrossFadeAlpha(1.0f, 2.0f, false);
                break;
            case 3:
                diamondGIf.CrossFadeAlpha(1.0f, 2.0f, false);
                break;
            case 4:
                startScreen.CrossFadeAlpha(1.0f, 2.0f, false);
                break;
            case 5:
                controlInstuctions.CrossFadeAlpha(1.0f, 2.0f, false);
                break;
        }
    }

    void FadeOut()
    {
        
        switch (number)
        {
            case 1:
                ballGame.CrossFadeAlpha(0.0f, 2.0f, false);
                break;
            case 2:
                splashImage.CrossFadeAlpha(0.0f, 2.0f, false);
                break;
            case 3:
                diamondGIf.CrossFadeAlpha(0.0f, 2.0f, false);
                break;
            case 4:
                startScreen.CrossFadeAlpha(0.0f, 2.0f, false);
                break;
            case 5:
                controlInstuctions.CrossFadeAlpha(0.0f, 3.0f, false);
                break;
        }
    }

    IEnumerator FadeOutAudio()
    {
        while (audioSource.volume >= 0)
        {
            audioSource.volume -= 1 * (Time.deltaTime / 5);
            yield return new WaitForEndOfFrame();
        }
    }
	
	
}
