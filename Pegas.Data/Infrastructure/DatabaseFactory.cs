namespace Pegas.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private PegasEntities dataContext;
        public PegasEntities Get()
        {
            return dataContext ?? (dataContext = new PegasEntities());
        }
        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}