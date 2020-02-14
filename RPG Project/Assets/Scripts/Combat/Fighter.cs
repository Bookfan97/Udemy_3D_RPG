using RPG.movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] float weaponRange = 2f;
        Transform target;
        private void Update()
        {
            bool isInRange = Vector3.Distance(transform.position, target.position) < weaponRange;
            if(target != null && !isInRange)
            {
                GetComponent<Mover>().MoveTo(transform.position);
            }
            else
            {
                GetComponent<Mover>().Stop();
            }
        }
        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
        }
    }
}
