using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManagement : MonoBehaviour
{
    public static PositionManagement Instance { get; private set; }
    [SerializeField]private Transform[] corners;
    private Rect rect;
    private void Awake()
    {
        if (Instance == null)
        {
            SetRectCorners();
            Instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    public bool IsInsideArena(Vector3 otherPosition)
    {
        Vector2 otherPositionOnFloor = new Vector2(otherPosition.x, otherPosition.z);
        return rect.Contains(otherPositionOnFloor);
    }

    private void SetRectCorners()
    {
        float xMin = corners[0].position.x;
        float xMax = corners[0].position.x;
        float zMin = corners[0].position.z;
        float zMax = corners[0].position.z;

        for (int i = 1; i < corners.Length; i++)
        {
            xMin = Mathf.Min(xMin, corners[i].position.x);
            xMax = Mathf.Max(xMax, corners[i].position.x);
            zMin = Mathf.Min(zMin, corners[i].position.z);
            zMax = Mathf.Max(zMin, corners[i].position.z);
        }

        rect = new Rect(xMin, xMax, zMax, zMax);
    }
}
