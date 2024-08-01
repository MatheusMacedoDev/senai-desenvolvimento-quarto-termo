using Exercise4;

namespace ExerciseTest4
{
    public class InventoryManagerTest
    {
        [Fact]
        public void AddNewProductTest()
        {
            // Arrange
            var product = new Product(
                name: "Geladera"
            );

            var inventoryManager = new InventoryManager();

            int expectedProductQuantity = 3;

            // Act
            inventoryManager.AddNewProduct( product );
            inventoryManager.AddNewProduct( product );
            inventoryManager.AddNewProduct( product );

            var productQuantityResult =  inventoryManager.FindProductQuantity(product.Name);

            // Assert
            Assert.Equal( expectedProductQuantity, productQuantityResult );
        }

        [Fact]
        public void GetProductQuantityTest()
        {
            // Arrange
            var product = new Product(
                name: "Monitor"
            );

            var inventoryManager = new InventoryManager();

            int expectedProductQuantity = 2;

            inventoryManager.AddNewProduct(product);
            inventoryManager.AddNewProduct(product);

            // Act
            var productQuantityResult = inventoryManager.FindProductQuantity(product.Name);

            // Assert
            Assert.Equal(expectedProductQuantity, productQuantityResult);
        }
    }
}