using FoodWebsite.Data.Static;
using FoodWebsite.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodWebsite.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();
                //Categories
                if (!context.Category.Any())
                {
                    context.Category.AddRange(new List<Categories>()
                    {
                        new Categories()
                        {
                            CategoryName = "Drinks",
                            Description = "This category contains drinks."
                        },
                        new Categories()
                        {
                            CategoryName = "Salads",
                            Description = "This category contains salads."

                        },
                        new Categories()
                        {
                            CategoryName = "Pasta",
                            Description = "This category contains pastas."
                        }
                    });
                }
                //Recipe
                if (!context.Recipes.Any())
                {
                    context.Recipes.AddRange(new List<Recipe>()
                    {
                        new Recipe()
                        {
                            PhotoURL ="https://sweetandsavorymeals.com/wp-content/uploads/2020/01/Detox-Water-Recipe-2.jpg",
                            RecipeName = "Detox Water",
                            RecipeDescription = "A water that has been infused with the flavors of fresh fruits.",
                        },
                        new Recipe()
                        {
                            PhotoURL = "https://www.nudie.com.au/wp-content/uploads/2020/10/juice.jpg",
                            RecipeName = "Orange Juice",
                            RecipeDescription = "Made with fresh oranges and love.",
                        },
                        new Recipe()
                        {
                            PhotoURL = "https://ifoodreal.com/wp-content/uploads/2014/12/FG-how-to-make-lemon-water.jpg",
                            RecipeName = "Lemon Juice",
                            RecipeDescription = "Made with fresh lemons and love.",
                        },
                        new Recipe()
                        {
                            PhotoURL = "https://www.cookingclassy.com/wp-content/uploads/2018/02/greek-salad-4.jpg",
                            RecipeName = "Greek Salad",
                            RecipeDescription = "Made with cheese,feta,tomatoes,cucumber,olives,olive oil,lemons,bell pepper,red onion and red wine vinegar.",
                        },
                        new Recipe()
                        {
                            PhotoURL = "https://healthyfitnessmeals.com/wp-content/uploads/2021/04/Southwest-chicken-salad-7.jpg",
                            RecipeName = "Chicken Salad",
                            RecipeDescription = "Made with chicken,mayonnaise,lettuce,tomatoes,boiled eggs,celery,onion,pepper,pickles and mustard.",
                        },
                        new Recipe()
                        {
                            PhotoURL = "https://natashaskitchen.com/wp-content/uploads/2019/01/Caesar-Salad-Recipe-3.jpg",
                            RecipeName = "Caesar Salad",
                            RecipeDescription = "Made with romaine lettuce,croutons,parmesan,lemon juice,olive oil,,dijon mustard,salt,pepper and bites of bread.",
                        },
                        new Recipe()
                        {
                            PhotoURL ="https://www.cookingclassy.com/wp-content/uploads/2020/10/spaghetti-carbonara-01.jpg",
                            RecipeName = "Pasta Carbonara",
                            RecipeDescription = "Made with just spaghetti,carbonara is made with pancetta,eggs,parmesan,olive oil,salt and pepper.",
                        },
                        new Recipe()
                        {
                            PhotoURL ="https://bigoven-res.cloudinary.com/image/upload/t_recipe-1280/spaghetti-bolognese-36d090.jpg",
                            RecipeName = "Pasta Bolognese",
                            RecipeDescription = "Made with spaghetti,bolognese is made with ground meat like beef or pork,onions,carrots,celery,tomatoes and a little bit of milk.",
                        },
                        new Recipe()
                        {
                            PhotoURL ="https://recipetineats.com/wp-content/uploads/2019/02/Pesto-Pasta_2-1.jpg",
                            RecipeName = "Pasta Pesto",
                            RecipeDescription = "Made with spaghetti,pesto is made with basil,garlic,olive oil,grated hard cheese and pine nuts.",
                        }
                    });
                }

            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@foodwebsite.com";
                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding1234!");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@foodwebsite.com";
                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding1234!");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
