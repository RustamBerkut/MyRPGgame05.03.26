using PlayerBehaviour;
using TMPro;
using UnityEngine;

public class SceneResultUpdater : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI sceneResult;
    [SerializeField]
    private TextMeshProUGUI enemyResult;
    [SerializeField]
    private TextMeshProUGUI goldResult;
    [SerializeField]
    private TextMeshProUGUI timerResult;

    [SerializeField]
    private GameObject finishCanvas;

    private int enemyCounter;
    private float goldCounter;
    private float timerCounter;

    private void OnEnable()
    {
        finishCanvas.SetActive(false);
        EnemyHealthSystem.EnemyDeadAction += OnEnemyResult;
        CoinCollect.ActionCoinCollect += OnGoldResult;
        EnemySpawner.ArenaFinishAction += OnSceneResult;
        PlayerHealthSystem.OnPlayerDeadAction += OnSceneResult;
    }
    private void OnDisable()
    {
        EnemyHealthSystem.EnemyDeadAction -= OnEnemyResult;
        CoinCollect.ActionCoinCollect -= OnGoldResult;
        EnemySpawner.ArenaFinishAction -= OnSceneResult;
        PlayerHealthSystem.OnPlayerDeadAction -= OnSceneResult;
    }
    private void Update()
    {
        timerCounter += Time.deltaTime;
    }
    private void OnSceneResult(bool winner)
    {
        finishCanvas.SetActive(true);

        if (winner)
        {
            sceneResult.text = "победа";
        }
        else sceneResult.text = "проигрыш";

        enemyResult.text = string.Format("убито врагов: {0}", enemyCounter);
        goldResult.text = string.Format("добыто золота: {0}", goldCounter);
        timerResult.text = string.Format("время арены: {0:00}", timerCounter);

        Destroy(this);
    }
    private void OnEnemyResult(float exp, GameObject enemy)
    {
        enemyCounter ++;
    }
    private void OnGoldResult(int gold)
    {
        goldCounter += gold;
    }
}
