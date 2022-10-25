using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_anim : MonoBehaviour
{
    private Pmovement move;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<Pmovement>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("velocity", move.GetCurrentSpeed());
    }
}
