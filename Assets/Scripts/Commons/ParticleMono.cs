using UnitSystem.Characteristics.Color;
using UnityEngine;

namespace Commons
{
    public class ParticleMono : BasicMono
    {
        [Header("ParticleMono")] 
        [SerializeField] private ParticleSystem thisParticleSystem;

        public ParticleSystem ThisParticleSystem => thisParticleSystem;

        public void SetStartColor(UnitColor unitColor)
        {
            var startColor = Color.white;
            switch (unitColor)
            {
                case Blue b:
                    startColor = Color.blue;
                    break;
                case Yellow y:
                    startColor = Color.yellow;
                    break;
                case Green g:
                    startColor = Color.green;
                    break;
                case Red r:
                    startColor = Color.red;
                    break;
            }

            var main = thisParticleSystem.main;
            main.startColor = startColor;
        }
    }
}