using UnityEngine;

public class SkillCanvasActivated : MonoBehaviour, ISkill
{
    public float             coolDownTime;
    public int               skillManaCost;

    [SerializeField]
    private float            skillRadius;
    [SerializeField]
    private int              skillDamage;
    [SerializeField]
    private int              skillLevel;
    [SerializeField]
    private GameObject       skillCanvas;

    public void OnSkillUse()
    {
        OnPlayerSkill();
    }

    private void OnPlayerSkill()
    {
        GameObject canvas = Instantiate(skillCanvas);
        canvas.GetComponent<ISkill>().OnSetupSkillInfo(skillRadius, skillDamage, skillLevel);
    }
}
