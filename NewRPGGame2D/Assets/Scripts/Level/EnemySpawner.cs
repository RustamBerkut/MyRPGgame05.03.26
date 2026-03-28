using System.Collections.Generic;
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
    private List<GameObject> _enemyCurrentList;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (!_isWaveReady) 
        {
            _waveTimer -= Time.deltaTime;
            _timeCounterProUGUI.text = string.Format("Волна через {0:0}", _waveTimer);
        }
        
        if (_waveTimer < 0)
        {
            _isWaveReady = true;
            OnEnemySpawn();
            _timeCounterProUGUI.text = string.Format("Осталось врагов {0:0}", _enemyCurrentList.Count);
            if (_enemyCurrentList.Count == 0)
            {
                _waveTimer = 15;
                _isWaveReady = false;
            }
        }
    }

    private void OnEnemySpawn()
    {
        
        _waveCounter++;
        switch (_waveCounter)
        {
            case 1:
                Instantiate(_enemy1);
                _enemyCurrentList.Add(_enemy1);
                
                break;
            case 2:
                Instantiate(_enemy2);

                break;
            case 3:
                Instantiate(_enemy3);
                
                break;
            case 4:
                Instantiate(_enemy4);

                break;
            case 5:
                Instantiate(_enemy5);

                break;
            case 6:
                Instantiate(_enemy1);

                break;
            case 7:
                Instantiate(_enemy2);

                break;
            case 8:
                Instantiate(_enemy3);

                break;
            case 9:
                Instantiate(_enemy4);

                break;
            case 10:
                Instantiate(_enemy5);

                break;
            default:
                break;
        }
    }
}
