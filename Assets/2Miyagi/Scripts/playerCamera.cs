using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCamera : MonoBehaviour
{
    public Transform _yAxis;
    public Transform _xAxis;
    public float _xSence;
    public float _ySence;
    public float _limitXAxizAngle = 30;
    private Vector3 mXAxiz;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        mXAxiz = _xAxis.localEulerAngles;
    }
    private void CameraFPS()
    {
        float xCamera = Input.GetAxis("Mouse X") * -_xSence * Time.deltaTime;
        _yAxis.transform.Rotate(0, -xCamera, 0);

        float yCamera = Input.GetAxis("Mouse Y") * -_ySence * Time.deltaTime;
        var x = mXAxiz.x + yCamera;
        if (x >= -_limitXAxizAngle && x <= _limitXAxizAngle){
            mXAxiz.x = x;
            _xAxis.localEulerAngles = mXAxiz;
        }
    }
    void Update()
    {
        CameraFPS();
    }
}
