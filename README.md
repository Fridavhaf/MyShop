# MyShop: MVC Project using the ASP.NET Core

## Project Overview
This project is a simple online shop developed as part of the ITPE3200 Web Applications course.
It demonstrates core ASP.NET Core MVC concepts, best practices for structuring a maintainable web application, and basic database integration with SQLite using Entity Framework Core.
The project includes full CRUD functionality for products, allowing users to create, read, update, and delete items directly in the application.

The project includes:
- **Table View:** Displays products in a tabular format.
- **Grid View:** Displays products in a responsive card layout.
- **Details View:** Shows detailed information for each product.
- **Partial Views:** `_ItemCard`, `_ItemTable`, and `_Carousel` for reusable UI components.
- **ViewModel:** `ItemsViewModel` to pass data from controllers to views cleanly.

## Features
- Responsive layout using Bootstrap.
- Dynamic carousel on the Home Page.
- Separation of concerns with controllers, models, views, and partial views.
- Use of Razor syntax for rendering dynamic content.
- Database integration: Uses SQLite with EF Core for data persistence. Mock data in ItemController replaced with real database queries.
- Full CRUD operations for products
- Verified database setup and data insertion using DB Browser for SQLite.
