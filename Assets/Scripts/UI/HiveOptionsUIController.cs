using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiveOptionsUIController : MonoBehaviour
{
    [SerializeField] private GameObject HiveOptionUI;

    public void OnPanel()
    {
        HiveOptionUI.SetActive(true);
    }

    public void OffPanel()
    {
        HiveOptionUI.SetActive(false);
    }
}
