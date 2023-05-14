using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeOptionsUIController : MonoBehaviour
{
    [SerializeField] private GameObject BeeOptionsUI;

    public void OnPanel()
    {
        BeeOptionsUI.SetActive(true);
    }

    public void OffPanel()
    {
        BeeOptionsUI.SetActive(false);
    }
}
