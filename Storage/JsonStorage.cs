using Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    /// <summary>
    /// Storage layer, use JSON format; saves into a file
    /// </summary>
    public class JsonStorage : Logic.IStorage
    {
        private string fileName;

        /// <summary>
        /// Initialize the storage layer
        /// </summary>
        /// <param name="filename">the path to the file</param>
        public JsonStorage(string filename)
        {
            this.fileName = filename;
        }
        public Notebook Load()
        {
            Notebook nb=null;
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Notebook));
                using(Stream stream = new FileStream(fileName,FileMode.Open))
                {
                    nb = ser.ReadObject(stream) as Notebook;
                }
            }
            catch
            {
                nb = new Notebook();
            }

            return nb;
        }

        public void Save(Notebook nb)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Notebook));
   
            using (Stream stream = new FileStream(fileName, FileMode.Create))
            {
                ser.WriteObject(stream, nb);
            }       

        }
    }
}
