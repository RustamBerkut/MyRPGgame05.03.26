using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentList : MonoBehaviour
{
    public List<Sprite> listSprites;

    
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void SetupItemInSlot(int value)
    {
        int num = value;
        spriteRenderer.sprite = listSprites[num];
    }
}
