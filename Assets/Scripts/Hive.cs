using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hive : StaticObject
{
    [SerializeField] private Slider _integrityStateSlider;
    [SerializeField] private Text _integrityText;
    [SerializeField] private GameObject _upgradeMenuUI;

    [Range(1, 100)]
    [SerializeField] private int _maxIntegrity;

    private SpriteRenderer _spriteRenderer;

    private int _integrityPoints; // целостность улья
    [SerializeField] private int _beeCapacity; // вместимость пчел
    [SerializeField] private int _nectarCapacity; // вместимость нектара
    [SerializeField] private int _honeyCapacity; // вместимость меда

    private int _hiveLevel;
    private int _nectarOccupancy = 0;
    private int _honeyOccupancy = 0;
    private int _beeOccupancy = 0;


    // Start is called before the first frame update
    void Start()
    {
        CancelHiveMenu();

        _integrityPoints = _maxIntegrity;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _integrityText.text = _maxIntegrity.ToString();
        _integrityStateSlider.value = _maxIntegrity;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Restore()
    {
        // РЕАЛИЗОВАТЬ СУЧКИ
    }

    public void AddNectar(int _amount)
    {
        _nectarOccupancy += _amount;
        Debug.Log("Nectar: " + _nectarOccupancy + " / " + _nectarCapacity);
    }

    public void AddHoney(int _amount)
    {
        Debug.Log("Added new honey");
        _honeyOccupancy += _amount;
    }
    public void AddBee(int _amount)
    {
        _beeOccupancy += _amount;
        Debug.Log("Added new bee");
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (_integrityPoints > 0)
        {
            _integrityStateSlider.value = (float)_integrityPoints / _maxIntegrity;
            _integrityText.text = _integrityPoints.ToString();
            SetHiveMenu();
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

    public void CancelHiveMenu()
    {
        Time.timeScale = 1;
        _upgradeMenuUI.SetActive(false);
    }

    public void SetHiveMenu()
    {
        Time.timeScale = 0;
        _upgradeMenuUI.SetActive(true);
    }
}
