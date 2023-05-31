using UnityEngine;
using UnityEngine.UI;

public abstract class Bee : FlyingEntity
{
    public static int beeAmount = 0;

    [SerializeField] private Slider _satietyPointsSlider;

    protected int _maxSatietyPoints;
    protected int _currentSatietyPoints;

    protected const float _hungerDelay = 6;
    protected const float _hungerDelayBoost = 3;

    protected const int _hungerDamage = 1;
    protected const int _hungerHealthDamage = 1;

    protected const float _regenerateInterval = 1;
    protected const int _regenerateValue = 1;   
    protected float _lastRegenerateTime;

    protected const float _eatDelay = 7;
    protected const int _nectarToSatiety = 3;   

    protected Hive _hive;

    protected void UpdateHungerProcess(float delay)
    {
        CancelInvoke("DecreaseSatiety");
        InvokeRepeating("DecreaseSatiety", 0.5f, delay);
    }

    protected void UpdateEatingProcess(float delay)
    {
        CancelInvoke("Eat");
        InvokeRepeating("Eat", 0.5f, delay);
    }

    protected virtual void DecreaseSatiety()
    {
        if (_currentSatietyPoints > 0)
        {
            _currentSatietyPoints -= _hungerDamage;
            UpdateSatietyPointsSlider();
        }
        else
        {
            TakeDamage(_hungerHealthDamage);
        }
    }

    protected virtual void Eat()
    {
        if (_currentSatietyPoints < _maxSatietyPoints)
        {
            int needSatiety = _maxSatietyPoints - _currentSatietyPoints;
            int needNectar = needSatiety / _nectarToSatiety;
            if (needNectar > 0)
            {
                _currentSatietyPoints += _hive.GetNectar(needNectar) * _nectarToSatiety;
            }
            UpdateSatietyPointsSlider();
        }
    }

    protected virtual void Regenerate()
    {
        if (_currentHealthPoints < _maxHealthPoints && _currentSatietyPoints > 0)
        {
            float percent = (float)_currentSatietyPoints / _maxSatietyPoints;
            float interval = _regenerateInterval * (2 - percent);

            if (Time.time - _lastRegenerateTime > interval)
            {
                _currentHealthPoints += _regenerateValue;
                UpdateHealthPointsSlider();

                if (_currentHealthPoints > _maxHealthPoints)
                {
                    _currentHealthPoints = _maxHealthPoints;
                }

                _lastRegenerateTime = Time.time;
            }
        }
    }

    protected void UpdateSatietyPointsSlider()
    {
        _satietyPointsSlider.value = (float)_currentSatietyPoints / _maxSatietyPoints;
    }

    protected override void SetHintPanelSettings()
    {
        base.SetHintPanelSettings();
        UpdateSatietyPointsSlider();
    }

    protected override void Die()
    {
        base.Die();
        beeAmount -= 1;
    }
}
