using UnityEngine;
using UnityEngine.UI;

public abstract class Bee : FlyingEntity
{
    protected static int _beeCounter = 0;
    public static int BeeCounter
    {
        get { return _beeCounter; }
        set { _beeCounter = value; }
    }

    [SerializeField] private Slider _satietyPointsSlider;

    [SerializeField] protected int _maxSatietyPoints;
    [SerializeField] protected int _HRR; // health regeneration rate

    protected int _currentSatietyPoints;

    protected virtual void Eat()
    {
       // soon
    }

    protected virtual void Regenerate()
    {
        // soon
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
}
