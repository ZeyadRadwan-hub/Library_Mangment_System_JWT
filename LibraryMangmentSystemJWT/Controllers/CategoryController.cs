using AutoMapper;
using LibraryMangmentSystemJWT.DTOs.Category;
using LibraryMangmentSystemJWT.Model;
using LibraryMangmentSystemJWT.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMangmentSystemJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var res = _unitOfWork.CustomCategories.GetAllCategories();
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CategoryDTO dto)
        {
            var category = _mapper.Map<Category>(dto);
            _unitOfWork.Categories.AddObject(category);
            var res = _mapper.Map<CategoryDTO>(category);
            _unitOfWork.Save();
            return Ok(res);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _unitOfWork.Categories.DeleteObject(id);
            _unitOfWork.Save();
            return NoContent();
        }
    }
}
