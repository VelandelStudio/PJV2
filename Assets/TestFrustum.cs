using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFrustum : MonoBehaviour
{
    private float TimeToRotate = 3f;
    float yVelocity = 0.0f;
    float zVelocity = 0.0f;
    float smoothHor = 20f;
    float smoothVert = 40f;

    float zAngle;
    float yAngle;
    float xAngle;

    float zAngleTarget = -40f;
    float yAngleTarget = 180f;
    float xAngleTarget = -25f;

    int turn = 0;
    private bool targetEngaged;
    private bool impulse;
    private float FrustumForce = 1f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + FrustumForce * transform.forward;

        if (turn < 2)
        {
            TimeToRotate -= Time.deltaTime;

            if (TimeToRotate <= 0)
            {
                yAngle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, yAngleTarget, smoothHor * Time.deltaTime);
                zAngle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, zAngleTarget, smoothVert * Time.deltaTime);

                transform.rotation = Quaternion.Euler(0f, yAngle, zAngle);
            }

            if (((transform.rotation.eulerAngles.y > 179.9 && transform.rotation.eulerAngles.y <= 180.1) ||
                (transform.rotation.eulerAngles.y > -0.1 && transform.rotation.eulerAngles.y <= 0.1))
                && TimeToRotate <= 0)
            {
                yAngleTarget += 180f;
                TimeToRotate = 3f;
                zAngleTarget *= -1;
                turn++;
            }
        }

        if (transform.rotation.eulerAngles.z != 0 && TimeToRotate > 0)
        {
            zAngle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, 0f, smoothVert * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0f, yAngle, zAngle);
        }

        if (turn >= 2 && !targetEngaged && transform.rotation.eulerAngles.z == 0)
        {
            xAngle = Mathf.MoveTowardsAngle(transform.eulerAngles.x, xAngleTarget, 5f * Time.deltaTime);
            transform.rotation = Quaternion.Euler(xAngle, 0f, 0f);

            targetEngaged = transform.rotation.eulerAngles.x >= 335f;
        }

        if (targetEngaged && !impulse)
        {
            xAngle = Mathf.MoveTowardsAngle(transform.eulerAngles.x, 35f, 30f * Time.deltaTime);
            transform.rotation = Quaternion.Euler(xAngle, 0f, 0f);
            impulse = transform.rotation.eulerAngles.x > 34.9 && transform.rotation.eulerAngles.x <= 35.1;

        }

        if (impulse)
        {
            FrustumForce = 3f;
        }
    }
}