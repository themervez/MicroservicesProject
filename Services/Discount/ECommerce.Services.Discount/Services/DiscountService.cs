using ECommerce.Shared.DTOs;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System;
using Dapper;
using System.Linq;

namespace ECommerce.Services.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _dbConnection;

        public DiscountService(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbConnection = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSql"));
        }
        public async Task<ResponseDto<NoContent>> Delete(int id)
        {
            var status = await _dbConnection.ExecuteAsync("delete from discount where ID=@id", new
            {
                id = id
            });

            return status > 0 ? ResponseDto<NoContent>.Success(204) : ResponseDto<NoContent>.Fail("Silinecek değer bulunamadı!", 404);//if there is a deleted value with this process,return success,if not return fail
        }
        public async Task<ResponseDto<List<Models.Discount>>> GetAll()
        {
            var discounts = await _dbConnection.QueryAsync<Models.Discount>("select * from discount");
            return ResponseDto<List<Models.Discount>>.Success(discounts.ToList(), 200);
        }

        public async Task<ResponseDto<Models.Discount>> GetByCodeUserId(string code, string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto<Models.Discount>> GetByID(int id)
        {
            var discount = (await _dbConnection.QueryAsync<Models.Discount>("select * from discount where Id=@id", new
            {
                id = id
            })).SingleOrDefault();

            if (discount == null)
            {
                return ResponseDto<Models.Discount>.Fail("Discount bulunamadı!", 404);
            }
            return ResponseDto<Models.Discount>.Success(discount, 200);
        }

        public async Task<ResponseDto<NoContent>> Save(Models.Discount discount)
        {
            var status = await _dbConnection.ExecuteAsync("insert into discount (userid,rate,code) values (@UserID,@Rate,@Code)", discount);
            if (status > 0)
            {
                return ResponseDto<NoContent>.Success(204);
            }
            return ResponseDto<NoContent>.Fail("Bir hata oluştu!", 500);
        }

        public async Task<ResponseDto<NoContent>> Update(Models.Discount discount)
        {
            var status = await _dbConnection.ExecuteAsync("update discount set userid=@UserID,rate=@Rate,code=@Code where Id=@id)", discount);
            if (status > 0)
            {
                return ResponseDto<NoContent>.Success(204);
            }
            return ResponseDto<NoContent>.Fail("Discount bulunamadı!", 500);
        }
    }
}
