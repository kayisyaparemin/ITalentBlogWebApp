using ITalentBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITalentBlog.Core.Repositories
{
    public interface ICategoryRepository
    {
        public List<Category> GetCategories();
    }
}
