using UnityEngine;

public class SkillCanvasActivated : MonoBehaviour, ISkill
{
    public float             coolDownTime;

    [SerializeField]
    private float            skillRadius;
    [SerializeField]
    private int              skillDamage;
    [SerializeField]
    private GameObject       teleportFX;
    [SerializeField]
    private int              skillLevel;
    [SerializeField]
    private GameObject       skillCanvas;

    private GameObject       player;
    private Collider2D[]     objectsInsideArea;

    public void OnSkillUse()
    {
        OnPlayerSkill();
    }
    public void OnSetupCD()
    {

    }

    private void OnPlayerSkill()
    {
        Instantiate(skillCanvas);
    }
}
