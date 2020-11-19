using UnitSystem.Characteristics.Shape;
using UnitSystem.GameDesign;

namespace UnitSystem.Characteristics.Color
{
    public class Yellow : UnitColor
    {
        public Yellow(UnitShape unitShape) : base(unitShape)
        {
        }

        protected override int BonusHealthPoint => unitShape is Cube ? GameDesignVariables.Yellow.healthPoint : 0;
        protected override int BonusAttackPoint => unitShape is Sphere ? GameDesignVariables.Yellow.attackPoint : 0;
    }
}