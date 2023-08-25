-- create
CREATE TABLE Product (
  Id INT PRIMARY KEY AUTO_INCREMENT,
  title VARCHAR(50) NOT NULL
);

CREATE TABLE Category (
  Id INT PRIMARY KEY AUTO_INCREMENT,
  title VARCHAR(50) NOT NULL
);

CREATE TABLE Product_Category (
  Id INT PRIMARY KEY AUTO_INCREMENT,
  ProductId INT NOT NULL,
  CategoryId INT NOT NULL,
  INDEX (ProductId),
  INDEX (CategoryId),
  FOREIGN KEY (ProductId) REFERENCES Product (Id),
  FOREIGN KEY (CategoryId) REFERENCES Category (Id)
);

-- insert
INSERT INTO Product (title) 
VALUES ('Помидор'), ('Яблоко'), ('Молоко'), ('Творог'), ('Батончик'), ('Сыр'), ('Филе'), ('Корм для кота'), ('Корм для собаки');

INSERT INTO Category (title) 
VALUES ('Овощи'), ('Фрукты'), ('Молочная прод.'), ('Другое');

INSERT INTO Product_Category (ProductId, CategoryId) 
VALUES (1, 1), (2, 2), (3, 3), (4, 3), (5, 4), (6, 3), (6, 4), (8, 4), (9, 4);

-- fetch 

SELECT Product.title as product, Category.title as category
FROM Product
LEFT JOIN Product_Category on Product.id = Product_Category.ProductId  
LEFT JOIN Category on Product_Category.CategoryId = Category.Id
Order by Category.title;

SELECT Product.title as product, GROUP_CONCAT(Category.title SEPARATOR ', ') as category
FROM Product
LEFT JOIN Product_Category on Product.id = Product_Category.ProductId  
LEFT JOIN Category on Product_Category.CategoryId = Category.Id
group by Product.title
Order by Product.title;