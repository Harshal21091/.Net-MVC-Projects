using InventoryDAL;
using InventoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryBusinessLogic
{
    public class ProductBL
    {
        public List<ProductModel> GetProductList()
        {
            ProductDAL pdal = new ProductDAL();
            return pdal.GetProductList();
        }

        public string AddProduct(ProductModel model)
        {
            ProductDAL pdal = new ProductDAL();
            return pdal.AddProduct(model);
        }

        public ProductModel Edit(int id)
        {
            ProductDAL pdal = new ProductDAL();
            return pdal.Edit(id);
        }
        public string Delete(int id)
        {
            ProductDAL pdal = new ProductDAL();
            return pdal.Delete(id);
        }
    }
}
