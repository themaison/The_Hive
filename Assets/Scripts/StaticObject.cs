using UnityEngine;
using UnityEngine.EventSystems;

public abstract class StaticObject : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] protected GameObject _borderHint;
    [SerializeField] protected Sprite _defaultSprite;

    public abstract void OnPointerClick(PointerEventData eventData);
    public abstract void OnPointerEnter(PointerEventData eventData);
    public abstract void OnPointerExit(PointerEventData eventData);
}
