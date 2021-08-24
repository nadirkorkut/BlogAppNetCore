using BlogAppNetCore.Entities.Concrete;
using BlogAppNetCore.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppNetCore.Data.Abstract
{
    public interface ICategoryRepository : IEntityRepository<Category>
    {
    }
}
