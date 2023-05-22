using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class FlyingEntity : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] protected GameObject _hintPanel;
    [SerializeField] private Slider _healthPointsSlider;
    [SerializeField] protected Text _nameText;

    [SerializeField] protected int _maxHealthPoints;
    [SerializeField] protected float _flightSpeed;
    [SerializeField] protected string _name;

    protected int _currentHealthPoints;

    protected abstract void Fly();

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    public virtual void TakeDamage(int damage)
    {
        _maxHealthPoints -= damage;
        UpdateHealthPointsSlider();

        if (_maxHealthPoints <= 0)
        {
            Die();
        }
    }
    
    protected virtual void SetHintPanelSettings()
    {
        _nameText.text = _name;
        _hintPanel.SetActive(false);
        UpdateHealthPointsSlider();
    }

    protected void UpdateHealthPointsSlider()
    {
        _healthPointsSlider.value = (float)_currentHealthPoints / _maxHealthPoints;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _hintPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _hintPanel.SetActive(false);
    }
}
