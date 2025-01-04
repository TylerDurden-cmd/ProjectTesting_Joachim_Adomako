# Product Reordering System

This project is a product reordering system that determines which products need to be reordered based on their current stock, minimum stock, and expected demand.

## Features

- Determine which products need to be reordered.
- Handle multiple products with mixed stock levels.
- Unit tests to ensure the correctness of the reordering logic.
- Acceptance tests using Gherkin syntax.

## Project Structure

- **UnitTest.cs**: Contains unit tests for the reordering logic.
- **Product.feature**: Contains acceptance tests written in Gherkin syntax.
- **Product.cs**: Defines the `Product` class.
- **IProductService.cs**: Defines the `IProductService` interface.
- **MockProductService.cs**: A mock implementation of `IProductService`.
- **Reorder.cs**: Contains the logic to determine which products need to be reordered.
- **ReorderStepDefinition.cs**: Step definitions for the Gherkin feature file.

## Class Diagram

The class diagram for this project can be found in the `ClassDiagram.puml` file. You can view it using PlantUML.

## Getting Started

### Prerequisites

- .NET 8
- Visual Studio or Visual Studio Code
- PlantUML (for viewing the class diagram)

### Running the Tests

1. Open the solution in Visual Studio.
2. Build the solution to restore the dependencies.
3. Run the unit tests using the Test Explorer.

### Running the Acceptance Tests

1. Open the solution in Visual Studio.
2. Build the solution to restore the dependencies.
3. Run the acceptance tests using the Test Explorer.

## Usage

To use the reordering system, create an instance of the `Reorder` class and pass an implementation of `IProductService` to it. Call the `DetermineReorder` method to get the list of products that need to be reordered.


## Test Scenarios

### Unit Tests

1. **DetermineReorder_Returns_EmptyList_WhenStockSufficient**
   - **Description**: Verifies that no products are added to the reorder list when the current stock is sufficient.
   - **Test Data**:
     - Playstation 5: CurrentStock = 30, MinStock = 12, ExpectedDemand = 5
     - iPhone 14: CurrentStock = 30, MinStock = 10, ExpectedDemand = 5
     - Zenbook: CurrentStock = 20, MinStock = 18, ExpectedDemand = 5
   - **Expected Result**: The reorder list should be empty.

2. **DetermineReorder_Returns_ExceptionWhenCurrentStock_LessThan_0**
   - **Description**: Verifies that an exception is thrown when the current stock is less than 0.
   - **Test Data**:
     - JBL Speaker: CurrentStock = -1, MinStock = 3, ExpectedDemand = 20
   - **Expected Result**: An `ArgumentException` should be thrown.

3. **DetermineReorder_AddsProductToReorderList_WhenCurrentStockLessThanMinStock**
   - **Description**: Verifies that a product is added to the reorder list when the current stock is less than the minimum stock.
   - **Test Data**:
     - JBL Speaker: CurrentStock = 2, MinStock = 3, ExpectedDemand = 20
   - **Expected Result**: The reorder list should contain "JBL Speaker".

4. **DetermineReorder_DoesNotAddProductToReorderList_WhenCurrentStockGreaterThanMinStock**
   - **Description**: Verifies that a product is not added to the reorder list when the current stock is greater than the minimum stock.
   - **Test Data**:
     - JBL Speaker: CurrentStock = 4, MinStock = 3, ExpectedDemand = 20
   - **Expected Result**: The reorder list should be empty.

5. **DetermineReorder_HandlesMultipleProductsWithMixedStockLevels**
   - **Description**: Verifies that the reorder list is correctly determined for multiple products with mixed stock levels.
   - **Test Data**:
     - JBL Speaker: CurrentStock = 2, MinStock = 3, ExpectedDemand = 20
     - Playstation 5: CurrentStock = 30, MinStock = 12, ExpectedDemand = 5
     - iPhone 14: CurrentStock = 10, MinStock = 10, ExpectedDemand = 5
     - Zenbook: CurrentStock = 20, MinStock = 18, ExpectedDemand = 5
   - **Expected Result**: The reorder list should contain "JBL Speaker".

### Acceptance Tests

1. **No products need to be reordered**
   - **Scenario**: No products need to be reordered.
   - **Given**:
     - Playstation 5: CurrentStock = 10, MinStock = 5, ExpectedDemand = 20
     - Xbox Series X: CurrentStock = 15, MinStock = 10, ExpectedDemand = 15
   - **When**: I determine the reorder list.
   - **Then**: The reorder list should be empty.

2. **A product needs to be reordered**
   - **Scenario**: A product needs to be reordered.
   - **Given**:
     - Playstation 5: CurrentStock = 2, MinStock = 5, ExpectedDemand = 20
     - Xbox Series X: CurrentStock = 15, MinStock = 10, ExpectedDemand = 15
   - **When**: I determine the reorder list.
   - **Then**: The reorder list should contain "Playstation 5".

3. **Product stock equals minimum stock**
   - **Scenario**: Product stock equals minimum stock.
   - **Given**:
     - Playstation 5: CurrentStock = 5, MinStock = 5, ExpectedDemand = 20
     - Xbox Series X: CurrentStock = 15, MinStock = 10, ExpectedDemand = 15
   - **When**: I determine the reorder list.
   - **Then**: The reorder list should be empty.

4. **Product stock is greater than minimum stock**
   - **Scenario**: Product stock is greater than minimum stock.
   - **Given**:
     - Playstation 5: CurrentStock = 6, MinStock = 5, ExpectedDemand = 20
     - Xbox Series X: CurrentStock = 15, MinStock = 10, ExpectedDemand = 15
   - **When**: I determine the reorder list.
   - **Then**: The reorder list should be empty.

5. **Multiple products with mixed stock levels**
   - **Scenario**: Multiple products with mixed stock levels.
   - **Given**:
     - Playstation 5: CurrentStock = 2, MinStock = 5, ExpectedDemand = 20
     - Xbox Series X: CurrentStock = 30, MinStock = 10, ExpectedDemand = 15
   - **When**: I determine the reorder list.
   - **Then**: The reorder list should contain "Playstation 5".

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request with your changes.

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.

## Contact

For any questions or suggestions, please open an issue in the repository.
