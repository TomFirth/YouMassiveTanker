using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Turret : MonoBehaviour
{
    public Rigidbody TurretRb;
    Vector2 turretMovement;

    public float acceleration = 1000f;
    public float brakeForce = 10000f;
    private float currentLeftAcceleration = 0f;
    private float currentLeftBrakeForce = 0f;
    private float currentRightAcceleration = 0f;
    private float currentRightBrakeForce = 0f;
    private void FixedUpdate()
    {
        var gamepad = Gamepad.current;
        turretMovement = gamepad.rightStick.ReadValue();
        // Debug.Log("turret" + turretMovement.y);
        TurretRb.rotation = Quaternion.Euler(turretMovement.y * 10000 * Time.deltaTime, turretMovement.x * 10000 * Time.deltaTime, 0);
    }
}
