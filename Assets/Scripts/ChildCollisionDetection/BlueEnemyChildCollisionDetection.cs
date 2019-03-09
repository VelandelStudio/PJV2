using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemyChildCollisionDetection : ChildCollisionDetectionImpl
{
    public override void OnChildrenDetectedCollisionEnter(Collision collision)
    {
        if(collision.collider.transform.root.CompareTag("Player"))
        {
            GetComponent<BlueBehaviour>().Explodes();
            Debug.Log("NotifyExplosion");
            ShutdownCollisionDetectionService();
        }
    }

    public override void OnChildrenDetectedCollisionExit(Collider other)
    {
    }

    public override void OnChildrenDetectedCollisionStay(Collider other)
    {
    }
}
