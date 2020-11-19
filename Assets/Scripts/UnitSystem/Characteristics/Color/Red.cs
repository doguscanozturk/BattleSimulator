using UnitSystem.Characteristics.Shape;
using UnitSystem.GameDesign;

namespace UnitSystem.Characteristics.Color
{
    public class Red : UnitColor
    {
        public Red(UnitShape unitShape) : base(unitShape)
        {
        }

        protected override int BonusHealthPoint => unitShape is Cube ? GameDesignVariables.Red.healthPoint : 0;
        protected override int BonusAttackPoint => unitShape is Sphere ? GameDesignVariables.Red.attackPoint : 0;
    }
}