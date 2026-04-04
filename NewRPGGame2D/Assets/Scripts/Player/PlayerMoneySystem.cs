using TMPro;
using UnityEngine;

namespace PlayerBehaviour
{
    public class PlayerMoneySystem : MonoBehaviour
    {
        [SerializeField]
        private string moneyName;
        [SerializeField]
        private TextMeshProUGUI proUGUI;

        private int currentMoney;

        private void Start()
        {
            OnLoadMoney();
        }

        private void OnEnable()
        {
            CoinCollect.ActionCoinCollect += OnUpdateMoney;
        }
        private void OnDisable()
        {
            CoinCollect.ActionCoinCollect -= OnUpdateMoney;
        }
        private void OnUpdateMoney(int money)
        {
            currentMoney += money;
            OnSaveMoney();
        }
        private void OnLoadMoney()
        {
            currentMoney = PlayerPrefs.GetInt(moneyName);
            proUGUI.text = currentMoney.ToString();
        }
        private void OnSaveMoney()
        {
            PlayerPrefs.SetInt(moneyName, currentMoney);
            proUGUI.text = currentMoney.ToString();
        }
    }
}
