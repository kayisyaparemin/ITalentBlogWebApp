using AutoMapper;
using ITalentBlog.Core;
using ITalentBlog.Core.DTOs;
using ITalentBlog.Core.Repositories;
using ITalentBlog.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITalentBlog.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public CustomResponse<List<CategoryDto>> GetCategories()
        {
            var  categories = _categoryRepository.GetCategories();

            var categoryDtoList = _mapper.Map<List<CategoryDto>>(categories);

            return CustomResponse<List<CategoryDto>>.Success(categoryDtoList, 200);
        }
    }
}
