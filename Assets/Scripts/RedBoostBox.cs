using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBoostBox : MonoBehaviour {

	[SerializeField] private int AmmoMinAmount;
	[SerializeField] private int AmmoMaxAmount;
	[SerializeField] private ParticleSystem PS_OnBoxPickedUp;
	
	private int AmmoValue;
	private void Start () 
	{
		AmmoValue = Random.Range(AmmoMinAmount, AmmoMaxAmount+1);
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag =="Player")
		{
            Debug.Log("Hello ammo");
		}
	}
}
