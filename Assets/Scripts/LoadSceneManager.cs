using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneManager : MonoBehaviour
{
    public static LoadSceneManager instance;
    [SerializeField] private GameObject _loaderCanvas;
    [SerializeField] private Slider _progressSlider;

    private float _targetProgress;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public async void LoadScene(string sceneName)
    {
        _progressSlider.value = 0;
        _targetProgress = 0;

        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        _loaderCanvas.SetActive(true);

        do
        {
            await Task.Delay(200);
            _targetProgress = scene.progress;
        } while (scene.progress < 0.9f);

        scene.allowSceneActivation = true;
        _loaderCanvas.SetActive(false);
    }

    void Update()
    {
        _progressSlider.value = Mathf.MoveTowards(_progressSlider.value, _targetProgress, 3 * Time.deltaTime);
    }
}
