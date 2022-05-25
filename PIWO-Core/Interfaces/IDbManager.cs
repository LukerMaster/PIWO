using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIWO_Core.Interfaces
{
    /// <summary>
    /// Interface that allows for creation and managing of new
    /// context.
    /// </summary>
    public interface IDbManager
    {
        public IAlcoholContext CreateAlcoholsDatabase(string ConnectionString);
    }
}
