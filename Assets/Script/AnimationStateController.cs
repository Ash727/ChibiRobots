using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationStateController : MonoBehaviour
{
    public Animator animator;

    public static bool walk;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public static void StartWalking() {
      // animator.SetBool("startRunning", true);
      walk = true;
    }

    public void StoptWalking() {
      // animator.SetBool("startRunning", true);
      walk = false;
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetAxis("Vertical") > 0 || walk)
        {
            animator.SetBool("startRunning", true);
        }
        else if (Input.GetAxis("Vertical") == 0)
        {
            animator.SetBool("startRunning", false);
        }
    }
}
