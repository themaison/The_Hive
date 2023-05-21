using UnityEngine;
using UnityEngine.EventSystems;

public class Barrel : StaticObject, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Sprite _honeyBarrelSprite;
    [SerializeField] private Sprite _openedBarrelSprite;

    [Range(1, 100)]
    [SerializeField] private int _honeyCapacity;
    private int _honeyOccupancy = 0;

    private Hive _hive;
    private SpriteRenderer _spriteRenderer;

    private bool _isOpened;

    void Start()
    {
        _borderHint.SetActive(false);
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _hive = FindObjectOfType<Hive>();

        _isOpened = false;
    }
    void Update()
    {
        if (!_isOpened)
        {
            SpriteRender();
        }
    }

    public void AddHoney(int amount)
    {
        _honeyOccupancy += amount;
        if (_honeyOccupancy > _honeyCapacity)
        {
            _honeyOccupancy = _honeyCapacity;
        }
        //Debug.Log("BARREL:Honey: " + _honeyOccupancy + " / " + _honeyCapacity);
    }

    public int GetHoney()
    {
        return _honeyOccupancy;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isOpened = true;

        _borderHint.SetActive(false);
        _spriteRenderer.sprite = _openedBarrelSprite;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isOpened = false;

        _borderHint.SetActive(true);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (_honeyOccupancy > 0)
        {
            _hive.AddHoney(_honeyOccupancy);
            _honeyOccupancy = 0;
        }
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        _borderHint.SetActive(true);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        _borderHint.SetActive(false);
    }

    private void SpriteRender()
    {
        if (_honeyOccupancy > 0)
        {
            _spriteRenderer.sprite = _honeyBarrelSprite;
        }
        else
        {
            _spriteRenderer.sprite = _defaultSprite;
        }
    }
}
