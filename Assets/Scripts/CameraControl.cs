using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{

    private Vector3 mousePos;
    private Vector3 inmousePos;
    private Vector3 startPos;
    private Vector3 newPos;

    private float newX;
    private float newY;

    [SerializeField]
    private float _boostMove;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = GetComponent<Camera>();
        newPos = mainCamera.transform.position;

    }

    void Update()
    {

        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition).normalized;

        if (Input.GetMouseButtonDown(0))
        {
            newX = 0f;
            inmousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition).normalized;
            startPos = mainCamera.transform.position;

        }

        if (Input.GetMouseButtonUp(0))
        {
            inmousePos = new Vector3(0, 0, 0);

            newX = 0f;
            newY = 0f;
            startPos = mainCamera.transform.position;
        }

    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            newX = inmousePos.x - mousePos.x;
            newY = inmousePos.y - mousePos.y;

            newPos.x = startPos.x - newX;
            newPos.y = startPos.x - newY;
            mainCamera.transform.position = newPos;

        }

    }
}
