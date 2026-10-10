using AutoMapper;
using LibraryMangmentSystemJWT.DTOs.Borrowing;
using LibraryMangmentSystemJWT.Model;
using LibraryMangmentSystemJWT.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMangmentSystemJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowingController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public BorrowingController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var res = _unitOfWork.CustomBorrowings.GetAllBorrowings();
            return Ok(res);
        }
        [HttpPost]
        public IActionResult Create([FromBody] BorrowingDTO dto)
        {
            var borrow = _mapper.Map<Borrowing>(dto);
            _unitOfWork.Borrowings.AddObject(borrow);
            var res = _mapper.Map<BorrowingDTO>(borrow);
            _unitOfWork.Save();
            return Ok(res);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update([FromBody] BorrowingDTO dto,int id)
        {
            if(id <= 0)
            return BadRequest();
            var borrow = _mapper.Map<Borrowing>(dto);
            _unitOfWork.Borrowings.UpdateObject(borrow);
            var respone = _mapper.Map<BorrowingDTO>(borrow);
            _unitOfWork.Save();
            return Ok(respone);
        }
    }
}