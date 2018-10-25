using ActivityPost.Core.Contracts.Repositories;
using ActivityPost.Infrastructure.Entities.Context;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace ActivityPost.Infrastructure.Entities.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IPostRepository _post;
        private IContainer _container;

        public IPostRepository Post
        {
            get
            {
                if (_post == null)
                {
                    _post = _container.With("RepositoryContext").EqualTo(_repoContext).GetInstance<IPostRepository>("InitPostRepository");
                }

                return _post;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext, IContainer container)
        {

            _repoContext = repositoryContext;
            _container = container;
        }
    }
}
