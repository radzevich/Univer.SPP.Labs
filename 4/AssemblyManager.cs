using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace _4
{
    public class AssemblyManager : IDisposable
    {
        private Assembly _assemblyToProcess;
        private Type[] _assemblyTypes;

        private Assembly LoadAssembly(string pathToAssembly)
        {
            var fullPathToAssembly = Path.GetFullPath(pathToAssembly);
            _assemblyToProcess = Assembly.LoadFile(fullPathToAssembly);

            if (_assemblyToProcess != null)
            {
                _assemblyTypes = _assemblyToProcess.GetTypes();
            }
            else
            {
                throw new FileNotFoundException();
            }

            return Assembly.LoadFile(fullPathToAssembly);
        }

        public AssemblyManager GetPublickMethods(string pathToAssembly)
        {
            var assemblyToAnalize = LoadAssembly(pathToAssembly);
            _assemblyTypes = assemblyToAnalize.
            return this;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}