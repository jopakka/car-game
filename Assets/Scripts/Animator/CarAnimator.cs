using CarController;
using CarController.Wheel;
using UnityEngine;

namespace Animator
{
    [RequireComponent(typeof(CarMovement))]
    public class CarAnimator : MonoBehaviour
    {
        private CarMovement _carMovement;

        [SerializeField] private GameObject body;
        [SerializeField] private Wheel[] wheels;

        private void Start()
        {
            _carMovement = GetComponent<CarMovement>();
            _carMovement.OnSteering += SteeringChanged;
        }

        private void SteeringChanged(float value)
        {
            foreach (var wheel in wheels)
            {
                wheel.Steer(value);
            }
        }
    }
}