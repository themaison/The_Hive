using UnityEngine;
using UnityEngine.EventSystems;

public class Chamomile : Flower
{
    [SerializeField] private FlowerData _flowerData;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        SetFlowerData(_flowerData);

        _spriteRenderer = GetComponent<SpriteRenderer>();

        InitPollenCount();
        SetFlowerHintPanellSettings();

        _borderHint.SetActive(false);
        _hintPanel.SetActive(false);
    }
}
