using UnityEngine;
using UnityEngine.EventSystems;

public class Violet : Flower
{
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _borderHint.SetActive(false);
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _maxPollenCount = 2;
        InitPollenCount();
    }

    private void Update()
    {

    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        _borderHint.SetActive(true);
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        _borderHint.SetActive(true);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        _borderHint.SetActive(false);
    }
}
