using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public Rigidbody theRB;
    public Vector3 moveDirection;
    public CharacterController controller;
    
    // Start is called before the first frame update
    void Start()
    {
      theRB = GetComponent<Rigidbody>();
      controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {

        theRB.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, theRB.velocity.y, Input.GetAxis("Vertical") * moveSpeed);
        moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0f , Input.GetAxis("Vertical") * moveSpeed);


        if (Input.GetButton("Jump"))
        {
            moveDirection.y = jumpForce;
        }

        controller.Move(moveDirection);


    }
}
