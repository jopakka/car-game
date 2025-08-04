using System;
using CarController;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(CarMovement))]
    public class CarAnimator : MonoBehaviour
    {
        private CarMovement _carMovement;

        private void Start()
        {
            _carMovement = GetComponent<CarMovement>();
        }
        
        
    }
}