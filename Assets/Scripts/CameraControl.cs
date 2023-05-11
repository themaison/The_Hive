using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
    [Range(1f, 10f)]
    [SerializeField] private float _smoothSpeed;
    [Range(1f, 10f)]
    [SerializeField] private float _cameraSpeed;
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

        if (!Input.GetMouseButton(0)) return;

        Vector2 pos = _camera.ScreenToViewportPoint(_dragOrigin - Input.mousePosition);
        Vector3 move = new Vector3(pos.x * _cameraSpeed, pos.y * _cameraSpeed, 0);

        this.transform.position += move * _smoothSpeed * Time.deltaTime;
    }
}
