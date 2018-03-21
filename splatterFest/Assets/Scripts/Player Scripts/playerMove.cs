using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : gameEntity
{
    private CharacterController playerController;
    public float sprintSpeed;
    public float walkSpeed;
    public static bool sprint;



    private void Awake()
    {
        playerController = GetComponent<CharacterController>();
        sprint = false;
       
    }

    private void Update()
    {
        movement();
       
    }

    void movement()
    {

        speed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed  : walkSpeed;

        sprint = Input.GetKey(KeyCode.LeftShift) ? true : false;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
       

        //Movement

        //Move side to side
        Vector3 moveHorizontal = transform.right * horizontal * speed * Time.deltaTime;

        //Move forward and back
        Vector3 moveForward = transform.forward * vertical * speed * Time.deltaTime;

        //Implement said moves
        playerController.SimpleMove(moveHorizontal);
        playerController.SimpleMove(moveForward);

    }
}
