using UnitSystem.GameDesign;

namespace UnitSystem.Characteristics.Shape
{
    public class Cube : UnitShape
    {
        protected override int BonusHealthPoint => GameDesignVariables.Cube.healthPoint;

        protected override int BonusAttackPoint => GameDesignVariables.Cube.attackPoint;
    }
}