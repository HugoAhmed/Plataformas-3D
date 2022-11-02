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

        if (Input.GetKey(KeyCode.A))
        {
            playerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);
        }
    }
    void Update()
    {
        
        if (walking == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                
            }        
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

        if(IsOnAir == true)
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
