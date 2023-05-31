using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hive : StaticObject
{
    [SerializeField] private HiveData _hiveData;

    [SerializeField] private GameObject _hiveOptionsUIPanel;
    [SerializeField] private GameObject _exitPanel;

    private SpriteRenderer _spriteRenderer;

    public static int MaxIntegrityPoints;
    public static int BeeCapacity;
    public static int NectarCapacity;
    public static int HoneyCapacity;

    public static int CurrentIntegrityPoints;
    public static int NectarOccupancy;
    public static int HoneyOccupancy;
    public static int BeeOccupancy;

    private void Start()
    {
        LoadData(_hiveData);

        _spriteRenderer = GetComponent<SpriteRenderer>();

        _hintPanel.SetActive(false);
        _exitPanel.SetActive(false);

        CurrentIntegrityPoints = MaxIntegrityPoints;
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
        TimePause();
        _hiveOptionsUIPanel.SetActive(true);
    }

    public void TimePause()
    {
        Time.timeScale = 0;
    }
    public void ContinueTime()
    {
        Time.timeScale = 1;
    }

    private void LoadData(HiveData data)
    {
        _name = data.name;
        MaxIntegrityPoints = data.maxIntegrityPoints;
        BeeCapacity = data.beeCapacity;
        HoneyCapacity = data.honeyCapacity;
        NectarCapacity = data.nectarCapacity;
    }
}
