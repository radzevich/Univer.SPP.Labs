using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace _4
{
    public class AssemblyManager : IDisposable
    {
        private Assembly _assemblyToProcess;
        private Type[] _assemblyTypes;

        private void Initialize(string pathToAssembly)
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
        }

        public AssemblyManager FromAssembly(string pathToAssembly)
        {
            Initialize(pathToAssembly);
            return this;
        }

        public AssemblyManager GetPublickMembers()
        {
            var publicMembers = from assemblyType in _assemblyTypes
                                where assemblyType.IsPublic
                                select assemblyType;

            _assemblyTypes = publicMembers.ToArray();

            return this;
        }

        public AssemblyManager SortByNamespaceAndName()
        {
            var sortedTypes = from assemblyType in _assemblyTypes
                              orderby assemblyType.Namespace, assemblyType.Name
                              select assemblyType;

            _assemblyTypes = sortedTypes.ToArray();

            return this;
        }

        public List<string> GetAssemblyTypesNames()
        {
            var assemblyTypesNames = from assemblyType in _assemblyTypes
                                     select assemblyType.FullName;

            return assemblyTypesNames.ToList();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}