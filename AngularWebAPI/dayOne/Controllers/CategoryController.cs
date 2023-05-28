using dayOne.DTO;
using dayOne.Models;
using dayOne.Repositries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dayOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository categoryRepository;
        public CategoryController( ICategoryRepository categoryRepository)
        {
            this.categoryRepository=categoryRepository;
        }
        [HttpGet]
        public List<CategoryDto> GetAllCategories()
        {
            CategoryDto categoryDto = new CategoryDto();
            List<CategoryDto> categoryDtos = new List<CategoryDto>();
            List<Category> categories= (List<Category>)categoryRepository.GetAll(c=>c.isDeleted==false);

            foreach(Category category in categories)
            {
                categoryDtos.Add(new CategoryDto { Id = category.Id, Name = category.Name });
            }
            return categoryDtos;
        }


        [HttpGet("GetAllName")]

        public List<string> GetAllCategoriesName()
        {
            List<string> categoryNames = new List<string>();
            List<Category> categories = (List<Category>)categoryRepository.GetAll(c => c.isDeleted == false).ToList();
            foreach (Category category in categories)
            {
                categoryNames.Add(category.Name);

            }

            return categoryNames;
        }

    }
}
