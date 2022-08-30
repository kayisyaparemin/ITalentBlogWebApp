using AutoMapper;
using ITalentBlog.Core;
using ITalentBlog.Core.DTOs.Category;
using ITalentBlog.Core.Models;
using ITalentBlog.Core.Repositories;
using ITalentBlog.Core.Services;
using ITalentBlog.Repository;
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
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository,IMapper mapper,IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public CustomResponse<CategoryCreateDto> CreateCategory(CategoryCreateDto request)
        {
            var newCategory = _mapper.Map<Category>(request);
            _categoryRepository.CreateCategory(newCategory);
            _unitOfWork.Commit();

            var newCategoryDto = _mapper.Map<CategoryCreateDto>(newCategory);

            return CustomResponse<CategoryCreateDto>.Success(newCategoryDto, 201);
        }

        public CustomResponse<List<CategoryDto>> GetCategories()
        {
            var  categories = _categoryRepository.GetCategories();

            var categoryDtoList = _mapper.Map<List<CategoryDto>>(categories);

            return CustomResponse<List<CategoryDto>>.Success(categoryDtoList, 200);
        }

        public CustomResponse<string> DeleteCategory(int id)
        {
            if (!_categoryRepository.Any(id))
            {
                return CustomResponse<string>.Fail($"Id'si {id} olan ürün bulunamamıştır", 404);

            }
            _categoryRepository.DeleteCategory(id);
            _unitOfWork.Commit();

            return CustomResponse<string>.Success(String.Empty, 204);
        }

        public CustomResponse<CategoryDto> GetCategoryById(int id)
        {
            var category = _categoryRepository.GetCategoryById(id);

            var categoryDto = _mapper.Map<CategoryDto>(category);

            return CustomResponse<CategoryDto>.Success(categoryDto, 200);
        }

        public CustomResponse<CategoryUpdateDto> UpdateCategory(CategoryUpdateDto request)
        {
            var UpdatedCategory = _mapper.Map<Category>(request);
            _categoryRepository.UpdateCategory(UpdatedCategory);
            _unitOfWork.Commit();

            var updatedCategoryDto = _mapper.Map<CategoryUpdateDto>(UpdatedCategory);

            return CustomResponse<CategoryUpdateDto>.Success(updatedCategoryDto, 201);
        }

        public CustomResponse<bool> ExistsCategory(string Name)
        {
            var IsExısts = _categoryRepository.ExistsCategory(Name);

            return CustomResponse<bool>.Success(IsExısts, 200);
        }
    }
}
