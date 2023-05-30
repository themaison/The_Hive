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

    public static int MaxIntegrityPoints;
    public static int BeeCapacity;
    public static int NectarCapacity;
    public static int HoneyCapacity;

    public static int CurrentIntegrityPoints;
    public static int NectarOccupancy = 0;
    public static int HoneyOccupancy = 0;
    public static int BeeOccupancy = 0;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _hintPanel.SetActive(false);
        _exitPanel.SetActive(false);

        MaxIntegrityPoints = 100;
        BeeCapacity = 10;
        NectarCapacity = 100;
        HoneyCapacity = 500;

        CurrentIntegrityPoints = MaxIntegrityPoints;
        HoneyOccupancy = 500;
    }

    private void Update()
    {
        BeeOccupancy = Bee.beeAmount;
    }

    public void AddNectar(int amount)
    {
        NectarOccupancy += amount;
        if (NectarOccupancy > NectarCapacity)
        {
            NectarOccupancy = NectarCapacity;
        }
    }

    public void AddHoney(int amount)
    {
        HoneyOccupancy += amount;
        if (HoneyOccupancy > HoneyCapacity)
        {
            HoneyOccupancy = HoneyCapacity;
        }
    }

    public int GetNectar(int amount)
    {
        if(amount > NectarOccupancy)
        {
            amount = NectarOccupancy;
        }

        NectarOccupancy -= amount;
        return amount;
    }

    public void TakeDamage(int amount)
    {
        CurrentIntegrityPoints -= amount;
        if (CurrentIntegrityPoints < 0)
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
        MaxIntegrityPoints = data.maxIntegrityPoints;
        BeeCapacity = data.beeCapacity;
        HoneyCapacity = data.honeyCapacity;
        NectarCapacity = data.nectarCapacity;
    }

    public static void UpdateHiveStats(HiveData data)
    {
        MaxIntegrityPoints = data.maxIntegrityPoints;
        BeeCapacity = data.beeCapacity;
        HoneyCapacity = data.honeyCapacity;
        NectarCapacity = data.nectarCapacity;
    }
}
