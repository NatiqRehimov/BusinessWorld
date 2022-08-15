using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float motorForce;
    private float steeringAngle;
    private float maxSteerAngle=30;
    private Vector2 inputs;
    [SerializeField] private WheelCollider[] wheelsC;
    [SerializeField] private Transform[] wheelT;
    [SerializeField] private Text speed; 

    private void FixedUpdate()
    {
        inputs.x = Input.GetAxis("Horizontal");
        inputs.y = Input.GetAxis("Vertical");
        Steer();
        Accelerate();
        UpdateWheelPoses(wheelsC,wheelT);
        CarParametersInUI();
    }
    private void Accelerate()
    {
        wheelsC[0].motorTorque = inputs.y * motorForce;
        wheelsC[1].motorTorque = inputs.y * motorForce;
    }
    private void Steer()
    {
        steeringAngle = inputs.x*maxSteerAngle;
        wheelsC[0].steerAngle =steeringAngle;
        wheelsC[1].steerAngle =steeringAngle;
    }
    private void UpdateWheelPoses(WheelCollider[] _wheels,Transform[] _points)
    {
        for (int i = 0; i < _wheels.Length; i++)
        {
            Vector3 _pos = _points[i].position;
            Quaternion _quat = _points[i].rotation;
            
            _wheels[i].GetWorldPose(out _pos, out _quat);

            _points[i].position = _pos;
            _points[i].rotation = _quat;
        }
    }
    private void CarParametersInUI()
    {
        speed.text = Mathf.Round(rb.velocity.magnitude)*5+"";
    }
}
