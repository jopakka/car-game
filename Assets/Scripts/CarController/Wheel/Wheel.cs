using System;
using UnityEngine;

namespace CarController.Wheel
{
    public abstract class Wheel : MonoBehaviour
    {
        /// <param name="ratio">Should be between -1f and 1f</param>
        public abstract void Steer(float ratio);
    }
}