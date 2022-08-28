using ITalentBlog.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITalentBlog.Core.Services
{
    public interface ICategoryService
    {
        CustomResponse<List<CategoryDto>> GetCategories();

        CustomResponse<CreateCategoryDto> CreateCategory(CreateCategoryDto request);

        CustomResponse<string> DeleteCategory(int id);

        CustomResponse<CategoryDto> GetCategoryById(int id);

        CustomResponse<CategoryUpdateDto> UpdateCategory(CategoryUpdateDto request);

        CustomResponse<bool> ExistsCategory(string Name);
    }
}
