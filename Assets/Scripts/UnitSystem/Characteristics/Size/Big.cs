using UnitSystem.GameDesign;

namespace UnitSystem.Characteristics.Size
{
    public class Big : UnitSize
    {
        protected override int BonusHealthPoint => GameDesignVariables.Big.healthPoint;
        protected override int BonusAttackPoint => GameDesignVariables.Big.attackPoint;
    }
}