using UnityEngine;

namespace Game
{
    public class UIInterface
    {
        private FlashLightUIText _flashLightUIText;

        public FlashLightUIText LightUIText
        {
            get
            {
                if (!_flashLightUIText)
                    _flashLightUIText = MonoBehaviour.FindObjectOfType<FlashLightUIText>();
                return _flashLightUIText;
            }
        }

        private WeaponUIText _weaponUIText;

        public WeaponUIText WeaponUIText
        {
            get
            {
                if (!_weaponUIText)
                    _weaponUIText = MonoBehaviour.FindObjectOfType<WeaponUIText>();
                return _weaponUIText;
            }
        }
    }
}
