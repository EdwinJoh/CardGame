using Contacts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        //private readonly Lazy<ITestModelRepository> _modelRepository;
        //public RepositoryManager(RepositoryContext repositoryContext)
        //{
        //    _repositoryContext = repositoryContext;
        //    _modelRepository = new Lazy<ITestModelRepository>(() => new
        //    TestModelRepository(repositoryContext));

        //}

        //public ITestModelRepository TestModel => _modelRepository.Value;
        public void Save() => _repositoryContext.SaveChanges();
    }
}
