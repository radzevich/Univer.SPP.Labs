using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _2
{
    public class CatalogManager
    {
        public bool CatalogExists(string catlogToCheckPath)
        {
            return Directory.Exists(catlogToCheckPath);
        }

        public void CreateCatalog(string catalogToCreatePath)
        {
            if (!Directory.Exists(catalogToCreatePath))
            {
                Directory.CreateDirectory(catalogToCreatePath);
            }
        }

        public List<string> GetFilesInCatalog(string targetCatalog)
        {
            return Directory.GetFiles(targetCatalog).ToList<string>();
        }
    }
}