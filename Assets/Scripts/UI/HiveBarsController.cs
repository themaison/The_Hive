using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        _integritySlider.value = (float)Hive.currentIntegrityPoints / Hive.maxIntegrityPoints;
        _integrityText.text = "÷≈ÀŒ—“ÕŒ—“‹ " + Hive.currentIntegrityPoints.ToString() + " / " + Hive.maxIntegrityPoints.ToString();
    }

    private void SetBeeSlider()
    {
        _beeSlider.value = (float)Hive.beeOccupancy / Hive.beeCapacity;
        _beeText.text = "œ◊®À€ " + Hive.beeOccupancy.ToString() + " / " + Hive.beeCapacity.ToString();
    }

    private void SetHoneySlider()
    {
        _honeySlider.value = (float)Hive.honeyOccupancy / Hive.honeyCapacity;
        _honeyText.text = "Ã®ƒ " + Hive.honeyOccupancy.ToString() + " / " + Hive.honeyCapacity.ToString();
    }

    private void SetNectarSlider()
    {
        _nectarSlider.value = (float)Hive.nectarOccupancy / Hive.nectarCapacity;
        _nectarText.text = "Õ≈ “¿– " + Hive.nectarOccupancy.ToString() + " / " + Hive.nectarCapacity.ToString();
    }
}
