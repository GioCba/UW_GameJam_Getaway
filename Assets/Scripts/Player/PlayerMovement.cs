using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Quaternion leftRotation;
    [SerializeField]
    private Quaternion rightRotation;

    [Header("Velocities")]
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float rotationSpeed;

    private float horizontal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        rb.linearVelocityX = horizontal * moveSpeed;

        if (rb.linearVelocityX > 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, rightRotation, Time.fixedDeltaTime * rotationSpeed);
        } else if (rb.linearVelocityX < 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, leftRotation, Time.fixedDeltaTime * rotationSpeed);
        } else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.fixedDeltaTime * rotationSpeed);
        }
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        horizontal = ctx.ReadValue<float>();
    }
}
