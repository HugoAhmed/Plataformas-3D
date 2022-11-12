using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class P_collision : MonoBehaviour
{
    public float coin_count = 8;

    private void Update()
    {
        if (coin_count == 0)
        {
            SceneManager.LoadScene("Victory");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "enemy")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("SampleScene");
        }
        if (collision.collider.tag == "coin")
        {
            coin_count -= 1;
            
        }
    }
}
