using PlayerBehaviour;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    public GameObject        skillGO;
    public Slider            slider;
    public float             coolDownSkillMax;
    public float             coolDownSkillCurrent;
    public PlayerManaSystem  playerManaSystem;
    public int               skillManaCost;
        
    private bool             isSkillReady;
    private int              currentMana;

    private void Start()
    {
        SetupCoolDown();
    }

    public void SetupCoolDown()
    {
        slider.maxValue = coolDownSkillMax;
        slider.value = 0;
    }


    private void Update()
    {
        coolDownSkillCurrent += Time.deltaTime;
        OnUpdateCD(coolDownSkillCurrent);
    }

    public void OnSkillCast()
    {
        if (skillGO == null) return;
        if (!isSkillReady) return;

        currentMana = playerManaSystem.currentMP;
        if (currentMana > skillManaCost)
        {
            playerManaSystem.OnMageAttack(skillManaCost);
        }

        skillGO.GetComponent<ISkill>().OnSkillUse();
        skillGO.GetComponent<ISkill>().OnSetupCD();

        coolDownSkillCurrent = 0;
        slider.value = 0;
        isSkillReady = false;
    }

    private void OnUpdateCD(float timer)
    {
        slider.value = timer;
        if (slider.value == slider.maxValue)
        {
            isSkillReady = true;
        }
    }
}
