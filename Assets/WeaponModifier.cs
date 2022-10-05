using UnityEngine;

namespace Chapter.Decorator
{
    [CreateAssetMenu(fileName = "NewWeaponModifier", 
        menuName = "Weapon/Modifier", order = 1)]
    public class WeaponModifier : ScriptableObject, IWeapon 
    {
        [Range(0, -50)]
        [Tooltip("Decrease rate of firing per second")]
        [SerializeField] public float rate;
        
        [Range(0, -50)]
        [Tooltip("Decrease weapon range")]
        [SerializeField] float range;
        
        [Range(0, -100)]
        [Tooltip("Decrease weapon strength")]
        [SerializeField] public float strength;
        
        [Range(0, 5)]
        [Tooltip("Increase cooldown duration")]
        [SerializeField] public float cooldown;
        
        public string modifierName;
        public GameObject modifierPrefab;
        public string modifierDescription;

        public float Rate {
            get { return rate;  }
        }

        public float Range {
            get { return range; }
        }
        
        public float Strength {
            get { return strength;  }
        }

        public float Cooldown {
            get { return cooldown; }
        }
    }
}