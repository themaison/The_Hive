using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hive : StaticObject
{
    [SerializeField] private GameObject _upgradeMenuUI;

    private SpriteRenderer _spriteRenderer;

    [SerializeField] private int _maxIntegrityPoints;
    [SerializeField] private int _beeCapacity;
    [SerializeField] private int _nectarCapacity;
    [SerializeField] private int _honeyCapacity;

    private int _currentIntegrityPoints;
    private int _nectarOccupancy = 0;
    private int _honeyOccupancy = 0;
    private int _beeOccupancy = 0;

    public int CurrentIntegrityPoints => _currentIntegrityPoints;
    public int NectarOccupancy => _nectarOccupancy;
    public int HoneyOccupancy => _honeyOccupancy;
    public int BeeOccupancy => _beeOccupancy;

    public int BeeCapacity => _beeCapacity;
    public int NectarCapacity => _nectarCapacity;
    public int HoneyCapacity => _honeyCapacity;
    public int MaxIntegrityPoints => _maxIntegrityPoints;


    private void Start()
    {
        CancelHiveMenu();

        _currentIntegrityPoints = _maxIntegrityPoints;
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _hintPanel.SetActive(false);
    }

    private void Update()
    {
        _beeOccupancy = Bee.beeAmount;
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
        _currentIntegrityPoints -= amount;
        if (_currentIntegrityPoints < 0)
        {
            //GameOver();
        }
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        SetHiveMenu();
        _borderHint.SetActive(true);
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

    public void CancelHiveMenu()
    {
        ContinueTime();
        _upgradeMenuUI.SetActive(false);
    }

    public void SetHiveMenu()
    {
        TimePause();
        _upgradeMenuUI.SetActive(true);
    }

    public void TimePause()
    {
        Time.timeScale = 0;
    }
    public void ContinueTime()
    {
        Time.timeScale = 1;
    }
}
