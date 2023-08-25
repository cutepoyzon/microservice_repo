using AutoMapper;
using Mango.Services.ProductsAPI.Data;
using Mango.Services.ProductsAPI.Models;
using Mango.Services.ProductsAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductsAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    //[Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ServiceResponseDto _responseDto;

        public ProductsController(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _responseDto = new ServiceResponseDto();
        }

        [HttpGet]
        public ServiceResponseDto Get()
        {
            try
            {
                IEnumerable<Product> objList = _dbContext.Products.ToList();
                _responseDto.Result = _mapper.Map<IEnumerable<ProductDto>>(objList);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ServiceResponseDto Get(int id)
        {
            try
            {
                var obj = _dbContext.Products.First(x => x.ProductId == id);
                _responseDto.Result = _mapper.Map<ProductDto>(obj);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public ServiceResponseDto Post([FromBody] ProductDto productDto)
        {
            try
            {
                Product obj = _mapper.Map<Product>(productDto);
                _dbContext.Products.Add(obj);
                _dbContext.SaveChanges();

                _responseDto.Result = _mapper.Map<ProductDto>(obj);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message + "||" + ex.StackTrace;
            }
            return _responseDto;
        }

        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public ServiceResponseDto Put([FromBody] ProductDto productDto)
        {
            try
            {
                Product obj = _mapper.Map<Product>(productDto);
                _dbContext.Products.Update(obj);
                _dbContext.SaveChanges();

                _responseDto.Result = _mapper.Map<ProductDto>(obj);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpDelete]
        [Authorize(Roles = "ADMIN")]
        [Route("{id:int}")]
        public ServiceResponseDto Delete(int id)
        {
            try
            {
                Product obj = _dbContext.Products.First(y => y.ProductId == id);
                _dbContext.Products.Remove(obj);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }
    }
}
