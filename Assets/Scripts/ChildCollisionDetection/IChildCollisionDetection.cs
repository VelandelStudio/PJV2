using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChildCollisionDetection {

    void OnChildrenDetectedCollisionEnter(Collider other);
    void OnChildrenDetectedCollisionStay(Collider other);
    void OnChildrenDetectedCollisionExit(Collider other);
}
