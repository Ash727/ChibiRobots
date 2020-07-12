using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public AudioClip _splashScreenMusic;                            // Creates slot for assigning scree music 

    private float _splashScreenFadeValue;                           // Defines fade value 
    private float _splashScrreenFadeSpeed = 0.15f;                  // define fade speed 

    private SplasScreenController splashScreenController;           // Define naming convention for splash screen controller 
    private enum SplasScreenController
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SplashScreenFadeIn() {
        splashScreenController = SplasScreenController.SplashScreenFadeIn;
        Debug.Log("SplashScreenFadeIn"); 
    } 
    private void SplashScreenFadeOut() {
        splashScreenController = SplasScreenController.SplashScreenFadeOut;
        Debug.Log("SplashScreenFadeOut");
    }

}
