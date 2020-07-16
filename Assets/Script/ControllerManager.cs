using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    public Texture2D _controllerNotDetected;                            // Creates slot in inspector to assign contorller not dectected warning Text 
    public bool _ps4Controller;                                         // Creates a bool for when PS4 Controller is connected 
    public bool _xBoxController;                                        // Creates a bool for when PS4 Controller is connected 
    public bool _controllerDected;                                         // Creates a bool for when PS4 Controller is connected 


    public static bool _startUpFinished;                                // Creates bool for when start up is finished


    void Awake() {
        _ps4Controller = false;                                         // PS4 controlelr is false on awake
        _xBoxController = false;                                         // _Xbox1 controlelr is false on awake 
        _controllerDected = false;                                         // controller dtected  controlelr is false on awake 

    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);                                       // Dont destroy game obj when loading new scene 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            Debug.Log("Using the Controller");
        }

    }

    void LateUpdate()
    {
        string[] _joyStickNames = Input.GetJoystickNames();
        

            /// JotstickNames Get JoyStickNames from in Built input
            for (int _js = 0; _js < _joyStickNames.Length; _js++)                 // Increase counter _js based on joystick names length 
        {
            /// Changing code to make it eaiser to devlope 
            //if (_joyStickNames[_js].Length == 19) {                         // / If joystick name equals code 19  
            //    _ps4Controller = true;                                      // Set os4 controller
            //    _controllerDected = true;                                   // Se
            //}

            //if (_joyStickNames[_js].Length == 33) {                         // / If joystick name equals code 19  
            //    _xBoxController = true;
            //    _controllerDected = true;
            //}

            if (_joyStickNames[_js].Length > 0)
            {
                _controllerDected = true;
            }


            //if (_joyStickNames[_js].Length != 0)
            //    return;                                                      // If string is null empt no controller detected 


            if (string.IsNullOrEmpty(_joyStickNames[_js])) {
                _controllerDected = false; 
            }

        }

     }

    private void OnGUI()
    {
        if(_startUpFinished==false){
            return;                                                     // Do nothing and return 
        }

        if (_controllerDected)
        {
            return;
        }
        else
        {
            
            GUI.DrawTexture(new Rect(0, 0, Screen.width,
                Screen.height)
                , _controllerNotDetected);
        }

    }

}

