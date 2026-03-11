using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PlayerStats : MonoBehaviour
{
    private int level = 1;
    private float currentExp = 0;
    private float expToNextLevel = 100;

    public TextMeshProUGUI lvlText, currExpText, expToNextLvlText;

    [SerializeField]
    private string lvlString;
    [SerializeField]
    private string currExpString;
    [SerializeField]
    private string expToNextLvlString;

    public int statFreePoints = 5;
    public int STR;
    public int DEX;
    public int INT;
    public int CON;

    public TextMeshProUGUI strText, dexText, intText, conText, statText;

    [SerializeField]
    private string strString;
    [SerializeField]
    private string dexString;
    [SerializeField]
    private string intString;
    [SerializeField]
    private string conString;
    [SerializeField]
    private string statString;


    public int MaxHP;
    public int MaxMP;

    public float MeleeDamage;
    public float MagicDamage;
    public float RangeDamage;

    public float AttackSpeed;
    public float CritChance;

    public float HpRegen; // за 10 сек
    public float MpRegen; // за сек

    private void Start()
    {
        OnLoadingStats();
    }       

    public void OnStatsUpdate()
    {

        MaxHP = 100 + (CON - 10) * 5;
        MaxMP = 50 + (INT - 10) * 3;

        MeleeDamage = 10 + (STR - 10) * 0.5f;
        MagicDamage = 15 * (1 + (INT - 10) * 0.05f);
        RangeDamage = 10 + (DEX - 10) * 0.5f;

        AttackSpeed = 1.0f + (DEX - 10) * 0.02f;
        CritChance = 0.05f + (DEX - 10) * 0.003f;

        HpRegen = 2 + (CON - 10) * 0.1f; // за 10 сек
        MpRegen = 3 + (INT - 10) * 0.2f; // за сек
    }
    public void OnLoadingStats()
    {
        if (!PlayerPrefs.HasKey(currExpString)) return;

        level = PlayerPrefs.GetInt(lvlString);
        currentExp = PlayerPrefs.GetFloat(currExpString);
        expToNextLevel = PlayerPrefs.GetFloat(expToNextLvlString);

        statFreePoints = PlayerPrefs.GetInt(statString);
        STR = PlayerPrefs.GetInt(strString);
        INT = PlayerPrefs.GetInt(intString);
        DEX = PlayerPrefs.GetInt(dexString);
        CON = PlayerPrefs.GetInt(conString);

        SetupStatsInText();
    }
    public void OnSaveStats()
    {

    }
    private void SetupStatsInText()
    {
        lvlText.text = level.ToString();
        currExpText.text = currentExp.ToString();
        expToNextLvlText.text = expToNextLevel.ToString();

        strText.text = STR.ToString();
        dexText.text = DEX.ToString();
        intText.text = INT.ToString();
        conText.text = CON.ToString();
        statText.text = statFreePoints.ToString();
    }
}
