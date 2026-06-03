using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;
        public DiscountService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values (@code,@rate,@isActive,@validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDto.Code);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@isActive", createCouponDto.IsActive);
            parameters.Add("@validDate", createCouponDto.ValidDate);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public Task DeleteCouponAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultCouponDto>> GetAllCouponAsync()
        {
            string query = "Select * From Coupons";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCouponDto>(query);
                return values.ToList();

            }
        }

        public Task<GetByIdCouponDto> GetByIdCouponAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultCouponDto>> GetResultCouponAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            throw new NotImplementedException();
        }
    }
}
