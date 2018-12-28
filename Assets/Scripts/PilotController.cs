using UnityEngine;

/// <summary>
/// PilotController 
/// Handling the controller of the Vehicle. 
/// Is able to move and rotate the Player Vehicle (Left Player). MoveSpeed and RotationSpeed should be set up in the editor directly.
/// </summary>
public class PilotController : MonoBehaviour
{
    public float MoveSpeed;
    public float RotationSpeed;
    private CharacterController controller; 

    private Animator anim;
    private bool IsMoving;
    private bool WasMoving;

    /// <summary>
    /// Start, private void 
    /// Getting Animator and Controller on the gameObject;
    /// If MoveSpeed/RotateSpeed are not set up in the editor, 
    /// </summary>
    private void Start()
    {
        MoveSpeed = MoveSpeed == 0f ? 0.25f : MoveSpeed;
        RotationSpeed = RotationSpeed == 0f ? 2f : RotationSpeed;
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

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
            controller.Move(movement * currentMoveSpeed);
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
