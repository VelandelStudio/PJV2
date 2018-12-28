using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GunnerController is used to move the Gunner camera with input detections.
/// </summary>
public class GunnerController : MonoBehaviour {
    public float RotationSpeed;
    public Vector2 HorizontalAngleMinMax;
    public Vector2 VerticalAngleMinMax;

    private float upDownRotation = 0.0f;
    private float rightLeftRotation = 0.0f;

    /// <summary>
    /// On Start, we check if roation values are set in the editor. If it is not, we simply attribute them soùe default values.
    /// </summary>
    private void Start()
    {
        RotationSpeed = RotationSpeed == 0f ? 2f : RotationSpeed;
        HorizontalAngleMinMax = HorizontalAngleMinMax == Vector2.zero ? new Vector2(-50f, 50f) : HorizontalAngleMinMax;
        VerticalAngleMinMax = VerticalAngleMinMax == Vector2.zero ? new Vector2(-20f, 20f) : VerticalAngleMinMax;
    }
    /// <summary>
    /// On Update, we call functions to calculate Vertical and horizontal rotation.
    /// Then we apply the results to the local camera.
    /// </summary>
    private void Update ()
    {
        CalculateVerticalRotation();
        CalculateHorizontalRotation();

        Vector3 newRotation = new Vector3(upDownRotation, rightLeftRotation, 0f);
        transform.localRotation = Quaternion.Euler(newRotation);
    }

    /// <summary>
    /// calculate the Up/Down roation using the Mouse Y Axis
    /// </summary>
    private void CalculateVerticalRotation()
    {
        upDownRotation -= Input.GetAxis("Mouse Y");
        upDownRotation = Mathf.Clamp(upDownRotation, VerticalAngleMinMax.x, VerticalAngleMinMax.y);
    }

    /// <summary>
    /// calculate the Left/Right roation using the Mouse X Axis
    /// </summary>
    private void CalculateHorizontalRotation()
    {
        rightLeftRotation += Input.GetAxis("Mouse X");
        rightLeftRotation = Mathf.Clamp(rightLeftRotation, HorizontalAngleMinMax.x, HorizontalAngleMinMax.y);
    }
}
