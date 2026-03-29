using System;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    public static Action<int> ActionCoinCollect;
    public int goldInCoin;
    public GameObject fxCoinCollect;

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
    }
}
