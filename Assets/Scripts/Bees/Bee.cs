using UnityEngine;
using UnityEngine.UI;

public abstract class Bee : FlyingEntity
{
    public static int beeAmount = 0;

    [SerializeField] private Slider _satietyPointsSlider;

    protected int _maxSatietyPoints;
    protected int _HRR; // health regeneration rate

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
