﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalaaviMVC_DomainClasses.Products;

namespace MalaaviMVC_DataLayer.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        IEnumerable<Category> GetByParentId(int parentId);
    }
}