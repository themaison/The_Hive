using UnityEngine;
using UnityEngine.EventSystems;

public class Violet : Flower
{
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        InitPollenCount();
        SetFlowerHintPanellSettings();

        _borderHint.SetActive(false);
        _hintPanel.SetActive(false);
    }

    private void Update()
    {

    }
}
