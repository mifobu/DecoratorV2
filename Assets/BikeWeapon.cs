using UnityEngine;
using System.Collections;

namespace Chapter.Decorator
{
    public class BikeWeapon : MonoBehaviour
    {
        public WeaponConfig weaponConfig;
        public WeaponAttachment mainAttachment;
        public WeaponAttachment secondaryAttachment;
        public WeaponModifier modifier;

        private bool _isFiring;
        private IWeapon _weapon;
        private bool _isDecorated;
        private bool _isScoped;

        void Start() {
            _weapon = new Weapon(weaponConfig);
        }
        
        void OnGUI()
        {
            GUI.color = Color.green;
            
            GUI.Label (
                new Rect (5, 70, 150, 100), 
                "Range: "+ _weapon.Range);
            
            GUI.Label (
                new Rect (5, 90, 150, 100), 
                "Strength: "+ _weapon.Strength);
            
            GUI.Label (
                new Rect (5, 110, 150, 100), 
                "Cooldown: "+ _weapon.Cooldown);
            
            GUI.Label (
                new Rect (5, 130, 150, 100), 
                "Firing Rate: " + _weapon.Rate);
            
            GUI.Label (
                new Rect (5, 150, 150, 100), 
                "Weapon Firing: " + _isFiring);
            
            GUI.Label (
                new Rect (5, 170, 150, 100), 
                "Weapon Scoped: " + _isScoped);
            
            if (mainAttachment && _isDecorated)
                GUI.Label (
                    new Rect (5, 190, 150, 100), 
                    "Main Attachment: " + mainAttachment.name);
            
            if (secondaryAttachment && _isDecorated)
                GUI.Label (
                    new Rect (5, 210, 200, 100), 
                    "Secondary Attachment: " + secondaryAttachment.name);

            if (modifier && _isDecorated) 
                GUI.Label (
                    new Rect (5, 230, 200, 100), 
                    "Modifier:" + modifier.name);
            
        }

        public void ToggleFire() {
            _isFiring = !_isFiring;
            
            if (_isFiring)
                StartCoroutine(FireWeapon());
        }

        public void ScopeInOut() {
            _isScoped = !_isScoped;

            if (_isScoped)
                StartCoroutine(Scoped());
        }
        
        IEnumerator FireWeapon() {
            float firingRate = 1.0f / _weapon.Rate;
            
            while (_isFiring) {
                yield return new WaitForSeconds(firingRate);
                Debug.Log("fire");
            }
        }

        IEnumerator Scoped() {
            float firingRate = 1.0f / _weapon.Rate;
            
            if (_isDecorated == true) {
                yield return new WaitForSeconds(firingRate);
                Debug.Log("Scoped");
            }
        }
        
        public void Reset() {
            _weapon = new Weapon(weaponConfig);
            _isDecorated = !_isDecorated;
        }
        
        public void Decorate() {
            if (mainAttachment && !secondaryAttachment)
                _weapon = 
                    new WeaponDecorator(_weapon, mainAttachment, modifier);

            if (mainAttachment && secondaryAttachment)
                _weapon = 
                    new WeaponDecorator(
                        new WeaponDecorator(
                            _weapon, mainAttachment, modifier), secondaryAttachment, modifier);

            _isDecorated = !_isDecorated;
        }
    }
}
