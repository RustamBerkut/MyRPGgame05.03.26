using PlayerBehaviour;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    public GameObject        skillGO;
    public Slider            slider;
    public float             coolDownSkillMax;
    public GameObject        noManaCanvas;
    
    public PlayerManaSystem  playerManaSystem;

    private int               skillManaCost;
    private bool             isSkillReady;
    private int              currentMana;
    private float            coolDownSkillCurrent;

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

        skillManaCost = skillGO.GetComponent<SkillCanvasActivated>().skillManaCost;
        coolDownSkillMax = skillGO.GetComponent<SkillCanvasActivated>().coolDownTime;
        currentMana = playerManaSystem.currentMP;
        if (currentMana >= skillManaCost)
        {
            playerManaSystem.OnMageAttack(skillManaCost);
            skillGO.GetComponent<ISkill>().OnSkillUse();

            slider.maxValue = coolDownSkillMax;
            coolDownSkillCurrent = 0;
            slider.value = 0;
            isSkillReady = false;
        }
        else Instantiate(noManaCanvas);
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
