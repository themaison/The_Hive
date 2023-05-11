using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
    [Range(0.1f, 10f)]
    [SerializeField] private float _smoothSpeed = 0.3f;
    [Range(1f, 10f)]
    [SerializeField] private float _cameraSpeed;
    private Vector3 _velocity;
    private Vector3 _dragOrigin;
    private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0))
        {
            transform.position = Vector3.SmoothDamp(transform.position, transform.position + _velocity, ref _velocity, _smoothSpeed/100);
            return;
        }

        Vector2 pos = _camera.ScreenToViewportPoint(_dragOrigin - Input.mousePosition);
        Vector3 move = new Vector3(pos.x * _cameraSpeed, pos.y * _cameraSpeed, 0);

        this.transform.position += move * _smoothSpeed * Time.deltaTime;
    }
}
