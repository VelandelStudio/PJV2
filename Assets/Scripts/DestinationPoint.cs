using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationPoint : MonoBehaviour
{
    private GameObject myEnemy;// Start is called before the first frame update
    void Awake()
    {
      Collider col = GetComponent<Collider>();
      if(!col.isTrigger)
      {
        col.isTrigger = true;
      }
      myEnemy = transform.parent.gameObject;
    }

    public void OnTriggerEnter(Collider other)
    {
      if(other.transform.root.gameObject == myEnemy)
      {
        BlueBehaviour enemy = other.transform.root.GetComponentInParent<BlueBehaviour>();
        enemy.HasArrived = true;
      }

    }
}
