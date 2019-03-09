using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemyChildCollisionDetection : ChildCollisionDetectionImpl
{
    public override void OnChildrenDetectedCollisionEnter(Collider other)
    {
        Debug.Log("Hello world : "+other);
    }

    public override void OnChildrenDetectedCollisionExit(Collider other)
    {
    }

    public override void OnChildrenDetectedCollisionStay(Collider other)
    {
    }
}
