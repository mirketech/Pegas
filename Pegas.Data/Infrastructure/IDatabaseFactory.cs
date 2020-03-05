using System;

namespace Pegas.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        PegasEntities Get();
    }
}
