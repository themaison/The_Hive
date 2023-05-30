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

    void Update()
    {
        SetIntegritySlider();
        SetBeeSlider();
        SetHoneySlider();
        SetNectarSlider();
    }

    private void SetIntegritySlider()
    {
        _integritySlider.value = (float)Hive.CurrentIntegrityPoints / Hive.MaxIntegrityPoints;
        _integrityText.text = "����������� " + Hive.CurrentIntegrityPoints.ToString() + " / " + Hive.MaxIntegrityPoints.ToString();
    }

    private void SetBeeSlider()
    {
        _beeSlider.value = (float)Hive.BeeOccupancy / Hive.BeeCapacity;
        _beeText.text = "�ר�� " + Hive.BeeOccupancy.ToString() + " / " + Hive.BeeCapacity.ToString();
    }

    private void SetHoneySlider()
    {
        _honeySlider.value = (float)Hive.HoneyOccupancy / Hive.HoneyCapacity;
        _honeyText.text = "̨� " + Hive.HoneyOccupancy.ToString() + " / " + Hive.HoneyCapacity.ToString();
    }

    private void SetNectarSlider()
    {
        _nectarSlider.value = (float)Hive.NectarOccupancy / Hive.NectarCapacity;
        _nectarText.text = "������ " + Hive.NectarOccupancy.ToString() + " / " + Hive.NectarCapacity.ToString();
    }
}
