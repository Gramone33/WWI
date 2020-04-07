using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SalesAPI.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private SqlConnection _db;
        private const string SelectCustomers =
            @"SELECT
                    CustomerID, CustomerName, BillToCustomerID, CustomerCategoryID, BuyingGroupID,
                    PrimaryContactPersonID, AlternateContactPersonID, DeliveryMethodID, DeliveryCityID, 
                    PostalCityID, CreditLimit, AccountOpenedDate, StandardDiscountPercentage, IsStatementSent,
                    IsOnCreditHold, PaymentDays, PhoneNumber, FaxNumber, DeliveryRun, RunPosition,
                    WebsiteURL, DeliveryAddressLine1, DeliveryAddressLine2, DeliveryPostalCode, 
                    PostalAddressLine1, PostalAddressLine2, PostalPostalCode, LastEditedBy, ValidFrom, ValidTo
              FROM Sales.Customers ";

        public CustomerRepository(string connectionString) =>
            _db = new SqlConnection(connectionString);
        

        public void Dispose() =>
            _db.Dispose();

        public Customer GetCustomer(int customerId) =>
            _db.QueryFirstOrDefault<Customer>(
                $"{SelectCustomers} WHERE CustomerId = @Id",
                new { Id = customerId }
            );

        public IEnumerable<Customer> ListCustomers() =>
            _db.Query<Customer>(SelectCustomers);

        public IEnumerable<Customer> SearchCustomers(string keyword) => 
            _db.Query<Customer>(
                $"{SelectCustomers} WHERE CustomerName LIKE @Search",
                new { Search=$"{keyword}%" }
            );
    }
}
