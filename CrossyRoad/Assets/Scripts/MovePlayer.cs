using UnityEngine;

public enum MoveDirection
{
    FORWARD,
    LEFT
}

public class MovePlayer : MonoBehaviour
{
    MoveDirection currentDirection, moveDirection;

    public float moveSpeed = 6f;
    public bool inFloor;
    public float jumpForce = 10f;
    private Rigidbody mybody;
    bool doubleJump;
    public bool turntile = false;
    Transform turntile_transform;
    public bool direction = false;
    private int TurnCooldown = 200;
    public Animator anim;

    void Start()
    {
        moveDirection = MoveDirection.FORWARD;
        currentDirection = MoveDirection.FORWARD;
        mybody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        inFloor = Physics.Raycast(transform.position, Vector3.down, 0.2f);
        if (inFloor) anim.SetBool("jump", false);
        TurnCooldown--;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.2f))
        {
            if (hit.collider.CompareTag("Turn"))
            {
                turntile = true;
                turntile_transform = gameObject.transform;
            }
            else
            {
                turntile = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (turntile)
            {
                if (TurnCooldown <= 0)
                {
                    direction = !direction;
                    turntile = false;
                    TurnCooldown = 200;

                    // Turn the player 90 degrees to the left
                    if (direction)
                    {
                        transform.Rotate(Vector3.up, 90f);
                        currentDirection = (MoveDirection)(((int)currentDirection + 1) % 2);
                    }
                    else
                    {
                        transform.Rotate(Vector3.up, -90f);
                        currentDirection = (MoveDirection)(((int)currentDirection - 1 + 2) % 2);
                    }

                    // Correct the position offset
                    CorrectPositionOffset();
                }
            }
            else if (inFloor || doubleJump)
            {
                // Jump action
                anim.SetBool("jump", true);
                Jump();
            }
        }

        // Move the player based on the current direction
        Vector3 movement = Vector3.zero;
        switch (direction)
        {
            case false:
                movement = transform.forward * moveSpeed * Time.deltaTime;
                break;
            case true:
                movement = transform.forward * moveSpeed * Time.deltaTime;
                break;
        }
        transform.position += movement;

        // Update the player's direction based on the current rotation
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }

    private void Jump()
    {
        // Add the necessary code to make the player jump
        if (inFloor)
        {
            mybody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            inFloor = false;
            doubleJump = true;
        }
        else if (doubleJump)
        {
            mybody.AddForce(Vector3.up * (jumpForce), ForceMode.Impulse);
            doubleJump = false;
        }
    }

    private void CorrectPositionOffset()
    {
        Vector3 correctedPosition = new Vector3(
            Mathf.Round(transform.position.x),
            transform.position.y,
            Mathf.Round(transform.position.z));

        transform.position = correctedPosition;
    }
}