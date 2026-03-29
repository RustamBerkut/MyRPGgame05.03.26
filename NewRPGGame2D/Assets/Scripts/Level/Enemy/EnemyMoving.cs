using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    public GameObject playerPosition;
    public float timerForAttack;
    public float attackDistance;
    public float rangeArrow;
    public Transform rangeBarrel;

    private float attackDelay;

    private void Start()
    {
        OnPlayerSetupInMove();
    }
    private void OnPlayerSetupInMove()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player");
        OnAttackStatsSetup();
    }
    private void OnAttackStatsSetup()
    {
        attackDelay = timerForAttack;
    }
    private void Update()
    {
        if (playerPosition == null) return;

        OnPlayerMoving();
    }

    private void OnAttack()
    {

    }
    private void OnPlayerMoving()
    {

    }
}
public enum EnemyAttackStyle
{
    Melee,
    Range,
    Mage
}
