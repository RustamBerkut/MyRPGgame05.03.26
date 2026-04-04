using System;
using TMPro;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    public static Action<int> ActionCoinCollect;
    private int goldInCoin;
    public GameObject fxCoinCollect;
    public TextMeshProUGUI proUGUI;
    private void Start()
    {
        goldInCoin = UnityEngine.Random.Range(0, 30);
        proUGUI.text = string.Format("{0:0}", goldInCoin);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnCoinCollect();
        }
    }
    private void OnCoinCollect()
    {
        Instantiate(fxCoinCollect, transform.position, transform.rotation);
        ActionCoinCollect?.Invoke(goldInCoin);
        Destroy(gameObject);
    }
}
