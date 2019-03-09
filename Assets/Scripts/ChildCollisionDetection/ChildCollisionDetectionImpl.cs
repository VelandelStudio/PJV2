using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChildCollisionDetectionImpl : MonoBehaviour, IChildCollisionDetection
{
    public abstract void OnChildrenDetectedCollisionEnter(Collider other);
    public abstract void OnChildrenDetectedCollisionExit(Collider other);
    public abstract void OnChildrenDetectedCollisionStay(Collider other);

    [SerializeField] private MeshRenderer[] optionalRenderersOnly;

    private void Start ()
    {
        InitChildColliderDetectors(optionalRenderersOnly.Length > 0 ? optionalRenderersOnly : GetComponentsInChildren<MeshRenderer>());
    }

    private void InitChildColliderDetectors(MeshRenderer[] renderers)
    {
        for (int i = 0; i < renderers.Length; i++)
        {
            ChildColliderDetector detector = renderers[i].gameObject.AddComponent<ChildColliderDetector>();
            detector.AttachToCollisionDetection(this);
        }
    }
}
