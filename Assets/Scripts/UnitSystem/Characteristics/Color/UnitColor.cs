using UnitSystem.Characteristics.Shape;

namespace UnitSystem.Characteristics.Color
{
    public abstract class UnitColor : Characteristic
    {
        protected readonly UnitShape unitShape;

        protected UnitColor(UnitShape unitShape)
        {
            this.unitShape = unitShape;
        }
    }
}