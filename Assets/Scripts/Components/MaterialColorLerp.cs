using UnityEngine;
using FallingCubes.Abstractions;

namespace FallingCubes.Core
{
    public class MaterialColorLerp : MonoBehaviour, IInterpolatable<Color>
    {
        [SerializeField]
        private new Renderer renderer;

        [SerializeField]
        private Color minColor;

        public Color MinValue { get => minColor; set => minColor = value; }
        public Color MaxValue { get => maxColor; set => maxColor = value; }
        public float LerpFactor { get => lerpFactor; set => SetFactor(value); }
        private float lerpFactor;
        private Color maxColor;

        private void Start()
        {
            maxColor = renderer.material.color;
        }

        private void SetFactor(float factor)
        {
            lerpFactor = factor;
            renderer.material.color = Color.Lerp(MinValue, MaxValue, lerpFactor);
        }
    }
}
