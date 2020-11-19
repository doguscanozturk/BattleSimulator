using UnitSystem.Characteristics.Shape;
using UnitSystem.GameDesign;

namespace UnitSystem.Characteristics.Color
{
    public class Blue : UnitColor
    {
        public Blue(UnitShape unitShape) : base(unitShape)
        {
        }
        
        protected override int BonusHealthPoint => unitShape is Sphere ? GameDesignVariables.Blue.healthPoint : 0;

        protected override int BonusAttackPoint => unitShape is Cube ? GameDesignVariables.Blue.attackPoint : 0;
    }
}