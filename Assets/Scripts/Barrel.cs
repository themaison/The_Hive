using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Barrel : StaticObject, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private BarellData _barellData;

    [SerializeField] private Text _honeyText;

    [SerializeField] private Sprite _honeyBarrelSprite;
    [SerializeField] private Sprite _openedBarrelSprite;

    private int _honeyCapacity;
    private int _honeyOccupancy = 0;

    public int HoneyCapacity
    {
        get { return _honeyCapacity; }
    }

    private Hive _hive;
    private SpriteRenderer _spriteRenderer;

    private bool _isOpened;

    void Start()
    {
        SetBarellStats(_barellData);

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _hive = FindObjectOfType<Hive>();

        _borderHint.SetActive(false);
        _isOpened = false;

        _nameText.text = _name;

        UpdateBarrelHintPanell();
        _hintPanel.SetActive(false);
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

        UpdateBarrelHintPanell();
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

        UpdateBarrelHintPanell();
        _hintPanel.SetActive(true);
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        _borderHint.SetActive(true);
        _hintPanel.SetActive(true);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        _borderHint.SetActive(false);
        _hintPanel.SetActive(false);
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

    protected void UpdateBarrelHintPanell()
    {
        _nameText.text = _name;
        _honeyText.text = _honeyOccupancy.ToString() + " / " + _honeyCapacity.ToString();
    }

    private void SetBarellStats(BarellData barellData)
    {
        _name = barellData.name;
        _honeyCapacity = barellData.honeyCapacity;
    }
}
