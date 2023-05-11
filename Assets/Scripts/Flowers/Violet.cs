using UnityEngine;
using UnityEngine.EventSystems;

public class Violet : Flower
{

    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _maxPollenCount = 2;
        SpawnPollens(_pollen);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        _spriteRenderer.sprite = _clickedSprite;
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        _spriteRenderer.sprite = _enteredSprite;
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        _spriteRenderer.sprite = _defaultSprite;
    }
}