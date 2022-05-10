using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCamera : MonoBehaviour
{
    public Transform _yAxis;
    public Transform _xAxis;
    public Transform _lightCamera;
    public float _xSence;
    public float _ySence;
    public float _limitXAxizAngle = 30;
    private Vector3 _mXAxiz;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _mXAxiz = _xAxis.localEulerAngles;
    }
    private void CameraFPS()
    {
        float xCamera = Input.GetAxis("Mouse X") * -_xSence * Time.deltaTime;
        _yAxis.transform.Rotate(0, -xCamera, 0);

        float yCamera = Input.GetAxis("Mouse Y") * -_ySence * Time.deltaTime;
        var x = _mXAxiz.x + yCamera;
        if (x >= -_limitXAxizAngle && x <= _limitXAxizAngle){
            _mXAxiz.x = x;
            _xAxis.localEulerAngles = _mXAxiz;
        }
        float lightCamera = Input.GetAxis("Mouse Y") * -_ySence * Time.deltaTime;
        var lightX = _mXAxiz.x + lightCamera;
        if (lightX >= -_limitXAxizAngle && x <= _limitXAxizAngle)
        {
            _mXAxiz.x = lightX;
            _lightCamera.localEulerAngles = _mXAxiz;
        }
    }
    void Update()
    {
        CameraFPS();
    }
}
