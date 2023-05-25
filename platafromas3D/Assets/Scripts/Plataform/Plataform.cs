using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform : MonoBehaviour
{
    //Con character controller funcioanaba mal
    public Rigidbody rb;
    public float y, z;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            rb.AddForce(0, y, z);
        }
    }
}
