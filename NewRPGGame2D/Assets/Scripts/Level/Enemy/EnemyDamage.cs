using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField]
    private int enemyDamager;

    public int EnemyDamager { get => enemyDamager; set => enemyDamager = value; }
}
