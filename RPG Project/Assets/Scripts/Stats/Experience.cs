using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Saving;
using System;

namespace RPG.Stats
{
    public class Experience : MonoBehaviour, ISaveable
    {
        [SerializeField] float experincePoints = 0;

        public object CaptureState()
        {
            return experincePoints;
        }

        public void GainExperience(float experience)
        {
            experincePoints += experience;
        }

        internal float GetPoints()
        {
            return experincePoints;
        }

        public void RestoreState(object state)
        {
            experincePoints = (float)state;
        }
    }
}