namespace Exercise4
{
    public class InventoryManager
    {
        public List<Product> Products { get; private set; }

        public InventoryManager()
        {
            Products = new List<Product>();
        }

        public void AddNewProduct(Product product) {
            bool hasProductIntoList = false;
            Product findedProduct = null!;

            foreach (var listedProduct in Products)
            {
                if (listedProduct.Name == product.Name) 
                {
                    hasProductIntoList = true;
                    findedProduct = listedProduct;
                    break;
                }
            }

            if (hasProductIntoList && findedProduct != null)
            {
                findedProduct.IncreaseProductQuantity(1);
                return;
            }

            Products.Add(product);
        }

        public int FindProductQuantity(string productName)
        {
            foreach (var listedProduct in Products)
            {
                if (listedProduct.Name == productName)
                {
                    return listedProduct.Quantity;
                }
            }

            return 0;
        }
    }
}
