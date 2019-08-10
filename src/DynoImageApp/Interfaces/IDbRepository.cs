using System;
using System.Collections.Generic;
using System.Text;

namespace DynoImageApp.Interfaces
{
    public interface IDbRepository
    {
        void UpdateDb(Models.dbModel dbModel);
        Models.dbModel ReadDb();
    }
}
