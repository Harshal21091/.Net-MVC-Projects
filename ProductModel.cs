using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryModels
{
    public class ProductModel
    {
        public int PRODUCT_ID { get; set; }

        [Required]
        public string PRODUCT_NAME { get; set; }

        [Required]
        public string DISCRIPTTION { get; set; }

        [Required]
        public string CATEGORY { get; set; }

        [Required]
        public int RETAIL_PRICE { get; set; }

        [Required]
        public int ACTUAL_PRICE { get; set; }

    }

    public class PurchaseModel
    {

    }
}
