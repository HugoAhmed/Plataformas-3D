using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class e_movement : MonoBehaviour
{

    public NavMeshAgent enemy;
    public Transform Player;
    public Transform Target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(Player.position);
    }

   
}
