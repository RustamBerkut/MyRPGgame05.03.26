using UnityEngine;

public class FrozenSkill : MonoBehaviour, ISkill
{
    public void OnSkillUse()
    {
        Debug.Log("Frozen");
    }
}
