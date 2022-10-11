using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 direction;
    public float speed = 8;
    public float jumpForce = 10;
    public float Gravity = -20;
    public Transform groundCheck;
    public LayerMask groundLayer;
    //Rouge
    private bool abletoDoubleJump = false;
    //Barbarian
    //Wizard
    [SerializeField] private Transform pfMagic;



    // Update is called once per frame
    void Update()
    {
        //horizontal movement
        float hInput = Input.GetAxis("Horizontal");
        direction.x = hInput * speed;
        controller.Move(direction * Time.deltaTime);

        //GroundCheck
        bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);
        if (isGrounded)
        {
            direction.y = 0;
            if (gameObject.tag == "Rouge")
            {
                gameObject.GetComponent<Renderer>().material.color = new Color(0, 255, 0);
                abletoDoubleJump = true;
            }
            //jump
            if (Input.GetButtonDown("Jump"))
            {
                direction.y = jumpForce;
            }
        }
        else
        {
            //Gravity
            direction.y += Gravity * Time.deltaTime;

            //double jump
            if (abletoDoubleJump & Input.GetButtonDown("Jump"))
            {
                direction.y = jumpForce;
                abletoDoubleJump = false;
            }
        }


        if (gameObject.tag == "Wizard")
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 255);
            if (Input.GetMouseButtonDown(0))
            {
                Cast();
            }
        }

        if (gameObject.tag == "Barbarian")
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
        }
    }

    void Cast()
    {
        Instantiate(pfMagic, transform.position, transform.rotation);
    }

}
