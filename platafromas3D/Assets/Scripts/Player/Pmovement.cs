using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pmovement : MonoBehaviour
{

    [Header("Movement")]
    public float speed;
    public float baseSpeed;
    private float rotationSpeed = 150;
    private Vector3 moveVelocity;
    bool walking;
    public float runSpeedMultiplier;



    [Header("Jump")]
    private float gravity = -20;
    private float jumpSpeed = 10;
    bool grounded;
    private int maxJumpCount = 3;
    private  int jumpsRemaining = 0;
    public float jumpForce;


    public float  ro_speed;
    private bool IsOnAir;

    private float currentMoveSpeed;


    [Header("References")]
    public CharacterController player;
    private Vector3 turnVelocity;
    public Animator playerAnim;
    public Transform playerTrans;



    void start()
    {
        currentMoveSpeed = speed;
    }
    void Update()
    {
        //Movimiento jugador
        var hInput = Input.GetAxis("Horizontal");
        var vInput = Input.GetAxis("Vertical");

        if (player.isGrounded)
        {
            moveVelocity = transform.forward * speed * vInput;
            turnVelocity = transform.up * rotationSpeed * hInput;
        }

        moveVelocity.y += gravity * Time.deltaTime;
        
        transform.Rotate(turnVelocity * Time.deltaTime);


        //Animaciones
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnim.SetTrigger("walk");
            playerAnim.ResetTrigger("idle");
            walking = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.ResetTrigger("walk");
            playerAnim.SetTrigger("idle");
            walking = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnim.SetTrigger("walkback");
            playerAnim.ResetTrigger("idle");
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.ResetTrigger("walkback");
            playerAnim.SetTrigger("idle");
        }

        //Rotacion
        if (Input.GetKey(KeyCode.A))
        {
            playerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);
        }
        if(jumpsRemaining > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerAnim.SetTrigger("jump");
                playerAnim.ResetTrigger("idle");
            }
        }
           

        if (Input.GetKeyUp(KeyCode.Space))
        {
            playerAnim.ResetTrigger("jump");
            playerAnim.SetTrigger("idle");
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            playerAnim.SetTrigger("crouched");
            playerAnim.ResetTrigger("idle");
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            playerAnim.ResetTrigger("crouched");
            playerAnim.SetTrigger("idle");
        }


        if (walking == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                //steps1.SetActive(false);
                //steps2.SetActive(true);
                  speed *= runSpeedMultiplier;
                playerAnim.SetTrigger("run");
                playerAnim.ResetTrigger("walk");
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                //steps1.SetActive(true);
                //steps2.SetActive(false);
                speed = baseSpeed;
                playerAnim.ResetTrigger("run");
                playerAnim.SetTrigger("walk");
            }   

        }

        if (Input.GetKeyDown(KeyCode.Space) && (jumpsRemaining > 0))
        {
            // reset y velocity
            moveVelocity.y = jumpForce;
            jumpsRemaining -= 1;

        }
        player.Move(moveVelocity * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "floor")
        {
            grounded = true;
            jumpsRemaining = maxJumpCount;
        }
        if (collision.collider.tag == "enemy")
        {
            Destroy(gameObject);
        }
        if (collision.collider.tag == "wall")
        {
            jumpsRemaining += 1;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        grounded = false;
        
    }


}
