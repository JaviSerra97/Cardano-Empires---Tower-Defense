using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float panSpeed;
    [SerializeField] private float zoomSpeed;

    [Header("Pan Limits")]
    [SerializeField] private float topLimit;
    [SerializeField] private float botLimit;
    [SerializeField] private float rightLimit;
    [SerializeField] private float leftLimit;

    [Header("Pan Limits")]
    [SerializeField] private float maxZoom;
    [SerializeField] private float minZoom;

    [SerializeField] private Color limitColor;

    private float width;
    private float height;

    private void Start()
    {
        CalculateScreenSize();
    }

    private void Update()
    {
        PanCamera();
        ZoomCamera();
    }

    void PanCamera()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");

        if(transform.position.x + width >= rightLimit)
        {
            if (h > 0) { h = 0; }
            transform.position = new Vector3(rightLimit - width, transform.position.y, transform.position.z);
        }
        if(transform.position.x - width <= leftLimit) 
        {
            if (h < 0) { h = 0; }
            transform.position = new Vector3(leftLimit + width, transform.position.y, transform.position.z);
        }
        if (transform.position.y + height >= topLimit)
        {
            if (v > 0) { v = 0; }
            transform.position = new Vector3(transform.position.x, topLimit - height, transform.position.z);
        }
        if(transform.position.y - height <= botLimit)
        {
            if (v < 0) { v = 0; }
            transform.position = new Vector3(transform.position.x, botLimit + height, transform.position.z);
        }

        if (h != 0 || v != 0)
        {
            transform.position += new Vector3(h, v, 0) * panSpeed * Time.deltaTime;
        }
    }

    void ZoomCamera()
    {
        if(Input.mouseScrollDelta.y > 0)
        {
            if(Camera.main.orthographicSize > minZoom)
            {
                Camera.main.orthographicSize -= minZoom * zoomSpeed * Time.deltaTime;
            }
            else { Camera.main.orthographicSize = minZoom; }

            CalculateScreenSize();
        }

        if (Input.mouseScrollDelta.y < 0)
        {
            if (Camera.main.orthographicSize < maxZoom)
            {
                Camera.main.orthographicSize += maxZoom * zoomSpeed * Time.deltaTime;
            }
            else
            {
                Camera.main.orthographicSize = maxZoom;
            }

            CalculateScreenSize();
        }
    }

    void CalculateScreenSize()
    {
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
    }

    #region GIZMOS
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = limitColor;

        Gizmos.DrawLine(new Vector3(leftLimit, botLimit), new Vector3(leftLimit, topLimit));
        Gizmos.DrawLine(new Vector3(rightLimit, botLimit), new Vector3(rightLimit, topLimit));
        Gizmos.DrawLine(new Vector3(rightLimit, topLimit), new Vector3(leftLimit, topLimit));
        Gizmos.DrawLine(new Vector3(rightLimit, botLimit), new Vector3(leftLimit, botLimit));
    }
    #endregion
}
