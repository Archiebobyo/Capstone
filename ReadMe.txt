-- Table `mydb`.`Warehouse`
This table manages all of the information about a Warehouse including contact information in case someone needs it.

-- Table `mydb`.`Customer`
This table manages all of the Customer information and how to contact them.

-- Table `mydb`.`Store`
This table manages all of the Store information including contact information in case someone needs it.

-- Table `mydb`.`Employee`
This table manages all of the Employee personal information, password, who manages them, and their type(clerk, manager, warehouse worker). Users will log in using their email and password.

-- Table `mydb`.`Products`
This table manages all of the Products information.

The below tables are used as join tables for various relationships.

-- Table `mydb`.`CustomerOrder`
This table represents orders a customer makes to a given store. It keeps track of date of order, pickup, and the customer's payment. The CustomerOrderProduct`table represents what products and their quantity in a given order. 

-- Table `mydb`.`CustomerOrderProduct`
This`table represents what products are part of a given customer order and the quantity of each product.

-- Table `mydb`.`InventoryOrder`
This table represents orders a store makes to a warehouse requesting additional inventory of products. It also keeps track of date of order, delivery date, the employee who placed the order, and the manager who approved it. This table basicaly coveres whenever an Employee places a order to a warehouse. The InventoryOrderProduct`table represents what products and the quantity in the order.

-- Table `mydb`.`InventoryOrderProduct`
This`table represents what products are part of a given inventory order and the quantity of each product.

-- Table `mydb`.`WarehouseProduct`
This table tracks products within a warehouse including the quantity on hand in the warehouse. 

-- Table `mydb`.`StoreProduct`
This table tracks products within a store including the quantity on hand in the store. 
