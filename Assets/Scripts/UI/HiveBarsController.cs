using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiveBarsController : MonoBehaviour
{
    [SerializeField] private Hive _hive;

    [SerializeField] private Slider _integritySlider;
    [SerializeField] private Slider _beeSlider;
    [SerializeField] private Slider _honeySlider;
    [SerializeField] private Slider _nectarSlider;

    [SerializeField] private Text _integrityText;
    [SerializeField] private Text _beeText;
    [SerializeField] private Text _honeyText;
    [SerializeField] private Text _nectarText;

    void Start()
    {
        
    }

    void Update()
    {
        SetIntegritySlider();
        SetBeeSlider();
        SetHoneySlider();
        SetNectarSlider();
    }

    private void SetIntegritySlider()
    {
        _integritySlider.value = (float)_hive.CurrentIntegrityPoints / _hive.MaxIntegrityPoints;
        _integrityText.text = "÷≈ÀŒ—“ÕŒ—“‹ " + _hive.CurrentIntegrityPoints.ToString() + " / " + _hive.MaxIntegrityPoints.ToString();
    }

    private void SetBeeSlider()
    {
        _beeSlider.value = (float)_hive.BeeOccupancy / _hive.BeeCapacity;
        _beeText.text = "œ◊®À€ " + _hive.BeeOccupancy.ToString() + " / " + _hive.BeeCapacity.ToString();
    }

    private void SetHoneySlider()
    {
        _honeySlider.value = (float)_hive.HoneyOccupancy / _hive.HoneyCapacity;
        _honeyText.text = "Ã®ƒ " + _hive.HoneyOccupancy.ToString() + " / " + _hive.HoneyCapacity.ToString();
    }

    private void SetNectarSlider()
    {
        _nectarSlider.value = (float)_hive.NectarOccupancy / _hive.NectarCapacity;
        _nectarText.text = "Õ≈ “¿– " + _hive.NectarOccupancy.ToString() + " / " + _hive.NectarCapacity.ToString();
    }
}
