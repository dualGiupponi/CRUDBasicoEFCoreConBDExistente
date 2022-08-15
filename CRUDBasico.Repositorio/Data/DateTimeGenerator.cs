using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace CRUDBasico.Repositorio.Data
{
    internal class DateTimeGenerator : ValueGenerator<DateTime?>
    {
        public override bool GeneratesTemporaryValues { get; }

        public override DateTime? Next(EntityEntry entry)
        {
            return DateTime.Now;
        }
    }
}
