using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IGradeRepository _grade;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public IGradeRepository Grade
        {
            get
            {
                if (_grade == null)
                {
                    _grade = new GradeRepository(_repoContext);
                }

                return _grade;
            }
        }
    }
}
