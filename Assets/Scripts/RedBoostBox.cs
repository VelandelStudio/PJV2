using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// RedBoostBox Class
/// To collect Amonition
/// </summary>
public class RedBoostBox : MonoBehaviour {

	[SerializeField] private int AmmoMinAmount;
	[SerializeField] private int AmmoMaxAmount;
	[SerializeField] private ParticleSystem PS_OnBoxPickedUp;
	
	private int AmmoValue;
	private void Start () 
	{
		AmmoValue = Random.Range(AmmoMinAmount, AmmoMaxAmount+1);
	}

    /// <summary>
    /// OnTriggerEnter Unity CallBack
    /// Give Amo when the player pass throught the box
    /// </summary>
    /// <param name="other"></param>
	private void OnTriggerEnter(Collider other)
	{
        Debug.Log(other.tag);
		if(other.gameObject.tag == "Player")
		{
			if(other.transform.root.gameObject.GetComponentInChildren<GunnerShooter>().CollectAmmo(AmmoValue))
			{
				PS_OnBoxPickedUp.transform.SetParent(null);
				PS_OnBoxPickedUp.Play(true);
				Destroy(PS_OnBoxPickedUp.gameObject,5f);
				Destroy(gameObject);
			}
		}
	}
}
