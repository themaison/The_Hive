using UnityEngine;
using UnityEngine.EventSystems;

public abstract class StaticObject : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] protected Sprite _defaultSprite;
    [SerializeField] protected Sprite _enteredSprite;
    [SerializeField] protected Sprite _clickedSprite;
    public abstract void OnPointerClick(PointerEventData eventData);
    public abstract void OnPointerEnter(PointerEventData eventData);
    public abstract void OnPointerExit(PointerEventData eventData);
}
