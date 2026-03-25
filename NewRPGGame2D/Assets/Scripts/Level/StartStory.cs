using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartStory : MonoBehaviour
{
    public Image backImage;
    public List<Sprite> backgroundImages;
    public AudioSource audioSource;
    public TextMeshProUGUI TextMeshProUGUIs;
    [TextArea]
    public List<string>  stringTextMeshProUGUIs;

    private float change;
    private int value;
    private void Start()
    {
        backImage.sprite = backgroundImages[value];
        TextMeshProUGUIs.text = stringTextMeshProUGUIs[value];
    }

    private void Update()
    {
        change += Time.deltaTime;
        if (change > 7)
        {
            change = 0;
            value++;
            OnBackChanger(value);
        }
    }
    
    private void OnBackChanger(int value)
    {
        if (value > 2)
        {
            backImage.enabled = false;
            Destroy(gameObject);
        }
        TextMeshProUGUIs.text = stringTextMeshProUGUIs[value];
        backImage.sprite = backgroundImages[value];
    }

    /*private void OnBackgroundImageDeactive()
    {
        Color color = backgroundImage.color;
        color.a = 0.5f;
        backgroundImage.color = color;
    }*/
}
