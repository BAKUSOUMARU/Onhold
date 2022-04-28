using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCamera : MonoBehaviour
{
    public Transform yAxis;
    public Transform xAxis;
    public float xSence;
    public float ySence;
    public float limitXAxizAngle = 30;
    private Vector3 mXAxiz;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        mXAxiz = xAxis.localEulerAngles;
    }
    private void cameraFPS()
    {
        float xCamera = Input.GetAxis("Mouse X") * -xSence * Time.deltaTime;
        yAxis.transform.Rotate(0, -xCamera, 0);

        float yCamera = Input.GetAxis("Mouse Y") * -ySence * Time.deltaTime;
        var x = mXAxiz.x + yCamera;
        if (x >= -limitXAxizAngle && x <= limitXAxizAngle)
        {
            mXAxiz.x = x;
            xAxis.localEulerAngles = mXAxiz;
        }
    }
    void Update()
    {
        cameraFPS();
    }
}
