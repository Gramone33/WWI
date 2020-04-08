using System;
using System.ComponentModel.DataAnnotations;

namespace SalesAPI.Models
{
    public class CustomerDetailDto
    {
        /// <summary>
        /// Primary key of the customer
        /// </summary>
        public int CustomerID { get; set; }
        /// <summary>
        /// Name of the customer
        /// </summary>
        [Required]
        public string CustomerName { get; set; }
        /// <summary>
        /// Bill identifier
        /// </summary>
        [Required] 
        public int BillToCustomerID { get; set; }
        /// <summary>
        /// Customer Category identifier
        /// </summary>
        [Required] 
        public int CustomerCategoryID { get; set; }
        /// <summary>
        /// Buying group identifier
        /// </summary>
        public int BuyingGroupID { get; set; }
        /// <summary>
        /// Identifier of the primary contact
        /// </summary>
        [Required] 
        public int PrimaryContactPersonID { get; set; }
        /// <summary>
        /// Identifier of the alternate contact
        /// </summary>
        [Required] 
        public int AlternateContactPersonID { get; set; }
        /// <summary>
        /// Identifier of the delivery method
        /// </summary>
        [Required] 
        public int DeliveryMethodID { get; set; }
        /// <summary>
        /// Identifier of the delivery city
        /// </summary>
        [Required] 
        public int DeliveryCityID { get; set; }
        /// <summary>
        /// Identifier of the postal city
        /// </summary>
        [Required] 
        public int PostalCityID { get; set; }
        /// <summary>
        /// Credit limit
        /// </summary>
        [Required] 
        public decimal CreditLimit { get; set; }
        /// <summary>
        /// Date of the account opening
        /// </summary>
        [Required] 
        public DateTime AccountOpenedDate { get; set; }
        /// <summary>
        /// Percentage of the standard discount for this customer
        /// </summary>
        [Required] 
        public decimal StandardDiscountPercentage { get; set; }
        /// <summary>
        /// Get if a statement was sent
        /// </summary>
        [Required] 
        public bool IsStatementSent { get; set; }
        /// <summary>
        /// Get if the customer is on a credit hold
        /// </summary>
        [Required] 
        public bool IsOnCreditHold { get; set; }
        /// <summary>
        /// Number of day for payments
        /// </summary>
        public int PaymentDays { get; set; }
        /// <summary>
        /// Main phone number
        /// </summary>
        [Required]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Main fax number
        /// </summary>
        [Required]
        public string FaxNumber { get; set; }
        /// <summary>
        /// Delivery run
        /// </summary>
        public string DeliveryRun { get; set; }
        /// <summary>
        /// Run position
        /// </summary>
        public string RunPosition { get; set; }
        /// <summary>
        /// Customer website url
        /// </summary>
        [Required] 
        public string WebsiteURL { get; set; }
        /// <summary>
        /// Address line 2 for deliveries
        /// </summary>
        [Required]
        public string DeliveryAddressLine1 { get; set; }
        /// <summary>
        /// Address line 1 for deliveries
        /// </summary>
        public string DeliveryAddressLine2 { get; set; }
        /// <summary>
        /// Postal code for deliveries
        /// </summary>
        [Required]
        public string DeliveryPostalCode { get; set; }
        // public SqlGeography DeliveryLocation { get; set; }
        /// <summary>
        /// Postal address, line 1 for mails
        /// </summary>
        [Required]
        public string PostalAddressLine1 { get; set; }
        /// <summary>
        /// Postal address, line 1 for mails
        /// </summary>
        public string PostalAddressLine2 { get; set; }
        /// <summary>
        /// Postal code for mails
        /// </summary>
        [Required] 
        public string PostalPostalCode { get; set; }
        /// <summary>
        /// Date of last edit
        /// </summary>
        [Required] 
        public int LastEditedBy { get; set; }
        /// <summary>
        /// Valid date start, default is maximum date value
        /// </summary>
        public DateTime ValidFrom { get; set; }
        /// <summary>
        /// Valid date end, default is maximum date value
        /// </summary>
        public DateTime ValidTo { get; set; }
    }
}
