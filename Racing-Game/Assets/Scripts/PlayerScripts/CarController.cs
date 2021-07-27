using UnityEngine;

public class CarController : MonoBehaviour  {

    
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    [Header("Components")]
    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider backLeftWheelCollider;
    [SerializeField] private WheelCollider backRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform backLeftWheelTransform;
    [SerializeField] private Transform backRightWheelTransform;
    [SerializeField] private Vector3 com;
    [SerializeField] private Rigidbody myRB;


    [Header("Settings")]
    [SerializeField] private float motorSpeed;
    [SerializeField] private float maxSteeringAngle;
    [SerializeField] private float breakForce;

    private float horizontalInput;
    private float verticalInput;
    private bool isBreaking;
    private float currentBreakForce;
    private float currentSteerAngle;
    private FinishLine _finishLine;


    private void Start() {
        SetComponents();
    }

    private void FixedUpdate() {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void HandleMotor(){
        frontLeftWheelCollider.motorTorque = verticalInput * motorSpeed;
        frontRightWheelCollider.motorTorque = verticalInput * motorSpeed;
        breakForce = isBreaking ? breakForce : 0f;

        if(isBreaking){
            ApplyBreaking();
        }
    }

    private void ApplyBreaking(){
        frontRightWheelCollider.brakeTorque = currentBreakForce;
        frontLeftWheelCollider.brakeTorque = currentBreakForce;
        backRightWheelCollider.brakeTorque = currentBreakForce;
        backLeftWheelCollider.brakeTorque = currentBreakForce;
    }

    private void GetInput(){
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleSteering(){
        currentSteerAngle = maxSteeringAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;

        if (!isBreaking)
        {
            frontRightWheelCollider.brakeTorque = frontLeftWheelCollider.brakeTorque = backRightWheelCollider.brakeTorque = backLeftWheelCollider.brakeTorque = 0f;
        }
    }

    private void UpdateWheels(){
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(backLeftWheelCollider, backLeftWheelTransform);
        UpdateSingleWheel(backRightWheelCollider, backRightWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform){
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

    private void SetComponents(){
        myRB.centerOfMass = com;
    }

}