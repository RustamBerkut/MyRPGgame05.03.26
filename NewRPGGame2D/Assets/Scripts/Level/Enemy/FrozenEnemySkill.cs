using UnityEngine;
using System.Collections;

public class FrozenEnemySkill : MonoBehaviour
{
    private EnemyMoving enemyMoving;

    private void Start()
    {
        enemyMoving = GetComponent<EnemyMoving>();
    }

    public void OnFreezeSkillUse()
    {
        StartCoroutine(nameof(FreezeCor));
    }
    IEnumerator FreezeCor()
    {
        enemyMoving.enabled = false;
        yield return new WaitForSeconds(3f);
        enemyMoving.enabled = true;
    }
}
