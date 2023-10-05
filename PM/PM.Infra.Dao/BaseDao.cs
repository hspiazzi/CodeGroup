using Microsoft.Practices.EnterpriseLibrary.Data;
using System;

namespace PM.Infra.Dao
{
    public class BaseDao : IDisposable
    {
        public Database db;

        public BaseDao()
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create("strConn");
        }

        public void Dispose()
        {
            db = null;
            GC.SuppressFinalize(this);
        }
    }
}