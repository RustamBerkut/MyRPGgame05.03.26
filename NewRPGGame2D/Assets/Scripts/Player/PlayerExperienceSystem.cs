using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace PlayerBehaviour
{
    public class PlayerExperienceSystem : MonoBehaviour
    {
        [SerializeField]
        private Slider expSlider;
        [SerializeField]
        private TextMeshProUGUI expText;
        [SerializeField]
        private TextMeshProUGUI lvlText;

        private int level = 1;
        private int currentExp = 0;
        private int expToNextLevel = 100;
        
        [SerializeField]
        private string lvlString;
        [SerializeField]
        private string currExpString;

        private void Start()
        {
            if (!PlayerPrefs.HasKey(currExpString))
            {
                OnExpUpdate(1, 0);
                return;
            }

            OnLvlLoad();
        }

        private void OnLvlLoad()
        {
            level = PlayerPrefs.GetInt(lvlString);
            currentExp = PlayerPrefs.GetInt(currExpString);
            OnExpUpdate(level, currentExp);
        }

        public void OnExpUpdate(int lvl, int exp)
        {
            currentExp += exp;
            level += lvl;
            lvlText.text = level.ToString();
            expSlider.maxValue = expToNextLevel;
            expSlider.value = currentExp;
            PlayerPrefs.SetFloat(currExpString, currentExp);
            expText.text = string.Format("{0} / {1}", currentExp, expToNextLevel);
        }
        private void OnExpSetupInText()
        {
            expText.text = string.Format("{0} / {1}", currentExp, expToNextLevel);
        }
        private void OnLvlUp()
        {
            PlayerPrefs.SetInt(lvlString, level);
        }
    }
}
