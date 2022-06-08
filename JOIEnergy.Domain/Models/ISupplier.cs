using System;
namespace JOIEnergy.Domain.Models
{
    public interface ISupplier
    {
        decimal GetPrice(DateTime datetime);
    }
}
