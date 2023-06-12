using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitPanelController : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Text _titleText;
    [SerializeField] private Button _closeButton;
    [SerializeField] private AudioSource _win;
    [SerializeField] private AudioSource _gameover;

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
        if (text == "œŒ–¿∆≈Õ»≈!")
        {
            _gameover.mute = false;
            _win.mute = true;
        }
        else if (text == "œŒ¡≈ƒ¿!")
        {
            _win.mute = false;
            _gameover.mute = true;
        }
        else
        {
            _win.mute = true;
            _gameover.mute = true;
        }

        //Time.timeScale = 0;
        _titleText.text = text;
        _closeButton.interactable = false;
        _panel.SetActive(true);
    }
}
