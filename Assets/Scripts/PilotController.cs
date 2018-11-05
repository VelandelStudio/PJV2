using UnityEngine;

public class PilotController : MonoBehaviour
{
    public float MoveSpeed;
    public float RotationSpeed;

    private Animator anim;
    private bool IsMoving;
    private bool WasMoving;

    private void Start()
    {
        MoveSpeed = MoveSpeed == 0f ? 0.25f : MoveSpeed;
        RotationSpeed = RotationSpeed == 0f ? 2f : RotationSpeed;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        Vector3 movement = Vector3.zero;
        float currentMoveSpeed = MoveSpeed;
        WasMoving = IsMoving;
        IsMoving = false;

        if (Input.GetKey(KeyCode.Z))
        {
            movement += transform.forward;
            if (Input.GetKey(KeyCode.A))
            {
                movement -= transform.right;
                currentMoveSpeed = MoveSpeed / 2f;
            }

            if (Input.GetKey(KeyCode.E))
            {
                movement += transform.right;
                currentMoveSpeed = MoveSpeed / 2f;
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            movement -= transform.forward;
            if (Input.GetKey(KeyCode.A))
            {
                movement -= transform.right;
                currentMoveSpeed = MoveSpeed / 2f;
            }

            if (Input.GetKey(KeyCode.E))
            {
                movement += transform.right;
                currentMoveSpeed = MoveSpeed / 2f;
            }
        }

        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.S))
        {

            movement -= transform.right;
        }

        if (Input.GetKey(KeyCode.E) && !Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.S))
        {
            movement += transform.right;
        }

        if (movement != Vector3.zero)
        {
            transform.position += movement * currentMoveSpeed;
            IsMoving = true;
        }

        if(IsMoving != WasMoving)
        {
            if(IsMoving)
            {
                anim.SetTrigger("Moving");
            }
            else
            {
                anim.SetTrigger("Idle");
            }
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
