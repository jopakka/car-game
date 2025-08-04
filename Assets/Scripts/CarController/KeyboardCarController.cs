using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CarController
{
    public class KeyboardCarController : CarController
    {
        private InputAction _accelerationAction;
        private InputAction _steeringAction;
        
        protected override void Start()
        {
            base.Start();
            _accelerationAction = InputSystem.actions.FindAction("Acceleration");
            _accelerationAction.started += StartAcceleration;
            _accelerationAction.performed += HandleAcceleration;
            _accelerationAction.canceled += StopAcceleration;
            
            _steeringAction = InputSystem.actions.FindAction("Steering");
            _steeringAction.started += StartSteering;
            _steeringAction.performed += HandleSteering;
            _steeringAction.canceled += StopSteering;
        }

        private void StartAcceleration(InputAction.CallbackContext context)
        {
            Debug.Log("Start Acceleration");
        }

        private void HandleAcceleration(InputAction.CallbackContext context)
        {
            Debug.Log("Performing Acceleration");
            Accelerate(context.ReadValue<float>());
        }

        private void StopAcceleration(InputAction.CallbackContext context)
        {
            Debug.Log("Performed Acceleration");
            Accelerate(0f);
        }

        private void StartSteering(InputAction.CallbackContext context)
        {
            Debug.Log("Start Steering");
        }

        private void HandleSteering(InputAction.CallbackContext context)
        {
            Debug.Log("Performing Steering");
            Rotate(context.ReadValue<float>());
        }

        private void StopSteering(InputAction.CallbackContext context)
        {
            Debug.Log("Performed Steering");
            Rotate(0f);
        }
    }
}