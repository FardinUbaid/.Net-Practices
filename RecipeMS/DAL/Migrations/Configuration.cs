namespace DAL.Migrations
{
    using DAL.EF;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.EF.Context context)
        {
            /*
            // Adding a single user
            var user = new User
            {
                Name = "Fardin",
                Email = "fardinkenway@gmail.com",
                Password = "123",
            };

            context.Users.AddOrUpdate(u => u.Email, user);
            context.SaveChanges();

            // Adding multiple recipes for the user
            var recipes = new List<Recipe>
    {
        new Recipe{
            Title = "Beef Curry",
            Ingredients = "Beef, onions, garlic, ginger, chili, turmeric, spices",
            Instructions = "Marinate beef, sauté onions, add spices, cook beef until tender.",
            UserId = user.Id
        },
        new Recipe{
            Title = "Hilsa Fish Fry",
            Ingredients = "Hilsa fish, turmeric, mustard oil, salt",
            Instructions = "Marinate fish with turmeric and salt, fry in mustard oil.",
            UserId = user.Id
        },
        new Recipe{
            Title = "Panta Bhat",
            Ingredients = "Cooked rice, water, salt, onion, green chili",
            Instructions = "Soak rice in water overnight, serve with onions and chili.",
            UserId = user.Id
        }
    };

            recipes.ForEach(r => context.Recipes.AddOrUpdate(rec => rec.Title, r));
            context.SaveChanges();

            // Adding ratings for the recipes
            var ratings = new List<Rating>
    {
        new Rating{
            RecipeId = recipes[0].Id,
            UserId = user.Id,
            Value = 5,
            RatedAt = DateTime.Now
        },
        new Rating{
            RecipeId = recipes[1].Id,
            UserId = user.Id,
            Value = 4,
            RatedAt = DateTime.Now
        },
        new Rating{
            RecipeId = recipes[2].Id,
            UserId = user.Id,
            Value = 3,
            RatedAt = DateTime.Now
        }
    };

            ratings.ForEach(r => context.Ratings.AddOrUpdate(rate => new { rate.RecipeId, rate.UserId }, r));
            context.SaveChanges();

            */
        }


    }
}
