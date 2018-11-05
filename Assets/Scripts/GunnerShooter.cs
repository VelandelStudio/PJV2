using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunnerShooter : MonoBehaviour {

    public float CoolDown;
    public Transform CannonEnd;
    public GameObject BulletPrefab;

    public AudioSource audioSource;
    public ParticleSystem PS_CannonShoot;

    private float currentCDVal;
    public int RedAmmo;
    public int RedAmmoMax;
    public Text RedAmmoTextField;

    /// <summary>
    /// On start, we set up everything about Cooldown. Default CD is 0.25 sec.
    /// </summary>
    private void Start ()
    {
        CoolDown = CoolDown == 0 ? 0.25f : CoolDown;
        currentCDVal = CoolDown;
        RedAmmoTextField.text = RedAmmo + " / " + RedAmmoMax;
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
                if (RedAmmo > 0)
                {
                    Instantiate(BulletPrefab, CannonEnd.position, transform.rotation, transform);
                    PS_CannonShoot.Play(true);
                    currentCDVal = 0f;
                    RedAmmo--;
                    RedAmmoTextField.text = RedAmmo + " / " + RedAmmoMax;
                    audioSource.Play();
                }
            }
        }
	}

    public bool CollectAmmo(int amount)
    {
        if(RedAmmo == RedAmmoMax)
        {
            return false;
        }
        else
        {
            RedAmmo = Mathf.Clamp(RedAmmo + amount, 0, RedAmmoMax);
            RedAmmoTextField.text = RedAmmo + " / " + RedAmmoMax;
            return true;
        }
    }
}
