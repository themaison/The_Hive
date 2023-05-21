using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hive : StaticObject
{
    [SerializeField] private GameObject _upgradeMenuUI;

    [Range(1, 100)]
    [SerializeField] private int _maxIntegrity;
    [SerializeField] private int _beeCapacity; // вместимость пчел
    [SerializeField] private int _nectarCapacity; // вместимость нектара
    [SerializeField] private int _honeyCapacity; // вместимость меда

    private SpriteRenderer _spriteRenderer;

    private int _integrityPoints; // целостность улья
    private int _nectarOccupancy = 0;
    private int _honeyOccupancy = 0;
    private int _beeOccupancy = 0;

    public int NectarOccupancy
    {
        get { return _nectarOccupancy; }
        set { _nectarOccupancy = value; }
    }

    public int HoneyOccupancy
    {
        get { return _honeyOccupancy; }
        set { _honeyOccupancy = value; }
    }

    public int BeeOccupancy
    {
        get { return _beeOccupancy; }
        set { _beeOccupancy = value; }
    }

    private void Start()
    {
        CancelHiveMenu();

        _integrityPoints = _maxIntegrity;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

    }

    public void Restore()
    {
        // soon
    }

    public void AddNectar(int _amount)
    {
        _nectarOccupancy += _amount;
        Debug.Log("HIVE:Nectar: " + _nectarOccupancy + " / " + _nectarCapacity);
    }

    public void AddHoney(int _amount)
    {
        _honeyOccupancy += _amount;
        Debug.Log("HIVE:Honey: " + _honeyOccupancy + " / " + _honeyCapacity);
    }
    public void AddBee(int _amount)
    {
        _beeOccupancy += _amount;
        Debug.Log("HIVE:Bees: " + _beeOccupancy + " / " + _beeCapacity);
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
