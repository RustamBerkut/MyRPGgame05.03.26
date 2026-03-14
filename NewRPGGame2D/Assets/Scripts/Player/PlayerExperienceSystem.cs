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
        private string lvlString;
        [SerializeField]
        private string currExpString;
        [SerializeField]
        private TextMeshProUGUI expText;
        [SerializeField]
        private TextMeshProUGUI lvlText;
        
        private int level = 1;
        private float currentExp = 0;
        private float expToNextLevel = 100;

        private PlayerStats playerStats;

        private void Start()
        {
            playerStats = GetComponent<PlayerStats>();
            if (!PlayerPrefs.HasKey(currExpString))
            {
                OnExpUpdate(0);
                return;
            }
            OnLvlLoad();
        }

        private void OnLvlLoad()
        {
            level = PlayerPrefs.GetInt(lvlString);
            currentExp = PlayerPrefs.GetFloat(currExpString);
            for (int i = 0; i < level - 1; i++)
            {
                expToNextLevel *= 1.3f;
            }
            expSlider.maxValue = (int)expToNextLevel;
            expSlider.value = (int)currentExp;
            expText.text = string.Format("{0} / {1}", (int)currentExp, (int)expToNextLevel);
            lvlText.text = level.ToString();
        }

        public void OnExpUpdate(int exp)
        {
            currentExp += exp;
            if (currentExp >= expToNextLevel)
            {
                currentExp -= expToNextLevel;
                OnLvlUp();
            }
            expSlider.maxValue = (int)expToNextLevel;
            expSlider.value = (int)currentExp;
            expText.text = string.Format("{0} / {1}", (int)currentExp, (int)expToNextLevel);
            PlayerPrefs.SetFloat(currExpString, currentExp);
        }

        private void OnLvlUp()
        {
            level ++;
            expToNextLevel *= 1.3f;
            lvlText.text = level.ToString();
            PlayerPrefs.SetInt(lvlString, level);
            playerStats.OnSetupPlayerStatpoints();
        }
    }
}
