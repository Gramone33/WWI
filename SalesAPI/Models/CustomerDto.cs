using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesAPI.Models
{
    public class CustomerDto
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
        /// Customer category ID
        /// </summary>
        [Required]
        public int CustomerCategoryID { get; set; }
        /// <summary>
        /// Valid date end. Default is maximum date value
        /// </summary>
        public DateTime ValidTo { get; set; }

    }
}
