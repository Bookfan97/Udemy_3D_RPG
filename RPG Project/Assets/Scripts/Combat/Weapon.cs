using UnityEngine;

namespace RPG.Combat
{
    [CreateAssetMenu(fileName = "weapon", menuName = "Weapons/Make New Weapom", order = 0)]
    public class Weapon : ScriptableObject
    {

        [SerializeField] AnimatorOverrideController animatorOverride = null;
        [SerializeField] GameObject weaponPrefab = null;
        [SerializeField] float weaponDamage = 5f;
        [SerializeField] float weaponRange = 2f;
 

        public void Spawn(Transform handTransform, Animator animator)
        {
            if(weaponPrefab != null)
            {
                Instantiate(weaponPrefab, handTransform);
            }
            if(animatorOverride != null)
            {
                animator.runtimeAnimatorController = animatorOverride;
            }
            
        }
        public float GetWeaponDamage()
        {
            return weaponDamage;
        }
        public float GetWeaponRange()
        {
            return weaponRange;
        }
    }
}