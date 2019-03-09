using UnityEngine;

/// <summary>
/// ChildColliderDetector 
/// </summary>
public class ChildColliderDetector : MonoBehaviour
{
    private IChildCollisionDetection childCollisionDetection;

    public void AttachToCollisionDetection(IChildCollisionDetection childCollisionDetection)
    {
        this.childCollisionDetection = childCollisionDetection;
        enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger)
        {
            childCollisionDetection.OnChildrenDetectedCollisionEnter(other);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.isTrigger)
        {
            childCollisionDetection.OnChildrenDetectedCollisionStay(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.isTrigger)
        {
            childCollisionDetection.OnChildrenDetectedCollisionExit(other);
        }
    }
}
