using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hive : StaticObject
{
    [SerializeField] private HiveData _hiveData;

    [SerializeField] private GameObject _upgradeMenuUI;
    [SerializeField] private GameObject _exitPanel;

    private SpriteRenderer _spriteRenderer;

    public static int maxIntegrityPoints;
    public static int beeCapacity;
    public static int nectarCapacity;
    public static int honeyCapacity;

    public static int currentIntegrityPoints;
    public static int nectarOccupancy = 0;
    public static int honeyOccupancy = 0;
    public static int beeOccupancy = 0;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        CancelHiveMenu();
        _hintPanel.SetActive(false);
        _exitPanel.SetActive(false);

        maxIntegrityPoints = 100;
        beeCapacity = 10;
        nectarCapacity = 100;
        honeyCapacity = 500;

        currentIntegrityPoints = maxIntegrityPoints;
        nectarOccupancy = 0;
        honeyOccupancy = 500;
        beeOccupancy = 0;
    }

    private void Update()
    {
        beeOccupancy = Bee.beeAmount;
    }

    public void AddNectar(int amount)
    {
        nectarOccupancy += amount;
        if (nectarOccupancy > nectarCapacity)
        {
            nectarOccupancy = nectarCapacity;
        }
    }

    public void AddHoney(int amount)
    {
        honeyOccupancy += amount;
        if (honeyOccupancy > honeyCapacity)
        {
            honeyOccupancy = honeyCapacity;
        }
    }

    public void GetNectar(int amount)
    {
        if (amount > nectarOccupancy)
        {
            amount = nectarOccupancy;
        }

        nectarOccupancy -= amount;
    }

    public void TakeDamage(int amount)
    {
        currentIntegrityPoints -= amount;
        if (currentIntegrityPoints < 0)
        {
            _exitPanel.SetActive(true);
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
        _upgradeMenuUI.SetActive(false);
    }

    public void SetHiveMenu()
    {
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

    private void SetHiveStats(HiveData data)
    {
        _name = data.name;
        maxIntegrityPoints = data.maxIntegrityPoints;
        beeCapacity = data.beeCapacity;
        honeyCapacity = data.honeyCapacity;
        nectarCapacity = data.nectarCapacity;
    }

    public static void UpdateHiveStats(HiveData data)
    {
        maxIntegrityPoints = data.maxIntegrityPoints;
        beeCapacity = data.beeCapacity;
        honeyCapacity = data.honeyCapacity;
        nectarCapacity = data.nectarCapacity;
    }
}
