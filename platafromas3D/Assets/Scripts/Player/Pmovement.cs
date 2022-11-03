using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pmovement : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody playerRigid;
    public float w_speed, wb_speed, olw_speed, rn_speed, ro_speed, jumpForce;
    public bool walking, grounded, IsOnAir;
    public Transform playerTrans;


    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * w_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * wb_speed * Time.deltaTime;
        }

        if (grounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                // reset y velocity
                playerRigid.velocity = new Vector3(playerRigid.velocity.x, 0f, playerRigid.velocity.z);

                playerRigid.AddForce(transform.up * jumpForce, ForceMode.Impulse);
                grounded = false;
                IsOnAir = true;
            }
        }

        if (IsOnAir == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                // reset y velocity
                playerRigid.velocity = new Vector3(playerRigid.velocity.x, 0f, playerRigid.velocity.z);

                playerRigid.AddForce(transform.up * jumpForce, ForceMode.Impulse);
                grounded = false;
                IsOnAir = false;
            }
        }

    }
    void Update()
    {
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


        if (Input.GetKey(KeyCode.A))
        {
            playerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnim.SetTrigger("jump");
            playerAnim.ResetTrigger("idle");
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
                w_speed = w_speed + rn_speed;
                playerAnim.SetTrigger("run");
                playerAnim.ResetTrigger("walk");
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                //steps1.SetActive(true);
                //steps2.SetActive(false);
                w_speed = olw_speed;
                playerAnim.ResetTrigger("run");
                playerAnim.SetTrigger("walk");
            }        
        }
        

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "floor")
        {
            grounded = true;
            IsOnAir = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "floor")
        {
            grounded = true;
        }
    }
}
