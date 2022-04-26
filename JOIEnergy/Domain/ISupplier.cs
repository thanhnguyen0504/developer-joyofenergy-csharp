using System;
namespace JOIEnergy.Domain
{
    public interface ISupplier
    {
        decimal GetPrice(DateTime datetime);
    }
}
