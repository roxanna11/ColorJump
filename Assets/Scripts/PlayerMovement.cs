using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    public bool groundCheck;

    private Rigidbody rb; 



    private void Start()
    {
      rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        //check for jump key + if on ground 
        if(Keyboard.current.spaceKey.wasPressedThisFrame && groundCheck)
        {
           PlayerJump();
        }

        //check for left key
        if (Keyboard.current.aKey.isPressed)
        {
            PlayerMoveLeft();
        }
        //check for right key 
        if (Keyboard.current.dKey.isPressed)
        {
            PlayerMoveRight();
        }



    }


    private void PlayerJump()
    {   //add the jump to the player - force 
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
    }


    private void PlayerMoveRight()
    {
        rb.linearVelocity = new Vector3( moveSpeed, rb.linearVelocity.y, rb.linearVelocity.z);
    }
    private void PlayerMoveLeft()
    {
        rb.linearVelocity = new Vector3(- moveSpeed, rb.linearVelocity.y, rb.linearVelocity.z);
    }



    //Check for groun w/ collision
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            groundCheck = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        groundCheck = false; 
    }
}

