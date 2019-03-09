using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerLocker : MonoBehaviour
{
    private bool isInAir = false;
    private CharacterController controller;
    private IEnumerator coroutine;
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
        coroutine = WaitAndFly();
        StartCoroutine(coroutine);
    }

    public IEnumerator WaitAndFly()
    {
        yield return new WaitForSeconds(0.2f);
        while (isInAir) {
            yield return new WaitForSeconds(0.05f);
        }
    }




}
