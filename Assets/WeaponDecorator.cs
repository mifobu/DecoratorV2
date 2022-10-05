namespace Chapter.Decorator
{
    public class WeaponDecorator : IWeapon
    {
        private readonly IWeapon _decoratedWeapon;
        private readonly WeaponAttachment _attachment;
        private readonly WeaponModifier _modifier;

        public WeaponDecorator(
            IWeapon weapon, WeaponAttachment attachment, WeaponModifier modifier) {
            
            _attachment = attachment;
            _decoratedWeapon = weapon;
            _modifier = modifier;
        }
        
        public float Rate {
            get { return _decoratedWeapon.Rate 
                         + _attachment.Rate + _modifier.Rate; }
        }

        public float Range {
            get { return _decoratedWeapon.Range 
                         + _attachment.Range + _modifier.Range; }
        }

        public float Strength {
            get { return _decoratedWeapon.Strength 
                         + _attachment.Strength + _modifier.Strength; }
        }
        
        public float Cooldown
        {
            get { return _decoratedWeapon.Cooldown 
                         + _attachment.Cooldown + _modifier.Cooldown; }
        }
    }
}