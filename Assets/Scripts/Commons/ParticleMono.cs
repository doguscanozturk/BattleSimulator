using UnitSystem.Characteristics.Color;
using UnityEngine;

namespace Commons
{
    public class ParticleMono : BasicMono
    {
        [Header("ParticleMono")] 
        [SerializeField] private ParticleSystem thisParticleSystem;

        public ParticleSystem ThisParticleSystem => thisParticleSystem;

        public void SetStartColor(Color color)
        {
            var main = thisParticleSystem.main;
            main.startColor = color;
        }
    }
}