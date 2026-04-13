using UnityEngine;

public class SkillButton : MonoBehaviour
{
    public GameObject skillGO;
    public void OnSkillCast()
    {
        skillGO.GetComponent<ISkill>().OnSkillUse();
    }
}
