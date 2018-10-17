using UnityEngine;

public class PilotController : MonoBehaviour
{

    public float MoveSpeed;
    public float RotationSpeed;

    private void Start()
    {
        MoveSpeed = MoveSpeed == 0f ? 0.25f : MoveSpeed;
        RotationSpeed = RotationSpeed == 0f ? 2f : RotationSpeed;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            transform.position += transform.forward * MoveSpeed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * MoveSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * MoveSpeed;
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.position += transform.right * MoveSpeed;
        }
    }

    private void HandleRotation()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0.0f, -1 * RotationSpeed, 0.0f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0.0f, 1 * RotationSpeed, 0.0f);
        }
    }
}
