using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiveUpgradeUIController : MonoBehaviour
{
    [SerializeField] private GameObject HiveUpgradeUI;

    public void OnPanel()
    {
        HiveUpgradeUI.SetActive(true);
    }

    public void OffPanel()
    {
        HiveUpgradeUI.SetActive(false);
    }
}
