﻿using FriendOrganizer.Model;
using System.Data.Entity.Migrations;

namespace FriendOrganizer.DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<FriendOrganizer.DataAccess.FriendOrganizerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FriendOrganizer.DataAccess.FriendOrganizerDbContext context)
        {
            context.Friends.AddOrUpdate(
                f => f.FirstName,
                 new Friend { FirstName = "Thomas", LastName = "Huber" },
                 new Friend { FirstName = "Andreas", LastName = "Boehler" },
                 new Friend { FirstName = "Julia", LastName = "Huber" },
                 new Friend { FirstName = "Chrissi", LastName = "Egin" },
                 new Friend { FirstName = "Martin", LastName = "Lavoi" }
                 );
        }
    }
}
