using AutoMapper;
using LibraryMangmentSystemJWT.DTOs.Book;
using LibraryMangmentSystemJWT.Model;
using LibraryMangmentSystemJWT.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMangmentSystemJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public BookController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{Name:alpha}")]
        public IActionResult GetAllBySearch(string Name)
        {
            var res = _unitOfWork.CustomBooks.GetAllBooks(Name);
            return Ok(res);
        }

        [HttpGet]
        public IActionResult GetByHighestPrice()
        {
            var res = _unitOfWork.CustomBooks.GetByHighestPrice();
            var respone = _mapper.Map<BookResponeDTO>(res);
            return Ok(respone);
        }

        [HttpPost]
        public IActionResult Create([FromBody] BookCreateDTO dto)
        {
            var Book = _mapper.Map<Book>(dto);
            _unitOfWork.Books.AddObject(Book);
            _unitOfWork.Save();
            var respone = _mapper.Map<BookCreateDTO>(Book);
            return Ok(respone);
        }
    }
}
