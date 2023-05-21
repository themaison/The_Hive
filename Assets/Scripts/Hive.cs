using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hive : StaticObject
{
    [SerializeField] private GameObject _upgradeMenuUI;

    [Range(1, 100)]
    [SerializeField] private int _maxIntegrityPoints = 100;
    [SerializeField] private int _beeCapacity; // вместимость пчел
    [SerializeField] private int _nectarCapacity; // вместимость нектара
    [SerializeField] private int _honeyCapacity; // вместимость меда

    private SpriteRenderer _spriteRenderer;

    private int _integrityPoints; // целостность улья
    private int _nectarOccupancy = 0;
    private int _honeyOccupancy = 0;
    private int _beeOccupancy = 0;

    public int MaxIntegrityPoints
    {
        get { return _maxIntegrityPoints; }
    }

    public int BeeCapacity
    {
        get { return _beeCapacity; }
    }

    public int NectarCapacity
    {
        get { return _nectarCapacity; }
    }

    public int IntegrityPoints
    {
        get { return _integrityPoints; }
    }

    public int HoneyCapacity
    {
        get { return _honeyCapacity; }
    }

    public int NectarOccupancy
    {
        get { return _nectarOccupancy; }
    }

    public int HoneyOccupancy
    {
        get { return _honeyOccupancy; }
    }

    public int BeeOccupancy
    {
        get { return _beeOccupancy; }
    }

    private void Start()
    {
        CancelHiveMenu();

        _integrityPoints = _maxIntegrityPoints;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _beeOccupancy = Bee.BeeCounter;
    }

    public void Restore()
    {
        // soon
    }

    public void AddNectar(int amount)
    {
        _nectarOccupancy += amount;
        if (_nectarOccupancy > _nectarCapacity)
        {
            _nectarOccupancy = _nectarCapacity;
        }
    }

    public void AddHoney(int amount)
    {
        _honeyOccupancy += amount;
        if (_honeyOccupancy > _honeyCapacity)
        {
            _honeyOccupancy = _honeyCapacity;
        }
    }

    public void GetNectar(int amount)
    {
        if (amount > _nectarOccupancy)
        {
            amount = _nectarOccupancy;
        }

        _nectarOccupancy -= amount;
    }

    public void TakeDamage(int amount)
    {
        _integrityPoints -= amount;
        if (_integrityPoints < 0)
        {
            //GameOver();
        }
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        SetHiveMenu();
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
