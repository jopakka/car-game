using System;
using UnityEngine;

namespace CarController
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CarMovement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private float _accelerationFactor;
        private float _steeringFactor;
        private float _rotationAngle;
        
        [SerializeField,  Range(0f, 1f)]
        private float driftFactor = 0.95f;
        
        [SerializeField,  Min(0f)]
        private float acceleration = 50f;
        
        [SerializeField,  Min(0f)]
        private float steeringSpeed = 50f;
        
        public delegate void OnAccelerationDelegate(float accelerationFactor);
        public event OnAccelerationDelegate OnAcceleration;
        
        public delegate void OnSteeringDelegate(float steeringFactor);
        public event OnSteeringDelegate OnSteering;

        public float AccelerationFactor
        {
            get => _accelerationFactor;
            private set
            {
                _accelerationFactor = Math.Clamp(value, -0.2f, 1f);
                OnAcceleration?.Invoke(_accelerationFactor);
            }
        }

        public float SteeringFactor
        {
            get => _steeringFactor;
            private set
            {
                _steeringFactor = Math.Clamp(value, -1f, 1f);
                OnSteering?.Invoke(_steeringFactor);
            }
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rotationAngle = transform.eulerAngles.z;
        }

        private void FixedUpdate()
        {
            HandleAcceleration();
            KillOrthogonalVelocity();
            HandleSteering();
        }

        public void Accelerate(float direction)
        {
            AccelerationFactor = direction;
        }

        public void Rotate(float direction)
        {
            SteeringFactor = direction;
        }

        private void HandleAcceleration()
        {
            _rigidbody.AddForce(transform.up * (AccelerationFactor * acceleration * Time.fixedDeltaTime));
        }

        private void HandleSteering()
        {
            var minSpeedBeforeTurning = Mathf.Clamp01(_rigidbody.linearVelocity.magnitude / 8);
            
            var localVelocity = transform.InverseTransformDirection(_rigidbody.linearVelocity);
            var direction = 1f;
            if (localVelocity.y > 0f) direction = -1f;

            _rotationAngle += SteeringFactor * steeringSpeed * minSpeedBeforeTurning * direction * Time.fixedDeltaTime;
            _rigidbody.MoveRotation(_rotationAngle);
        }

        private void KillOrthogonalVelocity()
        {
            var forwardVelocity = transform.up * Vector2.Dot(_rigidbody.linearVelocity, transform.up);
            var rightVelocity = transform.right * Vector2.Dot(_rigidbody.linearVelocity, transform.right);
            
            _rigidbody.linearVelocity = forwardVelocity + rightVelocity * driftFactor;
        }
    }
}