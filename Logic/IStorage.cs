using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Interface for the storage layer
    /// </summary>
    public interface IStorage
    {

        /// <summary>
        /// Load the notebook
        /// </summary>
        /// <returns>the notebook loaded (or a new notebook)</returns>
        Notebook Load();
        /// <summary>
        /// Save the notebook
        /// </summary>
        /// <param name="nb">the notebook to save</param>
        void Save(Notebook nb);
    }
}
