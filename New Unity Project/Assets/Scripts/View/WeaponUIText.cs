using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class WeaponUIText:MonoBehaviour
    {
        private Text _text;

        private void Start()
        {
            _text = GetComponent<Text>();
        }
        public void ShowData(int countAmmunition, int countClip)
        {
            _text.text = $"{countAmmunition}/{countClip}";
        }
        public void SetActive(bool value)
        {
            _text.gameObject.SetActive(value);
        }
    }
}
