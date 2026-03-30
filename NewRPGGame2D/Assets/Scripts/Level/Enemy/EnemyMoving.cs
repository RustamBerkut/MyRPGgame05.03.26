using UnityEngine;

public class EnemyMoving : MonoBehaviour
{

    public GameObject enemyBody;
    public float timerForAttack;
    public Animator animator;
    
    public GameObject rangeMissle;
    public Transform rangeBarrel;
    public float _speed;
    public float _bodyScaller;

    public EnemyAttackStyle enemyAttackStyle;

    private float attackDelay;
    private float _enemySpeed;
    private float attackDistance;
    private GameObject playerPosition;

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
        Vector3 playerPos = playerPosition.transform.position;
        Vector3 enemyPos = gameObject.transform.position;
        if (playerPos.x < enemyPos.x) // игрок находится слева от врага  
            enemyBody.transform.localScale = new Vector3(-_bodyScaller, _bodyScaller, _bodyScaller); // поворачиваем врага влево  
        else // игрок находится справа от врага  
            enemyBody.transform.localScale = new Vector3(_bodyScaller, _bodyScaller, _bodyScaller); // поворачиваем врага вправо  

        transform.position = Vector2.MoveTowards(enemyPos, playerPos, _enemySpeed);
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
