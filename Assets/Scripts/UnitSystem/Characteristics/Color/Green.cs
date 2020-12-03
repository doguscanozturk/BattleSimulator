using UnitSystem.Characteristics.Shape;
using UnitSystem.GameDesign;

namespace UnitSystem.Characteristics.Color
{
    public class Green : UnitColor
    {
        public Green(UnitShape unitShape) : base(unitShape)
        {
        }

        public override UnityEngine.Color RepresentationColor => UnityEngine.Color.green;
        
        protected override int BonusHealthPoint => unitShape is Sphere ? GameDesignVariables.Green.healthPoint : 0;
        protected override int BonusAttackPoint => unitShape is Cube ? GameDesignVariables.Green.attackPoint : 0;
    }
}