using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SalesAPI.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private SqlConnection _db;
        private const string SelectDetailsCustomers =
            @"SELECT
                    CustomerID, CustomerName, BillToCustomerID, CustomerCategoryID, BuyingGroupID,
                    PrimaryContactPersonID, AlternateContactPersonID, DeliveryMethodID, DeliveryCityID, 
                    PostalCityID, CreditLimit, AccountOpenedDate, StandardDiscountPercentage, IsStatementSent,
                    IsOnCreditHold, PaymentDays, PhoneNumber, FaxNumber, DeliveryRun, RunPosition,
                    WebsiteURL, DeliveryAddressLine1, DeliveryAddressLine2, DeliveryPostalCode, 
                    PostalAddressLine1, PostalAddressLine2, PostalPostalCode, LastEditedBy, ValidFrom, ValidTo
              FROM Sales.Customers ";
        private const string SelectCustomers =
            @"SELECT
                    CustomerID, CustomerName, CustomerCategoryID, ValidTo
              FROM Sales.Customers";
        private const string Paging = "ORDER BY CustomerId OFFSET @PageNum * @PageSize ROWS FETCH NEXT @PageSize ROWS ONLY";

        public CustomerRepository(string connectionString) =>
            _db = new SqlConnection(connectionString);
        

        public void Dispose() =>
            _db.Dispose();

        public CustomerDetailDto GetCustomer(int customerId) =>
            _db.QueryFirstOrDefault<CustomerDetailDto>(
                $"{SelectDetailsCustomers} WHERE CustomerId = @Id",
                new { Id = customerId }
            );

        public IEnumerable<CustomerDto> ListCustomers(int pageNum, int pageSize) =>
            _db.Query<CustomerDto>($"{ SelectCustomers } { Paging }", new { PageNum = pageNum, PageSize=pageSize });

        public IEnumerable<CustomerDto> SearchCustomers(string keyword, int pageNum, int pageSize) => 
            _db.Query<CustomerDto>(
                $"{SelectCustomers} WHERE CustomerName LIKE @Search { Paging }",
                new { PageNum = pageNum, PageSize = pageSize, Search=$"{keyword}%" }
            );
    }
}
