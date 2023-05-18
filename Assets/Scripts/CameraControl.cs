using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.UIElements;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private float _minSize = 2.0f;
    [SerializeField] private float _maxSize = 7.7f;
    [SerializeField] private float _defaultSize = 5.0f;

    [SerializeField] private float _zoomSpeed = 1.0f;
    [SerializeField] private float _moveSpeed = 1.0f;
    //[SerializeField] private float _smoothTime = 0.5f;

    [SerializeField] SpriteRenderer _mapRenderer;

    private Camera _cam;
    private Vector3 _dragOrigin;
    private float _mapMinX, _mapMaxX, _mapMinY, _mapMaxY;

    //float _velocity = 1;

    private void Start()
    {
        _cam = GetComponent<Camera>();
        _cam.orthographicSize = _defaultSize;
    }

    private void Awake()
    {
        _mapMinX = _mapRenderer.transform.position.x - _mapRenderer.bounds.size.x / 2f;
        _mapMaxX = _mapRenderer.transform.position.x + _mapRenderer.bounds.size.x / 2f;
        _mapMinY = _mapRenderer.transform.position.y - _mapRenderer.bounds.size.y / 2f;
        _mapMaxY = _mapRenderer.transform.position.y + _mapRenderer.bounds.size.y / 2f;
    }

    private void Update()
    {
        MoveCamera();
        ZoomCamera();

        _cam.transform.position = ClampCamera(_cam.transform.position);
    }

    private void MoveCamera()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _dragOrigin = _cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 difference = _dragOrigin - _cam.ScreenToWorldPoint(Input.mousePosition);
            _cam.transform.position += difference * Time.deltaTime * _moveSpeed;
        }
    }

    private void ZoomCamera()
    {
        float scrollValue = Input.GetAxis("Mouse ScrollWheel");

        if (scrollValue != 0)
        {
            float currentSize = _cam.orthographicSize;
            currentSize -= scrollValue * _zoomSpeed;
            currentSize = Mathf.Clamp(currentSize, _minSize, _maxSize);
            _cam.orthographicSize = currentSize;
            //_cam.orthographicSize = Mathf.SmoothDamp(_cam.orthographicSize, currentSize, ref _velocity, _smoothTime);

            float cursorDistance = Vector3.Distance(_cam.transform.position, _cam.ScreenToWorldPoint(Input.mousePosition));
            _cam.transform.position = Vector3.MoveTowards(_cam.transform.position, _cam.ScreenToWorldPoint(Input.mousePosition), cursorDistance * scrollValue);
        }
    }

    private Vector3 ClampCamera(Vector3 targetPosition)
    {
        float camHeight = _cam.orthographicSize;
        float camWidth = _cam.orthographicSize * _cam.aspect;

        float minX = _mapMinX + camWidth;
        float maxX = _mapMaxX - camWidth;
        float minY = _mapMinY + camHeight;
        float maxY = _mapMaxY - camHeight;

        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3 (newX, newY, targetPosition.z);
    }
}
