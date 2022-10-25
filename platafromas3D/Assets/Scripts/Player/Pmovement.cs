using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pmovement : MonoBehaviour
{
    [SerializeField]
    private float acceleration; //5 en el inspector

    [SerializeField] 
    private float maxSpeed; //5 en el inspector


    private float currentSpeed = 0f;
    private float currentSpeed1 = 0f;
    private float currentSpeed2 = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
       
        else
        {
            currentSpeed -= acceleration * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.S))
        {
            currentSpeed1 += acceleration * Time.deltaTime;
        }
        else
        {
            currentSpeed -= acceleration * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.D))
        {
            currentSpeed2 += acceleration * Time.deltaTime;
        }

        currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed);
        currentSpeed1 = Mathf.Clamp(currentSpeed1, 0f, maxSpeed);

        transform.position += transform.forward * currentSpeed * Time.deltaTime;
        transform.position -= transform.forward * currentSpeed1 * Time.deltaTime;
        transform.position += transform.forward * currentSpeed2 * Time.deltaTime;
    }

    public float GetCurrentSpeed()
    {
        return this.currentSpeed;
        return this.currentSpeed1;
    }
}
