using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Resources
{
    public class Experience : MonoBehaviour
    {
        [SerializeField] float experincePoints = 0;
        public void GainExperience(float experience)
        {
            experincePoints += experience;
        }
    }
}