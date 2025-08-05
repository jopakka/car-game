using Unity.Mathematics.Geometry;
using UnityEngine;

namespace CarController.Wheel
{
    public class RotatingWheel : Wheel
    {
        [SerializeField] private float minRotationAngle = -30f;
        [SerializeField] private float maxRotationAngle = 30f;
        
        public override void Steer(float ratio)
        {
            Debug.Log("Steering");
            var clampedRatio = Mathf.Clamp(ratio, -1f, 1f);

            var newRotation = clampedRatio switch
            {
                > 0f => Mathf.Lerp(0f, minRotationAngle, clampedRatio),
                < 0f => Mathf.Lerp(0f, maxRotationAngle, -clampedRatio),
                _ => 0f
            };
            
            var currentEulerAngles = transform.localEulerAngles;
            transform.localRotation = Quaternion.Euler(
                currentEulerAngles.x,
                currentEulerAngles.y,
                newRotation
            );
        }
    }
}