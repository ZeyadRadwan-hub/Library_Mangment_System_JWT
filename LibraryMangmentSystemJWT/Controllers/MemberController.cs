using AutoMapper;
using LibraryMangmentSystemJWT.DTOs.Member;
using LibraryMangmentSystemJWT.Model;
using LibraryMangmentSystemJWT.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMangmentSystemJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public MemberController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("Top-Readers")]
        public IActionResult Get()
        {
            var res = _unitOfWork.CustomMembers.GetAllMembers();
            return Ok(res);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var res =  _unitOfWork.CustomMembers.GetById(id);
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Create([FromBody]MemberDTO dto)
        {
            var member = _mapper.Map<Member>(dto);
            _unitOfWork.Members.AddObject(member);
            var respone = _mapper.Map<MemberDTO>(member);
            _unitOfWork.Save();
            return Ok(respone);
        }
    }
}
