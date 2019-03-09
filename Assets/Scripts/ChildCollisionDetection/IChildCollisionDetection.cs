using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChildCollisionDetection {

    void OnChildrenDetectedCollisionEnter(Collision collision);
    void OnChildrenDetectedCollisionStay(Collider other);
    void OnChildrenDetectedCollisionExit(Collider other);
}
