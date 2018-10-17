using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerController : MonoBehaviour {
    public float RotationSpeed;
    public Vector2 HorizontalAngleMinMax;
    public Vector2 VerticalAngleMinMax;

    private float upDownRotation = 0.0f;
    private float rightLeftRotation = 0.0f;

    private void Start()
    {
        RotationSpeed = RotationSpeed == 0f ? 2f : RotationSpeed;
        HorizontalAngleMinMax = HorizontalAngleMinMax == Vector2.zero ? new Vector2(-50f, 50f) : HorizontalAngleMinMax;
        VerticalAngleMinMax = VerticalAngleMinMax == Vector2.zero ? new Vector2(-20f, 20f) : VerticalAngleMinMax;
    }

    private void Update ()
    {
        CalculateVerticalRotation();
        CalculateHorizontalRotation();

        Vector3 newRotation = new Vector3(upDownRotation, rightLeftRotation, 0f);
        transform.localRotation = Quaternion.Euler(newRotation);
    }

    private void CalculateVerticalRotation()
    {
        upDownRotation -= Input.GetAxis("Mouse Y");
        upDownRotation = Mathf.Clamp(upDownRotation, VerticalAngleMinMax.x, VerticalAngleMinMax.y);
    }

    private void CalculateHorizontalRotation()
    {
        rightLeftRotation += Input.GetAxis("Mouse X");
        rightLeftRotation = Mathf.Clamp(rightLeftRotation, HorizontalAngleMinMax.x, HorizontalAngleMinMax.y);
    }
}
