using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Ashley Hamilton-Morley
/// 07/15/2020
/// </summary>
public class ControllerWarning : ControllerManager
{
    public Texture2D _controllerWarningBackground;                       // Create slot in inspector to  assign the controller warning background
    public Texture2D _controllerWarningText;                       // Create slot in inspector to  assign the controller warning background
    public  Texture2D _controllerDetectedText;                     // Creates skit ub ubsoectir ti assign the controller dtected text message  

    public float _controllerWarningFadeValue;                      // Defines the fade value of the warning text
    private float _controllerWarningFadeSpeed = 0.24f;              // Defines the fade speed
    private bool _controllerConditionsMet;                          // Defines if the controller conditions are met for the game to continue

    // Start is called before the first frame update
    void Start()
    {
        _controllerWarningFadeValue = 1;                            // Fade value equals 1 on start up controller conditions met
        _controllerConditionsMet = false;                            // Controelr coniditions met is false on start up
   
    }

    // Update is called once per frame
    void Update()
    {
     
        if (_controllerDected) {
            StartCoroutine("WaitToLoadMainMenu");                     // Start function 
        }

        if(_controllerConditionsMet == false) {     
            return;
        }

        if (_controllerConditionsMet == true){
            _controllerWarningFadeValue -=                          // Decrease fade valu e 
                _controllerWarningFadeSpeed *                       // By the speed over a peroid of time
                Time.deltaTime;        
        }

        if(_controllerWarningFadeValue < 0) {                       // OF fade value les than zero
            _controllerWarningFadeValue = 0;                        // Reset it back to zero 
        }

        if (_controllerWarningFadeValue==0) {                        // If Fade value equals 0 
            _startUpFinished = true;
            SceneManager.LoadScene("MainMenu");                          // Launch in the main men u

        }

    }

    private IEnumerator WaitToLoadMainMenu() {
        yield return new WaitForSeconds(2);                         // Wait for this (x) many seconds
        _controllerConditionsMet = true;                            // Set Controller Conditions met to true 
    }

    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width,                // Draw textrure starting at 0,0
                        Screen.height)                              // By the scren width height
                        , _controllerWarningBackground);            // Draw the warning background 

        GUI.color = new Color(1, 1, 1,                              // GUI color is equal to (1 1 1 a)(rgba deafualt)
            _controllerWarningFadeValue);

        GUI.DrawTexture(new Rect(0, 0, Screen.width,                // Draw textrure starting at 0,0
                        Screen.height)                              // By the scren width height
                        , _controllerWarningText);                  // Draw the warning background 

        if (_controllerDected)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width,            // Draw textrure starting at 0,0
                Screen.height)                                      // By the scren width height
                , _controllerDetectedText);                         // Draw the controller detected text 
        }
    }

}
