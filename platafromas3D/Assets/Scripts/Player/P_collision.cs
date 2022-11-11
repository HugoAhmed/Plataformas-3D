using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_collision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "enemy")
        {
            Destroy(gameObject);
        }
    }
}
