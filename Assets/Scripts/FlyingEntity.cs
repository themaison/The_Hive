using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class FlyingEntity : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] protected GameObject _hintPanel;
    [SerializeField] protected Text _nameText;

    [SerializeField] private Slider _healthPointsSlider;

    protected int _maxHealthPoints;
    protected float _flightSpeed;
    protected string _name;

    protected int _currentHealthPoints;

    protected abstract void Fly();

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    public virtual void TakeDamage(int damage)
    {
        _currentHealthPoints -= damage;
        _currentHealthPoints = Mathf.Clamp(_currentHealthPoints, 0, _maxHealthPoints);

        UpdateHealthPointsSlider();

        if (_currentHealthPoints <= 0)
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
        //Change Text
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
