using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChildCollisionDetectionImpl : MonoBehaviour, IChildCollisionDetection
{
    public abstract void OnChildrenDetectedCollisionEnter(Collision collision);
    public abstract void OnChildrenDetectedCollisionExit(Collider other);
    public abstract void OnChildrenDetectedCollisionStay(Collider other);

    [SerializeField] private MeshRenderer[] optionalRenderersOnly;
    private List<ChildColliderDetector> detectors;
    private void Start ()
    {
        InitChildColliderDetectors(optionalRenderersOnly.Length > 0 ? optionalRenderersOnly : GetComponentsInChildren<MeshRenderer>());
    }

    private void InitChildColliderDetectors(MeshRenderer[] renderers)
    {
        detectors = new List<ChildColliderDetector>();

        for (int i = 0; i < renderers.Length; i++)
        {
            ChildColliderDetector detector = renderers[i].gameObject.AddComponent<ChildColliderDetector>();
            detector.AttachToCollisionDetection(this);
            detectors.Add(detector);
        }
    }

    protected void ShutdownCollisionDetectionService()
    {
        for(int i = 0; i < detectors.Count; i++)
        {
            Destroy(detectors[i]);
        }

        Destroy(this);
    }
}
