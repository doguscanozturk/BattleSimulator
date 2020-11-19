using UnitSystem.GameDesign;

namespace UnitSystem.Characteristics.Shape
{
    public class Sphere : UnitShape
    {
        protected override int BonusHealthPoint => GameDesignVariables.Sphere.healthPoint;
        protected override int BonusAttackPoint => GameDesignVariables.Sphere.attackPoint;
    }
}