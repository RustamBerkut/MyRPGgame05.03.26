using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartStory : MonoBehaviour
{
    public Image backImage;
    public List<Sprite> backgroundImages;
    public AudioSource audioSource;
    public TextMeshProUGUI TextMeshProUGUI;

    private float change;
    private int value;
    private void Start()
    {
        backImage.sprite = backgroundImages[value];
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
        backImage.sprite = backgroundImages[value];
    }

    /*private void OnBackgroundImageDeactive()
    {
        Color color = backgroundImage.color;
        color.a = 0.5f;
        backgroundImage.color = color;
    }*/
}
