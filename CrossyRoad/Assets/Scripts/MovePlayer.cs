using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;


enum MoveDirection { LEFT, FORWARD, RIGHT, BACKWARD };




public class MovePlayer : MonoBehaviour
{
    MoveDirection currentDirection, moveDirection;

    public Animator anim;
    public float moveSpeed = 2f;
    public bool inFloor;
    public float jumpForce;
    private Rigidbody mybody;
    bool doubleJump;

    void Start()
    {
        moveDirection = MoveDirection.FORWARD;
        currentDirection = MoveDirection.FORWARD;
        anim = GetComponent <Animator>();
        mybody = GetComponent<Rigidbody>();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (inFloor ) {
                anim.SetBool("jump", true);
                mybody.velocity = Vector3.up * jumpForce;
                doubleJump = true;
                Debug.Log(1);
            }
        else if (doubleJump ) {
                Debug.Log(2);
                mybody.velocity = Vector3.up * jumpForce;
                doubleJump = false;
            }
        }
    }
    void Update()
    {
        inFloor = Physics.Raycast(transform.position, Vector3.down, 0.2f);
        Jump();
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)))
            {
                moveDirection = MoveDirection.FORWARD;
                if (currentDirection == MoveDirection.LEFT)
                    transform.Rotate(0.0f, 90.0f, 0.0f);
                else if (currentDirection == MoveDirection.RIGHT)
                    transform.Rotate(0.0f, -90.0f, 0.0f);
                currentDirection = moveDirection;
               
            }
            else if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
            {
                moveDirection = MoveDirection.LEFT;
                if (currentDirection == MoveDirection.FORWARD)
                    transform.Rotate(0.0f, -90.0f, 0.0f);
                else if (currentDirection == MoveDirection.RIGHT)
                    transform.Rotate(0.0f, -180.0f, 0.0f);
                currentDirection = moveDirection;
               
            }
            else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
            {
                moveDirection = MoveDirection.RIGHT;
                if (currentDirection == MoveDirection.LEFT)
                    transform.Rotate(0.0f, 180.0f, 0.0f);
                else if (currentDirection == MoveDirection.FORWARD)
                    transform.Rotate(0.0f, 90.0f, 0.0f);
                currentDirection = moveDirection;
              
            }

            switch (moveDirection)
                {
                    case MoveDirection.LEFT:
                         mybody.MovePosition(transform.position + Vector3.left * Time.deltaTime* moveSpeed);
                         break;
                    case MoveDirection.FORWARD:
                        mybody.MovePosition(transform.position + Vector3.forward * Time.deltaTime * moveSpeed);
                        break;
                    case MoveDirection.RIGHT:
                        mybody.MovePosition(transform.position + Vector3.right * Time.deltaTime * moveSpeed);
                        break;
               }      
    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        inFloor= true;
        anim.SetBool("jump", false);
    }

}
