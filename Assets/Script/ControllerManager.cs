using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    public Texture2D _controllerNotDetected;                            // Creates slot in inspector to assign contorller not dectected warning Text 
    public bool _ps4Controller;                                         // Creates a bool for when PS4 Controller is connected 
    public bool _xBoxController;                                        // Creates a bool for when PS4 Controller is connected 
    public bool _controllerDecteed;                                         // Creates a bool for when PS4 Controller is connected 


    public static bool _startUpFinished;                                // Creates bool for when start up is finished

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
