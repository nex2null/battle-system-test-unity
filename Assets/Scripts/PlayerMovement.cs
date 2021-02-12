using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// The player's movement speed
    /// </summary>
    public float MoveSpeed;

    // Component references
    private Rigidbody2D myRigidBody;

    /// <summary>
    /// Handle game start
    /// </summary>
    private void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Handle game updates
    /// </summary>
    private void FixedUpdate()
    {
        HandleMovement();
    }

    /// <summary>
    /// Handle the movement of the character
    /// </summary>
    void HandleMovement()
    {
        // Figure out our change vector
        var change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        // Move the character
        if (change != Vector3.zero)
            myRigidBody.MovePosition(transform.position + (change * MoveSpeed * Time.fixedDeltaTime));
    }
}
