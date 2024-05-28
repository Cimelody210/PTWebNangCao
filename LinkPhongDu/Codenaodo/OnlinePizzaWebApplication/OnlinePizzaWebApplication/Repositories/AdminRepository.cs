using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using OnlinePizzaWebApplication.Data;
using OnlinePizzaWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlinePizzaWebApplication.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _context;
        private readonly IServiceProvider _serviceProvider;

        public AdminRepository(AppDbContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public void SeedDatabase()
        {
            var _roleManager = _serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var _userManager = _serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            var cat1 = new Categories { Name = "Tiêu Chuẩn", Description = "Các loại pizza Tiêu Chuẩn của cửa hàng bánh quanh năm." };
            var cat2 = new Categories { Name = "Đặc Biệt", Description = "Các loại pizza Đặc Biệt của cửa hàng bánh chỉ có trong một khoảng thời gian hạn chế." };
            var cat3 = new Categories { Name = "Mới", Description = "Các loại pizza Mới của cửa hàng bánh trên thực đơn." };

            var cats = new List<Categories>()
            {
                cat1, cat2, cat3
            };

            var piz1 = new Pizzas { Name = "Capricciosa", Price = 70.00M, Category = cat1, Description = "Một chiếc pizza bình thường với hương vị từ rừng.", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/2/2a/Pizza_capricciosa.jpg", IsPizzaOfTheWeek = false };
            var piz2 = new Pizzas { Name = "Rau Củ", Price = 70.00M, Category = cat3, Description = "Pizza Rau Củ cho người ăn chay", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/3f/Vegetarian_pizza.jpg", IsPizzaOfTheWeek = false };
            var piz3 = new Pizzas { Name = "Hawaii", Price = 75.00M, Category = cat1, Description = "Một chiếc pizza có hương vị đặc biệt từ Hawaii.", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/d/d1/Hawaiian_pizza_1.jpg", IsPizzaOfTheWeek = true };
            var piz4 = new Pizzas { Name = "Margarita", Price = 65.00M, Category = cat1, Description = "Một chiếc pizza cơ bản cho mọi người.", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/a/a3/Eq_it-na_pizza-margherita_sep2005_sml.jpg", IsPizzaOfTheWeek = false };
            var piz5 = new Pizzas { Name = "Đặc Biệt Kebab", Price = 85.00M, Category = cat2, Description = "Một chiếc pizza đặc biệt với kebab cho những người đói.", ImageUrl = "http://2.bp.blogspot.com/_3cSn3Qz_4IA/THkYqKwGw1I/AAAAAAAAAPg/ybKpvRbjDWE/s1600/matsl%C3%A4kten+002.JPG", IsPizzaOfTheWeek = true };
            var piz6 = new Pizzas { Name = "Pescatore", Price = 80.00M, Category = cat1, Description = "Một chiếc pizza với hương vị từ đại dương.", ImageUrl = "https://isinginthekitchen.files.wordpress.com/2014/07/dsc_0231.jpg", IsPizzaOfTheWeek = true };
            var piz7 = new Pizzas { Name = "Barcelona", Price = 70.00M, Category = cat1, Description = "Một chiếc pizza với hương vị từ Tây Ban Nha, Barcelona", ImageUrl = "http://barcelona-home.com/blog/wp-content/upload/pizza/Pizzeria%20Los%20Amigos/pizza-jamon-dulce-y-champinone.jpg", IsPizzaOfTheWeek = false };
            var piz8 = new Pizzas { Name = "Flying Jacob", Price = 89.00M, Category = cat2, Description = "Pizza bay từ trên trời, với hương vị của chuối.", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/6/64/Pizza_Hawaii_Special_p%C3%A5_Pizzeria_Papillon_i_Sala_1343.jpg", IsPizzaOfTheWeek = false };
            var piz9 = new Pizzas { Name = "Kentucky", Price = 69.00M, Category = cat3, Description = "Một chiếc pizza từ Mỹ với hương vị của Gà Kentucky.", ImageUrl = "https://media-cdn.tripadvisor.com/media/photo-s/15/64/e0/0b/kentucky-pizza-bar.jpg", IsPizzaOfTheWeek = false };
            var piz10 = new Pizzas { Name = "La Carne", Price = 75.00M, Category = cat1, Description = "Pizza Ý với nhiều loại thịt ngon.", ImageUrl = "https://imag.bonviveur.com/pizza-de-carne-picada.jpg", IsPizzaOfTheWeek = false };

            var pizs = new List<Pizzas>()
            {
                piz1, piz2, piz3, piz4, piz5, piz6, piz7, piz8, piz9, piz10
            };

            var user1 = new IdentityUser { UserName = "user1@gmail.com", Email = "user1@gmail.com" };
            var user2 = new IdentityUser { UserName = "user2@gmail.com", Email = "user2@gmail.com" };
            var user3 = new IdentityUser { UserName = "user3@gmail.com", Email = "user3@gmail.com" };
            var user4 = new IdentityUser { UserName = "user4@gmail.com", Email = "user4@gmail.com" };
            var user5 = new IdentityUser { UserName = "user5@gmail.com", Email = "user5@gmail.com" };

            string userPassword = "Password123";

            var users = new List<IdentityUser>()
            {
                user1, user2, user3, user4, user5
            };

            foreach (var user in users)
            {
                _userManager.CreateAsync(user, userPassword).Wait();
            }

            var revs = new List<Reviews>()
            {
                new Reviews { User = user1, Title ="Pizza Ngon Nhất với nấm", Description="Tôi thích Pizza này với nấm.", Grade=4, Date=DateTime.Now, Pizza = piz1 },
                new Reviews { User = user2, Title ="Pizza Tệ Nhất với nấm", Description="Tôi ghét Pizza này với nấm.", Grade=1, Date=DateTime.Now.AddDays(-1), Pizza = piz1 },
                new Reviews { User = user2, Title ="Chỉ Có Rau Không Vị", Description="Rau nhạt trên Pizza ướt này.", Grade=1, Date=DateTime.Now, Pizza = piz2 },
                new Reviews { User = user3, Title ="Pizza Rau Củ Tuyệt Vời", Description="Lựa chọn tốt nếu bạn là người ăn chay.", Grade=5, Date=DateTime.Now.AddDays(-6), Pizza = piz2 },
                new Reviews { User = user4, Title ="Dứa Tuyệt Vời", Description="Tôi thích hương vị của dứa trên pizza này.", Grade=4, Date=DateTime.Now.AddDays(-4), Pizza = piz3 },
                new Reviews { User = user1, Title ="Quá Đơn Giản", Description="Pizza quá đơn giản, với giá cao như vậy.", Grade=2, Date=DateTime.Now.AddDays(-2), Pizza = piz4 },
                new Reviews { User = user5, Title ="Siêu Đặc Biệt", Description="Pizza siêu đặc biệt, hương vị tốt nhất trên thế giới!", Grade=5, Date=DateTime.Now.AddDays(-9), Pizza = piz5 },
            };


            var ing1 = new Ingredients { Name = "Phô Mai" };
            var ing2 = new Ingredients { Name = "Bột" };
            var ing3 = new Ingredients { Name = "Sốt Cà Chua" };
            var ing4 = new Ingredients { Name = "Rau Diếp" };
            var ing5 = new Ingredients { Name = "Nấm" };
            var ing6 = new Ingredients { Name = "Thịt Kebab" };
            var ing7 = new Ingredients { Name = "Tôm" };
            var ing8 = new Ingredients { Name = "Dứa" };
            var ing9 = new Ingredients { Name = "Giăm Bông" };
            var ing10 = new Ingredients { Name = "Bông Cải" };
            var ing11 = new Ingredients { Name = "Hành Tây" };
            var ing12 = new Ingredients { Name = "Olive" };
            var ing13 = new Ingredients { Name = "Chuối" };
            var ing14 = new Ingredients { Name = "Thịt Gà" };
            var ing15 = new Ingredients { Name = "Cà Chua" };
            var ing16 = new Ingredients { Name = "Thịt Băm" };

            var ings = new List<Ingredients>()
            {
                ing1, ing2, ing3, ing4, ing5, ing6, ing7, ing8, ing9, ing10, ing11, ing12, ing13, ing14, ing15, ing16
            };

            var pizIngs = new List<PizzaIngredients>()
            {
                new PizzaIngredients { Ingredient = ing1, Pizza = piz1 },
                new PizzaIngredients { Ingredient = ing2, Pizza = piz1 },
                new PizzaIngredients { Ingredient = ing3, Pizza = piz1 },
                new PizzaIngredients { Ingredient = ing5, Pizza = piz1 },
                new PizzaIngredients { Ingredient = ing9, Pizza = piz1 },

                new PizzaIngredients { Ingredient = ing1, Pizza = piz2 },
                new PizzaIngredients { Ingredient = ing2, Pizza = piz2 },
                new PizzaIngredients { Ingredient = ing3, Pizza = piz2 },
                new PizzaIngredients { Ingredient = ing4, Pizza = piz2 },
                new PizzaIngredients { Ingredient = ing10, Pizza = piz2 },

                new PizzaIngredients { Ingredient = ing1, Pizza = piz3 },
                new PizzaIngredients { Ingredient = ing2, Pizza = piz3 },
                new PizzaIngredients { Ingredient = ing3, Pizza = piz3 },
                new PizzaIngredients { Ingredient = ing8, Pizza = piz3 },
                new PizzaIngredients { Ingredient = ing9, Pizza = piz3 },

                new PizzaIngredients { Ingredient = ing1, Pizza = piz4 },
                new PizzaIngredients { Ingredient = ing2, Pizza = piz4 },
                new PizzaIngredients { Ingredient = ing3, Pizza = piz4 },

                new PizzaIngredients { Ingredient = ing1, Pizza = piz5 },
                new PizzaIngredients { Ingredient = ing2, Pizza = piz5 },
                new PizzaIngredients { Ingredient = ing3, Pizza = piz5 },
                new PizzaIngredients { Ingredient = ing6, Pizza = piz5 },
                new PizzaIngredients { Ingredient = ing4, Pizza = piz5 },
                new PizzaIngredients { Ingredient = ing11, Pizza = piz5 },

                new PizzaIngredients { Ingredient = ing1, Pizza = piz6 },
                new PizzaIngredients { Ingredient = ing2, Pizza = piz6 },
                new PizzaIngredients { Ingredient = ing3, Pizza = piz6 },
                new PizzaIngredients { Ingredient = ing4, Pizza = piz6 },
                new PizzaIngredients { Ingredient = ing7, Pizza = piz6 },

                new PizzaIngredients { Ingredient = ing1, Pizza = piz7 },
                new PizzaIngredients { Ingredient = ing2, Pizza = piz7 },
                new PizzaIngredients { Ingredient = ing3, Pizza = piz7 },
                new PizzaIngredients { Ingredient = ing5, Pizza = piz7 },
                new PizzaIngredients { Ingredient = ing11, Pizza = piz7 },
                new PizzaIngredients { Ingredient = ing12, Pizza = piz7 },

                new PizzaIngredients { Ingredient = ing1, Pizza = piz8 },
                new PizzaIngredients { Ingredient = ing2, Pizza = piz8 },
                new PizzaIngredients { Ingredient = ing3, Pizza = piz8 },
                new PizzaIngredients { Ingredient = ing5, Pizza = piz8 },
                new PizzaIngredients { Ingredient = ing8, Pizza = piz8 },
                new PizzaIngredients { Ingredient = ing13, Pizza = piz8 },

                new PizzaIngredients { Ingredient = ing1, Pizza = piz9 },
                new PizzaIngredients { Ingredient = ing2, Pizza = piz9 },
                new PizzaIngredients { Ingredient = ing3, Pizza = piz9 },
                new PizzaIngredients { Ingredient = ing14, Pizza = piz9 },
                new PizzaIngredients { Ingredient = ing15, Pizza = piz9 },

                new PizzaIngredients { Ingredient = ing1, Pizza = piz10 },
                new PizzaIngredients { Ingredient = ing2, Pizza = piz10 },
                new PizzaIngredients { Ingredient = ing3, Pizza = piz10 },
                new PizzaIngredients { Ingredient = ing9, Pizza = piz10 },
                new PizzaIngredients { Ingredient = ing16, Pizza = piz10 },

            };

            var ord1 = new Order
            {
                FirstName = "Huy",
                LastName = "Quang",
                AddressLine1 = "71 An Binh",
                City = "Da Lat",
                Country = "Viet Nam",
                Email = "buro@gmail.com",
                OrderPlaced = DateTime.Now.AddDays(-2),
                PhoneNumber = "0123456789",
                User = user1,
                ZipCode = "43210",
                OrderTotal = 370.00M,
            };

            var ord2 = new Order { };
            var ord3 = new Order { };

            var orderLines = new List<OrderDetail>()
            {
                new OrderDetail { Order=ord1, Pizza=piz1, Amount=2, Price=piz1.Price},
                new OrderDetail { Order=ord1, Pizza=piz3, Amount=1, Price=piz3.Price},
                new OrderDetail { Order=ord1, Pizza=piz5, Amount=3, Price=piz5.Price},
            };

            var orders = new List<Order>()
            {
                ord1
            };

            _context.Categories.AddRange(cats);
            _context.Pizzas.AddRange(pizs);
            _context.Reviews.AddRange(revs);
            _context.Orders.AddRange(orders);
            _context.OrderDetails.AddRange(orderLines);
            _context.Ingredients.AddRange(ings);
            _context.PizzaIngredients.AddRange(pizIngs);

            _context.SaveChanges();
        }

        public void ClearDatabase()
        {
            var pizzaIngredients = _context.PizzaIngredients.ToList();
            _context.PizzaIngredients.RemoveRange(pizzaIngredients);

            var ingredients = _context.Ingredients.ToList();
            _context.Ingredients.RemoveRange(ingredients);

            var reviews = _context.Reviews.ToList();
            _context.Reviews.RemoveRange(reviews);

            var shoppingCartItems = _context.ShoppingCartItems.ToList();
            _context.ShoppingCartItems.RemoveRange(shoppingCartItems);

            var users = _context.Users.ToList();
            var userRoles = _context.UserRoles.ToList();

            foreach (var user in users)
            {
                if (!userRoles.Any(r => r.UserId == user.Id))
                {
                    _context.Users.Remove(user);
                }
            }

            var orderDetails = _context.OrderDetails.ToList();
            _context.OrderDetails.RemoveRange(orderDetails);

            var orders = _context.Orders.ToList();
            _context.Orders.RemoveRange(orders);

            var pizzas = _context.Pizzas.ToList();
            _context.Pizzas.RemoveRange(pizzas);

            var categories = _context.Categories.ToList();
            _context.Categories.RemoveRange(categories);

            _context.SaveChanges();
        }

    }
}
