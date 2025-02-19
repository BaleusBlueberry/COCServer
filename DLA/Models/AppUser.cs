﻿using AspNetCore.Identity.Mongo.Model;
using DLA.Models.UserData;

namespace DLA.Models
{
    public class AppUser : MongoUser
    {
        public List<string> FavoriteTownHalls { get; set; } = new List<string>();
        public FavoriteBuildingsModel FavoriteBuildings { get; set; } = new FavoriteBuildingsModel();
    }
    public class AppRole : MongoRole
    {
    }
}