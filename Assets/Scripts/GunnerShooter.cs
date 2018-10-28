using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerShooter : MonoBehaviour {

    public float CoolDown;
    public Transform CannonEnd;
    public GameObject BulletPrefab;

    public AudioSource audioSource;
    public ParticleSystem PS_CannonShoot;

    private float currentCDVal;


    /// <summary>
    /// On start, we set up everything about Cooldown. Default CD is 0.25 sec.
    /// </summary>
    private void Start ()
    {
        CoolDown = CoolDown == 0 ? 0.25f : CoolDown;
        currentCDVal = CoolDown;
    }
	
    /// <summary>
    /// On Update, we are checking if we are on Cooldown. If we are not, and if the player gets Mouse 0 down, we shoot a bullet.
    /// Shooting a bullet launches sounds and PS. We also reset the CD.
    /// </summary>
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
                audioSource.Play();
                PS_CannonShoot.Play(true);
                currentCDVal = 0f;
            }
        }
	}
}
