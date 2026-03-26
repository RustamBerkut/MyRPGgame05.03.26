using System.Collections.Generic;
using UnityEngine;

public class GameContinue : MonoBehaviour
{
    public string isGameStart;
    public List<GameObject> buttonsContinue;

    private void Start()
    {
        if (!PlayerPrefs.HasKey(isGameStart))
        {
            PlayerPrefs.SetInt(isGameStart, 1);
            for (int i = 0; i < buttonsContinue.Count; i++)
            {
                buttonsContinue[i].SetActive(false);
            }
        }
    }
    private void OnDisable()
    {
        PlayerPrefs.SetInt(isGameStart, 1);
    }
}
