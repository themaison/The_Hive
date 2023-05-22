using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class Flower : StaticObject
{
    protected static int _flowersCount = 0;

    public static int FlowersCount
    {
        get { return _flowersCount; }
        set { _flowersCount = value; }
    }

    public int PollenCount
    {
        get { return _pollenCount; }
        set { _pollenCount = value; }
    }
    [SerializeField] protected Text _pollenText;
    [Range(1, 10)]
    [SerializeField] protected int _maxPollenCount;
    protected int _pollenCount;

    protected void InitPollenCount()
    {
        _pollenCount = Random.Range(1, _maxPollenCount + 1);
    }

    protected void SetFlowerHintPanellSettings()
    {
        _nameText.text = _name;
        string pollenName = _pollenCount > 1 ? " Õ≈ “¿–¿" : " Õ≈ “¿–";
        _pollenText.text = _pollenCount.ToString() + pollenName;
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
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
}
