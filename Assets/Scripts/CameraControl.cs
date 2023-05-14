using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private float _zoomSpeed;
    private Camera _mainCamera;
    private float _minSize = 2.0f;
    private float _maxSize = 7.7f;

    private void Start()
    {
        _mainCamera = GetComponent<Camera>();
        _mainCamera.orthographicSize = 5;
    }

    private void Update()
    {
        float currentSize = _mainCamera.orthographicSize;
        currentSize -= Input.GetAxis("Mouse ScrollWheel") * _zoomSpeed;
        _mainCamera.orthographicSize = Mathf.Clamp(currentSize, _minSize, _maxSize);
    }
}
