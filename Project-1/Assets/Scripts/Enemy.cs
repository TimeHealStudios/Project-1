using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    [Header("Enemy Target Settings")]
    public Transform target;
    
    private NavMeshAgent _navMeshAgent;
    private float _distanceToTarget;
    
   
    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        _distanceToTarget = Vector3.Distance(_navMeshAgent.transform.position, target.position);

        _navMeshAgent.destination = target.position;
    }
}