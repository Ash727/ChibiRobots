using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement; 

/// <summary>
/// Splash Screen 
/// Ashley Hamilton-Morley
/// July 7th 2020
/// </summary>

[RequireComponent(typeof(AudioSource))]
public class SplashScreen : MonoBehaviour
{
    public Texture2D _splashScreenBackground;                       // Create slots to assighn background image 
    public Texture2D _splashScreenText;                             //  Create slot in inspectr to assign splash screen text 

    public AudioSource _splashscreenAudioSource;                    // Deifines nameing convention for audio source component 
    public AudioClip _splashScreenAudio;                            // Creates slot for assigning scree music 

    private float _splashScreenFadeValue;                           // Defines fade value 
    private float _splashScrreenFadeSpeed = 0.15f;                  // define fade speed 

    private SplashScreenController splashScreenController;           // Define naming convention for splash screen controller 
    private enum SplashScreenController
    {
        SplashScreenFadeIn = 0,
        SplashScreenFadeOut = 1,
    }

    private void Awake()
    {
        _splashScreenFadeValue = 0; 

    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;                                     // Set the visable False value  
        Cursor.lockState = CursorLockMode.Locked;                   //and lock the cursor 
        _splashscreenAudioSource = GetComponent<AudioSource>();    // Splash screen aursio soruce 

        _splashscreenAudioSource.volume = 0;                       // Audio volume equals zero on start up 
        _splashscreenAudioSource.clip = _splashScreenAudio;        //Set the saplash scrren audio clip to that of the audio 
        _splashscreenAudioSource.loop = true;                      // Set the Audio to loop 
        _splashscreenAudioSource.Play();                           // Play the audio

        splashScreenController = SplashScreen.SplashScreenController.SplashScreenFadeIn;   // Fade in on start up 

        StartCoroutine("SplashScreenManager");                      // Starts SPlashScreenManager 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SplashScreenManager() {
        while (true)
        {
            switch (splashScreenController)
            {
                case SplashScreenController.SplashScreenFadeIn:
                    SplashScreenFadeIn();
                    break;
                case SplashScreenController.SplashScreenFadeOut:
                    SplashScreenFadeOut();
                    break;
            }

            yield return null;

        }
    }

    private void SplashScreenFadeIn() {
        //splashScreenController = SplashScreenController.SplashScreenFadeIn;
        Debug.Log("SplashScreenFadeIn");
        _splashscreenAudioSource.volume += _splashScrreenFadeSpeed * Time.deltaTime;      // Increase Volume by fade speed 
        _splashScreenFadeValue += _splashScrreenFadeSpeed * Time.deltaTime;              // Increase Volume by fade speed 

        if (_splashScreenFadeValue > 1) {
            _splashScreenFadeValue = 1;                                                   // Then set the value  to one 
            splashScreenController = SplashScreen.SplashScreenController.SplashScreenFadeOut;   // Fade in on start up 
        }

    }
    private void SplashScreenFadeOut() {
        splashScreenController = SplashScreenController.SplashScreenFadeOut;
        Debug.Log("SplashScreenFadeOut");
        _splashscreenAudioSource.volume -= _splashScrreenFadeSpeed * Time.deltaTime;      // Decrease Volume by fade speed 
        _splashScreenFadeValue -= _splashScrreenFadeSpeed * Time.deltaTime;              // Decrease Volume by fade speed 

        if (_splashScreenFadeValue < 0)
        {
            _splashScreenFadeValue = 0;                                                   // Then set the value  to zero 
            Cursor.visible = true;                                     // Set the visable False value  
            Cursor.lockState = CursorLockMode.None;                   //and lock the cursor 
            SceneManager.LoadScene("ControllerWarning");

        }
    }

    private void OnGUI()
    {
        GUI.DrawTexture                                                                  // Draw textrue at starting at  0,0
            (new Rect(0, 0, Screen.width, Screen.height),                                // By screen wdith and height 
            _splashScreenBackground);                                                   // and draw the background texture

        GUI.color = new Color(1,1,1, _splashScreenFadeValue);                                                   // GUI  color is equal to (1,1,1)
        

        GUI.DrawTexture                                                                  // Draw textrue at starting at  0,0
           (new Rect(110f, 20f, 300, 300),                                // By screen wdith and height 
           _splashScreenText);                                                          // and draw the Text  Texture 

        GUILayout.BeginHorizontal();
        //GUI.Button(new Rect(0, 0,c), "Push ME");
        GUILayout.EndHorizontal();
    }

}
