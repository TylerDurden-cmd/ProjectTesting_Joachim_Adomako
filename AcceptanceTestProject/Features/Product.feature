Feature: Reordering Products

  Scenario: No products need to be reordered
    Given the product "Playstation 5" has a current stock of 10, a minimum stock of 5, and an expected demand of 20
    And the product "Xbox Series X" has a current stock of 15, a minimum stock of 10, and an expected demand of 15
    When I determine the reorder list
    Then the reorder list should be empty

  Scenario: A product needs to be reordered
    Given the product "Playstation 5" has a current stock of 2, a minimum stock of 5, and an expected demand of 20
    And the product "Xbox Series X" has a current stock of 15, a minimum stock of 10, and an expected demand of 15
    When I determine the reorder list
    Then the reorder list should contain "Playstation 5"

  Scenario: Product stock equals minimum stock
    Given the product "Playstation 5" has a current stock of 5, a minimum stock of 5, and an expected demand of 20
    And the product "Xbox Series X" has a current stock of 15, a minimum stock of 10, and an expected demand of 15
    When I determine the reorder list
    Then the reorder list should be empty

  Scenario: Product stock is greater than minimum stock
    Given the product "Playstation 5" has a current stock of 6, a minimum stock of 5, and an expected demand of 20
    And the product "Xbox Series X" has a current stock of 15, a minimum stock of 10, and an expected demand of 15
    When I determine the reorder list
    Then the reorder list should be empty

  Scenario: Multiple products with mixed stock levels
    Given the product "Playstation 5" has a current stock of 2, a minimum stock of 5, and an expected demand of 20
    And the product "Xbox Series X" has a current stock of 30, a minimum stock of 10, and an expected demand of 15
    When I determine the reorder list
    Then the reorder list should contain "Playstation 5"