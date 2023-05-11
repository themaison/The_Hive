using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hive : StaticObject
{
    [SerializeField] private Slider _integrityStateSlider;
    [SerializeField] private Text _integrityText;

    [Range(1, 100)]
    [SerializeField] private int _integrity;

    private SpriteRenderer _spriteRenderer;

    private int _integrityPoints; // öåëîñòíîñòü óëüÿ
    private int _beeCapacity; // âìåñòèìîñòü ï÷åë
    private int _nectarÑapacity; // âìåñòèìîñòü íåêòàğà
    private int _honeyÑapacity; // âìåñòèìîñòü ìåäà
    private int _hiveLevel;


    // Start is called before the first frame update
    void Start()
    {
        _integrityPoints = _integrity;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _integrityText.text = _integrity.ToString();
        _integrityStateSlider.value = _integrity;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Restore()
    {
        // ĞÅÀËÈÇÎÂÀÒÜ ÑÓ×ÊÈ
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Open Hive Menu");
        if (_integrityPoints > 0)
        {
            _integrityPoints -= 1;
            _integrityStateSlider.value = (float)_integrityPoints / _integrity;
            _integrityText.text = _integrityPoints.ToString();
        }
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
