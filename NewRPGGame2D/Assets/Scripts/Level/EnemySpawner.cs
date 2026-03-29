using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy1;
    [SerializeField] private GameObject _enemy2;
    [SerializeField] private GameObject _enemy3;
    [SerializeField] private GameObject _enemy4;
    [SerializeField] private GameObject _enemy5;
    [SerializeField] private GameObject _enemyElite1;
    [SerializeField] private GameObject _enemyElite2;
    [SerializeField] private GameObject _enemyElite3;
    [SerializeField] private GameObject _enemyElite4;
    [SerializeField] private GameObject _enemyElite5;
    [SerializeField] private GameObject _enemyBoss;

    [SerializeField] private List<GameObject> _spawnPoints;

    private float _waveMultiply = 1f;
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
        OnWaveCounterUpdate();
        
        switch (_waveCounter)
        {
            case 1:
                Wave1Spawn();
                break;
            case 2:
                Wave2Spawn();
                break;
            case 3:
                Wave3Spawn();
                break;
            case 4:
                Wave4Spawn();
                break;
            case 5:
                Wave5Spawn();
                break;
            case 6:
                Wave6Spawn();
                break;
            case 7:
                Wave7Spawn();
                break;
            case 8:
                Wave8Spawn();
                break;
            case 9:
                Wave9Spawn();
                break;
            case 10:
                Wave10Spawn();
                break;
            case 11:
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
    private void Wave1Spawn()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(_enemy1, _spawnPoints[i].transform.position, Quaternion.identity);
            _enemyCurrentList++;
        }
        Instantiate(_enemy2, _spawnPoints[3].transform.position, Quaternion.identity);
        _enemyCurrentList++;
    }
    private void Wave2Spawn()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject enemy1 = Instantiate(_enemy1, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy1.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy1.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 2; i++)
        {
            GameObject enemy2 = Instantiate(_enemy2, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy2.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy2.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
    }
    private void Wave3Spawn()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject enemy = Instantiate(_enemy1, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 2; i++)
        {
            GameObject enemy = Instantiate(_enemy2, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 2; i < 3; i++)
        {
            GameObject enemy = Instantiate(_enemy3, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
    }
    private void Wave4Spawn()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject enemy = Instantiate(_enemy1, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 3; i++)
        {
            GameObject enemy = Instantiate(_enemy2, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 2; i < 3; i++)
        {
            GameObject enemy = Instantiate(_enemy3, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 1; i < 2; i++)
        {
            GameObject enemy = Instantiate(_enemy4, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
    }
    private void Wave5Spawn()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject enemy = Instantiate(_enemy1, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 4; i++)
        {
            GameObject enemy = Instantiate(_enemy2, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 1; i < 3; i++)
        {
            GameObject enemy = Instantiate(_enemy3, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 1; i < 2; i++)
        {
            GameObject enemy = Instantiate(_enemy4, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 1; i++)
        {
            GameObject enemy = Instantiate(_enemy5, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
    }
    private void Wave6Spawn()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject enemy = Instantiate(_enemy1, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 4; i++)
        {
            GameObject enemy = Instantiate(_enemy2, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 4; i++)
        {
            GameObject enemy = Instantiate(_enemy3, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 3; i++)
        {
            GameObject enemy = Instantiate(_enemy4, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 3; i++)
        {
            GameObject enemy = Instantiate(_enemy5, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
    }
    private void Wave7Spawn()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject enemy = Instantiate(_enemy1, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 4; i++)
        {
            GameObject enemy = Instantiate(_enemy2, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 4; i++)
        {
            GameObject enemy = Instantiate(_enemy3, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 4; i++)
        {
            GameObject enemy = Instantiate(_enemy4, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 4; i++)
        {
            GameObject enemy = Instantiate(_enemy5, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 1; i++)
        {
            GameObject enemy = Instantiate(_enemyElite1, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
    }
    private void Wave8Spawn()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject enemy = Instantiate(_enemy1, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 4; i++)
        {
            GameObject enemy = Instantiate(_enemy2, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 4; i++)
        {
            GameObject enemy = Instantiate(_enemy3, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 4; i++)
        {
            GameObject enemy = Instantiate(_enemy4, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 4; i++)
        {
            GameObject enemy = Instantiate(_enemy5, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 1; i++)
        {
            GameObject enemy = Instantiate(_enemyElite1, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 1; i++)
        {
            GameObject enemy = Instantiate(_enemyElite2, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
    }
    private void Wave9Spawn()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject enemy = Instantiate(_enemy1, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 4; i++)
        {
            GameObject enemy = Instantiate(_enemy2, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 4; i++)
        {
            GameObject enemy = Instantiate(_enemy3, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 4; i++)
        {
            GameObject enemy = Instantiate(_enemy4, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 4; i++)
        {
            GameObject enemy = Instantiate(_enemy5, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 1; i++)
        {
            GameObject enemy = Instantiate(_enemyElite1, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 1; i++)
        {
            GameObject enemy = Instantiate(_enemyElite2, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 1; i++)
        {
            GameObject enemy = Instantiate(_enemyElite3, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 1; i++)
        {
            GameObject enemy = Instantiate(_enemyElite4, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 1; i++)
        {
            GameObject enemy = Instantiate(_enemyElite5, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
    }
    private void Wave10Spawn()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject enemy = Instantiate(_enemy1, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 4; i++)
        {
            GameObject enemy = Instantiate(_enemy2, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 4; i++)
        {
            GameObject enemy = Instantiate(_enemy3, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 4; i++)
        {
            GameObject enemy = Instantiate(_enemy4, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 4; i++)
        {
            GameObject enemy = Instantiate(_enemy5, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 1; i++)
        {
            GameObject enemy = Instantiate(_enemyElite1, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 1; i++)
        {
            GameObject enemy = Instantiate(_enemyElite2, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 1; i++)
        {
            GameObject enemy = Instantiate(_enemyElite3, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 1; i++)
        {
            GameObject enemy = Instantiate(_enemyElite4, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 1; i++)
        {
            GameObject enemy = Instantiate(_enemyElite5, _spawnPoints[i].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
        for (int i = 0; i < 1; i++)
        {
            GameObject enemy = Instantiate(_enemyBoss, _spawnPoints[i+2].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHealthSystem>().MaxHP *= _waveMultiply;
            enemy.GetComponent<EnemyHealthSystem>().enemyExp *= _waveMultiply;
            _enemyCurrentList++;
        }
    }
    private void OnWaveCounterUpdate()
    {
        _waveTimer = 15;
        _waveCounter++;
        _waveCounterProUGUI.text = string.Format("Волна: {0}", _waveCounter);
        _waveMultiply *= 1.15f;
    }
    private void OnEnemyDeath(float exp, GameObject enemyGO)
    {
        Debug.Log(enemyGO);
        _enemyCurrentList--;
        _timeCounterProUGUI.text = string.Format("Осталось врагов {0:0}", _enemyCurrentList);
    }
}
