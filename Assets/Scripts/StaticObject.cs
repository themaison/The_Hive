using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class StaticObject : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] protected GameObject _hintPanel;
    [SerializeField] protected Text _nameText;

    [SerializeField] protected GameObject _borderHint;
    [SerializeField] protected Sprite _defaultSprite;
    [SerializeField] protected string _name;

    public abstract void OnPointerClick(PointerEventData eventData);
    public abstract void OnPointerEnter(PointerEventData eventData);
    public abstract void OnPointerExit(PointerEventData eventData);
}
