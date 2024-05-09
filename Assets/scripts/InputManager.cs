using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{

    private PlayerActions playerActions;

    private PlayerActions.OnFootActions onFootActions;

    private PlayerMotor playerMotor;
    private PlayerLook playerLook;

    // Start is called before the first frame update

    private void Awake() {
        playerActions = new PlayerActions();
        onFootActions = playerActions.onFoot;
        playerMotor = GetComponent<PlayerMotor>();
        playerLook = GetComponent<PlayerLook>();
        onFootActions.Jump.performed += ctx => playerMotor.Jump();
        onFootActions.Sprint.performed += ctx => playerMotor.Sprint();
        onFootActions.Crouch.performed += ctx => playerMotor.Crouch();
        onFootActions.Shoot.performed += ctx => playerMotor.Shoot();
    }

    // Update is called once per frame
    private void FixedUpdate() {
        playerMotor.ProcessMove(onFootActions.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        playerLook.ProcessLook(onFootActions.Look.ReadValue<Vector2>());
    }

    
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        onFootActions.Enable();
    }

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
        onFootActions.Disable();
    }
}
