using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.movement
{
    public class Mover : MonoBehaviour
    {   
        [SerializeField] Transform target;
        NavMeshAgent navMeshAgent;
        void Update()
        {
            UpdateAnimator();
        }
        private void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }
        public void Stop()
        {
            navMeshAgent.isStopped = true;
        }
        private void UpdateAnimator()
        {
            Vector3 velocity = navMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("ForwardSpeed", speed);
        }

        internal void MoveTo(Vector3 destination)
        {
            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;
        }
    }

}
