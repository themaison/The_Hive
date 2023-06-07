using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitPanelController : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Text _titleText;
    [SerializeField] private Button _closeButton;

    public void ShowPaneleByText(string text)
    {
        _titleText.text = text;
        _panel.SetActive(true);
    }
    public void HidePanel()
    {
        _panel.SetActive(false);
    }

    public void ShowResultPanel(string text)
    {
        Time.timeScale = 0;
        _titleText.text = text;
        _closeButton.interactable = false;
        _panel.SetActive(true);
    }
}
