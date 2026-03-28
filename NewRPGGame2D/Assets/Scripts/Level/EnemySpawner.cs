
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy1;
    [SerializeField] private GameObject _enemy2;
    [SerializeField] private GameObject _enemy3;
    [SerializeField] private GameObject _enemy4;
    [SerializeField] private GameObject _enemy5;
    [SerializeField] private GameObject _enemyBoss;

    [SerializeField] private GameObject _spawnPoints1, _spawnPoints2, _spawnPoints3, _spawnPoints4;

    private float _waveMultiply = 1.15f;
    private byte _waveCounter;
    private float _waveTimer = 15;
    private float _timeBetweenWave = 30;
    private bool _isWaveReady;

    [SerializeField]
    private TextMeshProUGUI _waveCounterProUGUI;
    [SerializeField]
    private TextMeshProUGUI _timeCounterProUGUI;
    [SerializeField]
    private int _enemyCurrentList;

    private void OnEnable()
    {
        EnemyHealthSystem.EnemyDeadAction += OnEnemyDeath;
    }
    private void OnDisable()
    {
        EnemyHealthSystem.EnemyDeadAction -= OnEnemyDeath;
    }

    private void Start()
    {
        _waveCounterProUGUI.text = string.Format("Волна: {0}", _waveCounter);
    }

    private void Update()
    {


        if (!_isWaveReady)
        {
            _waveTimer -= Time.deltaTime;
            _timeCounterProUGUI.text = string.Format("Волна через {0:0}", _waveTimer);
            if (_waveTimer < 0)
            {
                
                _isWaveReady = true;
            }
        }
        else if (_isWaveReady)
        {
            _timeCounterProUGUI.text = string.Format("Осталось врагов {0:0}", _enemyCurrentList);
            if (_enemyCurrentList == 0)
            {

                _isWaveReady = false;
            }
        }

        if (_waveTimer < 0 & _isWaveReady)
        {
             OnEnemySpawn();
            
        }
    }

    private void OnEnemySpawn()
    {
        _waveTimer = 15;
        _waveCounter++;
        _waveCounterProUGUI.text = string.Format("Волна: {0}", _waveCounter);
        switch (_waveCounter)
        {
            case 1:
                Instantiate(_enemy1, _spawnPoints1.transform.position, Quaternion.identity);
                _enemyCurrentList++;
                Instantiate(_enemy1, _spawnPoints2.transform.position, Quaternion.identity);
                _enemyCurrentList++;
                Instantiate(_enemy1, _spawnPoints3.transform.position, Quaternion.identity);
                _enemyCurrentList++;
                Instantiate(_enemy2, _spawnPoints4.transform.position, Quaternion.identity);
                _enemyCurrentList++;
                
                break;
            case 2:
                Instantiate(_enemy1, _spawnPoints1.transform.position, Quaternion.identity);
                _enemyCurrentList++;
                Instantiate(_enemy1, _spawnPoints2.transform.position, Quaternion.identity);
                _enemyCurrentList++;
                Instantiate(_enemy1, _spawnPoints3.transform.position, Quaternion.identity);
                _enemyCurrentList++;
                Instantiate(_enemy2, _spawnPoints4.transform.position, Quaternion.identity);
                _enemyCurrentList++;
                break;
            case 3:
                Instantiate(_enemy1, _spawnPoints1.transform.position, Quaternion.identity);
                _enemyCurrentList++;
                Instantiate(_enemy1, _spawnPoints2.transform.position, Quaternion.identity);
                _enemyCurrentList++;
                Instantiate(_enemy1, _spawnPoints3.transform.position, Quaternion.identity);
                _enemyCurrentList++;
                Instantiate(_enemy2, _spawnPoints4.transform.position, Quaternion.identity);
                _enemyCurrentList++;
                break;
            case 4:
                Instantiate(_enemy1, _spawnPoints1.transform.position, Quaternion.identity);
                _enemyCurrentList++;
                Instantiate(_enemy1, _spawnPoints2.transform.position, Quaternion.identity);
                _enemyCurrentList++;
                Instantiate(_enemy1, _spawnPoints3.transform.position, Quaternion.identity);
                _enemyCurrentList++;
                Instantiate(_enemy2, _spawnPoints4.transform.position, Quaternion.identity);
                _enemyCurrentList++;
                break;
            case 5:
                Instantiate(_enemy5);
                _enemyCurrentList++;
                break;
            case 6:
                Instantiate(_enemy1);
                _enemyCurrentList++;
                break;
            case 7:
                Instantiate(_enemy2);
                _enemyCurrentList++;
                break;
            case 8:
                Instantiate(_enemy3);
                _enemyCurrentList++;
                break;
            case 9:
                Instantiate(_enemy4);
                _enemyCurrentList++;
                break;
            case 10:
                Instantiate(_enemy5);
                _enemyCurrentList++;
                break;
            default:
                break;
        }
    }
    private void OnEnemyDeath(int exp, GameObject enemyGO)
    {
        Debug.Log(enemyGO);
        _enemyCurrentList--;
        _timeCounterProUGUI.text = string.Format("Осталось врагов {0:0}", _enemyCurrentList);
    }
}
