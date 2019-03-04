using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerLocker : MonoBehaviour
{
    private bool isInAir = false;
    private CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check if bugs with isGrounded
        if(isInAir && controller.isGrounded)
        {
            isInAir = false;
            controller.enabled = true;
        }
    }

    public void LockControllerInAir()
    {
        controller.enabled = false;
        isInAir = true;
    }
}
