using BlogAppNetCore.Data.Abstract;
using BlogAppNetCore.Entities.Concrete;
using BlogAppNetCore.Entities.Dtos;
using BlogAppNetCore.Services.Abstract;
using BlogAppNetCore.Shared.Utilities.Results.Abstract;
using BlogAppNetCore.Shared.Utilities.Results.ComplexTypes;
using BlogAppNetCore.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppNetCore.Services.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IResult> Add(CategoryAddDto categoryAddDto, string createdByName)
        {
            await _unitOfWork.Categories.AddAsync(new Category
            {
                Name = categoryAddDto.Name,
                Description = categoryAddDto.Description,
                Note = categoryAddDto.Note,
                IsActive = categoryAddDto.IsActive,
                CreatedByName = createdByName,
                CreatedDate = DateTime.Now,
                ModifiedByName = createdByName,
                ModifiedDate = DateTime.Now,
                IsDeleted = false
            }).ContinueWith(t=>_unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, $"{categoryAddDto.Name} Adlı Kategori Başarıyla Eklenmeştir.");
        }

        public async Task<IResult> Delete(int categoryId, string modifiedByName)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId);
            if (category != null)
            {
                category.IsDeleted = true;
                category.ModifiedByName = modifiedByName;
                category.ModifiedDate = DateTime.Now;
                await _unitOfWork.Categories.UpdateAsync(category).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{category.Name} Adlı Kategori Başarıyla Silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Böyle Bir Kategori Bulunamadı.");
        }

        public async Task<IDataResult<Category>> Get(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId, c => c.Articles);

            if (category != null)
            {
                return new DataResult<Category>(ResultStatus.Success, category);
            }
            return new DataResult<Category>(ResultStatus.Error, "Kategori Bulunamadı.", null);
        }

        public async Task<IDataResult<IList<Category>>> GetAll()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(null, c => c.Articles);
            if (categories.Count > -1)
            {
                return new DataResult<IList<Category>>(ResultStatus.Success, categories);
            }
            return new DataResult<IList<Category>>(ResultStatus.Error, "Hiç Bir Kategori Bulunamadı.", null);
        }

        public async Task<IDataResult<IList<Category>>> GetAllByNonDeleted()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(c => !c.IsDeleted, c => c.Articles);
            if (categories.Count > -1)
            {
                return new DataResult<IList<Category>>(ResultStatus.Success, categories);
            }
            return new DataResult<IList<Category>>(ResultStatus.Error, "Hiç Bir Kategori Bulunamadı.", null);
        }

        public async Task<IResult> HardDelete(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId);
            if (category != null)
            {
                await _unitOfWork.Categories.DeleteAsync(category).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{category.Name} Adlı Kategori Veritabanından Başarıyla Silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Böyle Bir Kategori Bulunamadı.");
        }

        public async Task<IResult> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryUpdateDto.Id);
            if (category != null)
            {
                category.Name = categoryUpdateDto.Name;
                category.Description = categoryUpdateDto.Description;
                category.Note = categoryUpdateDto.Note;
                category.IsActive = categoryUpdateDto.IsActive;
                category.IsDeleted = categoryUpdateDto.IsDeleted;
                category.ModifiedByName = modifiedByName;
                category.ModifiedDate = DateTime.Now;
                await _unitOfWork.Categories.UpdateAsync(category).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{categoryUpdateDto.Name} Adlı Kategori Başarıyla Güncellenmiştir.");
            }
            return new Result(ResultStatus.Error, "Böyle Bir Kategori Bulunamadı.");
        }
    }
}
