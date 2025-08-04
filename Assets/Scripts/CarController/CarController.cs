using System;
using UnityEngine;

namespace CarController
{
    [RequireComponent(typeof(CarMovement))]
    public abstract class CarController : MonoBehaviour
    {
        private CarMovement _carMovement;

        protected virtual void Start()
        {
            _carMovement = GetComponent<CarMovement>();
        }

        protected void Accelerate(float acceleration)
        {
            _carMovement.Accelerate(acceleration);
        }

        protected void Rotate(float rotation)
        {
            _carMovement.Rotate(rotation);
        }
    }
}