using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    private GameObject playerPosition;

    public float timerForAttack;
    
    public GameObject rangeMissle;
    public Transform rangeBarrel;
    public float _speed;

    public EnemyAttackStyle enemyAttackStyle;

    private float attackDelay;
    private float _enemySpeed;
    private float attackDistance;

    private void Start()
    {
        OnPlayerSetupInMove();
    }
    private void OnPlayerSetupInMove()
    {
        switch (enemyAttackStyle)
        {
            case EnemyAttackStyle.Melee:
                attackDistance = 1;
                break;
            case EnemyAttackStyle.Range:
                attackDistance = 6;
                break;
            case EnemyAttackStyle.Mage:
                attackDistance = 4;
                break;
            default:
                break;
        }
        _enemySpeed = _speed;
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
        attackDelay -= Time.deltaTime;
        OnPlayerMoving();
    }

    
    private void OnPlayerMoving()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPosition.transform.position, _enemySpeed);
        float dis = Vector2.Distance(transform.position, playerPosition.transform.position);
        dis = Mathf.Abs(dis);
        if (dis <= attackDistance)
        {
            _enemySpeed = 0;
            if (attackDelay <= 0)
            {
                OnAttack();
            }
        }
        else _enemySpeed = _speed;
    }
    private void OnAttack()
    {
        OnAttackStatsSetup();
        switch (enemyAttackStyle)
        {
            case EnemyAttackStyle.Melee:
                OnMeleeAttack();
                break;
            case EnemyAttackStyle.Range:
                OnRangeAttack();
                break;
            case EnemyAttackStyle.Mage:
                OnMageAttack();
                break;
            default:
                break;
        }
    }
    private void OnMeleeAttack()
    {

    }
    private void OnRangeAttack()
    {
        GameObject missle = Instantiate(rangeMissle, rangeBarrel.transform.position, rangeBarrel.transform.rotation);
    }
    private void OnMageAttack()
    {
        GameObject missle = Instantiate(rangeMissle, rangeBarrel.transform.position, rangeBarrel.transform.rotation);
    }
}
public enum EnemyAttackStyle
{
    Melee,
    Range,
    Mage
}
