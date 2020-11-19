using UnitSystem.GameDesign;

namespace UnitSystem.Characteristics.Size
{
    public class Small : UnitSize
    {
        protected override int BonusHealthPoint => GameDesignVariables.Small.healthPoint;
        protected override int BonusAttackPoint => GameDesignVariables.Small.attackPoint;
    }
}