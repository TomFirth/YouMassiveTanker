using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    Vector2 movement, vision;
    float rightTrigger, leftTrigger, topSpeed = 25f;
    [SerializeField] WheelCollider lone, ltwo, lthree, lfour;
    [SerializeField] WheelCollider rone, rtwo, rthree, rfour;

    public float acceleration = 1000f;
    public float brakeForce = 10000f;
    private float currentLeftAcceleration = 0f;
    private float currentLeftBrakeForce = 0f;
    private float currentRightAcceleration = 0f;
    private float currentRightBrakeForce = 0f;

    private void FixedUpdate() {
        var gamepad = Gamepad.current;
        if (gamepad == null)
            return; // No gamepad connected.

        movement = gamepad.leftStick.ReadValue();
        if (rb.velocity.magnitude > topSpeed) {
            rb.velocity = rb.velocity.normalized * topSpeed;
        }

        leftTrigger = gamepad.leftTrigger.ReadValue();
        if (leftTrigger > 0) {
            // Debug.Log("lt-on");
            currentLeftAcceleration = acceleration;
            currentLeftBrakeForce = 0f;
        } else {
            // Debug.Log("lt-off");
            currentLeftAcceleration = 0f;
            currentLeftBrakeForce = brakeForce;
        }
        rightTrigger = gamepad.rightTrigger.ReadValue();
        if (rightTrigger > 0) {
            // Debug.Log("rt-on");
            currentRightAcceleration = acceleration;
            currentRightBrakeForce = 0f;
        } else {
            // Debug.Log("rt-off");
            currentRightAcceleration = 0f;
            currentRightBrakeForce = brakeForce;
        }

        lone.motorTorque = currentLeftAcceleration;
        ltwo.motorTorque = currentLeftAcceleration;
        lthree.motorTorque = currentLeftAcceleration;
        lfour.motorTorque = currentLeftAcceleration;
        lone.brakeTorque = currentLeftBrakeForce;
        ltwo.brakeTorque = currentLeftBrakeForce;
        lthree.brakeTorque = currentLeftBrakeForce;
        lfour.brakeTorque = currentLeftBrakeForce;

        rone.motorTorque = currentRightAcceleration;
        rtwo.motorTorque = currentRightAcceleration;
        rthree.motorTorque = currentRightAcceleration;
        rfour.motorTorque = currentRightAcceleration;
        rone.brakeTorque = currentRightBrakeForce;
        rtwo.brakeTorque = currentRightBrakeForce;
        rthree.brakeTorque = currentRightBrakeForce;
        rfour.brakeTorque = currentRightBrakeForce;

        if (gamepad.buttonNorth.isPressed || gamepad.dpad.up.isPressed) {
            transform.rotation = Quaternion.identity;
            rb.velocity = new Vector3(0f, 0f, 0f);
            currentLeftAcceleration = 0f;
            currentLeftBrakeForce = 0f;
            currentRightAcceleration = 0f;
            currentRightBrakeForce = 0f;
        }
    }

    void UpdateWheel(WheelCollider collider, Transform transform) {
        Vector3 position;
        Quaternion rotation;

        collider.GetWorldPose(out position, out rotation);
        transform.position = position;
        transform.rotation = rotation * Quaternion.Euler(0f, 0f, 90f);
    }
}
