using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerShooter : MonoBehaviour {

    public float CoolDown;
    public Transform CannonEnd;
    public GameObject BulletPrefab;

    private float currentCDVal;

    private void Start ()
    {
        CoolDown = CoolDown == 0 ? 0.5f : CoolDown;
        currentCDVal = CoolDown;
    }
	
	// Update is called once per frame
	void Update () {

        if(currentCDVal != CoolDown)
        {
            currentCDVal = Mathf.Clamp(currentCDVal + Time.deltaTime, currentCDVal + Time.deltaTime, CoolDown);
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(BulletPrefab, CannonEnd.position, transform.rotation, transform);
                currentCDVal = 0f;
            }
        }
	}
}
