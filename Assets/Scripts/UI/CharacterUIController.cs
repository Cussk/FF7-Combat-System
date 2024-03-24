using Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CharacterUIController
    {
        readonly CharacterData _characterData;
        readonly TextMeshProUGUI _characterNameText;
        readonly Slider _healthSlider;
        readonly TextMeshProUGUI _healthText;
        readonly Slider _manaSlider;
        readonly TextMeshProUGUI _manaText;
        readonly Slider _limitSlider;
        readonly Slider _timeSlider;
    
        public CharacterUIController(CharacterData characterData, GameObject characterStatsGameObject, GameObject characterNameGameObject)
        {
            _characterData = characterData;
            characterStatsGameObject.SetActive(true);
            characterNameGameObject.SetActive(true);

            _characterNameText = characterNameGameObject.GetComponent<TextMeshProUGUI>();
            _healthSlider = characterStatsGameObject.transform.GetChild(0).GetComponent<Slider>();
            _healthText = characterStatsGameObject.transform.GetChild(0).transform.GetChild(2).GetComponent<TextMeshProUGUI>();
            _manaSlider = characterStatsGameObject.transform.GetChild(1).GetComponent<Slider>();
            _manaText = characterStatsGameObject.transform.GetChild(1).transform.GetChild(2).GetComponent<TextMeshProUGUI>();
            _limitSlider = characterStatsGameObject.transform.GetChild(2).GetComponent<Slider>();
            _timeSlider = characterStatsGameObject.transform.GetChild(3).GetComponent<Slider>();

            InitStatsValues();
        }

        void InitStatsValues()
        {
            _characterNameText.text = _characterData.characterName;
            _healthSlider.maxValue = _characterData.maxHealth;
            _manaSlider.maxValue = _characterData.maxMana;
            _limitSlider.maxValue = _characterData.maxLimit;
            _timeSlider.maxValue = _characterData.maxSpeed;
        }
        
        public void UpdateUIValues()
        {
            _healthSlider.value = _characterData.currentHealth;
            _manaSlider.value = _characterData.currentMana;
            _limitSlider.value = _characterData.currentLimit;
            _timeSlider.value = _characterData.currentSpeed;

            _healthText.text = _characterData.currentHealth + "/" + _characterData.maxHealth;
            _manaText.text = _characterData.currentMana.ToString();
        }
    }
}
