using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerIcons : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Color buttonPressedColor;
    public Color grabbedColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ShowButton(Color color)
    {
        spriteRenderer.enabled = true;
        spriteRenderer.color = color;
    }

    public void HideButton()
    {
        spriteRenderer.enabled = false;
    }
}
