using UnityEngine;
using UnityEngine.EventSystems;

public class Tree : StaticObject
{
    private SpriteRenderer _spriteRenderer;
    private float _defaultTransparency = 1;
    private float _enteredTransparency = 0.5f;

    public override void OnPointerClick(PointerEventData eventData)
    {
        _spriteRenderer.color = new Color(255, 255, 255, _defaultTransparency);
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        _spriteRenderer.color = new Color(255, 255, 255, _enteredTransparency);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        _spriteRenderer.color = new Color(255, 255, 255, _defaultTransparency);
    }

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
