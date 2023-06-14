using MovieCharacterAPI.Models;
using System.Collections.Generic;

namespace MovieCharacterAPI.Data
{
    /// <summary>
    /// Class to help seed data in database
    /// </summary>
    public class DataSeedHelper
    {
        /// <summary>
        /// <c>SeedCharacters</c> return demo seeding data for character
        /// </summary>
        /// <returns>List of Character</returns>
        public static List<Character> SeedCharacters()
        {
            List<Character> characters = new List<Character>()
            {
                new Character(){ CharacterId = 1, FullName="Robert Downey Jr.", Alias="Iron Man", Gender="Male"},
                new Character(){ CharacterId = 2, FullName="Chris Hemsworth", Alias="Thor", Gender="Male"},
                new Character(){ CharacterId = 3, FullName="Chris Evans", Alias="Captain America", Gender="Male"},
                new Character(){ CharacterId = 4, FullName="Tom Holland", Alias="Spider Man", Gender="Male"}
            };
            return characters;
        }

        /// <summary>
        /// <c>SeedFranchises</c> return demo seeding data for Franchise
        /// </summary>
        /// <returns>List of Franchise</returns>
        public static List<Franchise> SeedFranchises()
        {
            List<Franchise> franchises = new List<Franchise>()
            {
                new Franchise(){  FranchiseId = 1, Name="Iron Man Series"},
                new Franchise(){  FranchiseId = 2, Name="Spider Man Series"},
                new Franchise(){  FranchiseId = 3, Name="Thor Series"},
                new Franchise(){  FranchiseId = 4, Name="Captain America Series"},
                new Franchise(){  FranchiseId = 5, Name="Marvel Universe"}
            };
            return franchises;
        }

        /// <summary>
        /// <c>SeedMovies</c> return demo seeding data for Movie
        /// </summary>
        /// <returns>List of Movie</returns>
        public static List<Movie> SeedMovies()
        {
            List<Movie> movies = new List<Movie>()
            {
                new Movie(){ MovieId = 1, Title = "Iron Man", ReleaseYear=2008, Director="Jon Favreau" , Genre="Comic Book,Superhero", FranchiseId = 1},
                new Movie(){ MovieId = 2, Title = "Thor", ReleaseYear=2011, Director="Kenneth Branagh" , Genre="Comic Book,Superhero", FranchiseId = 3},
                new Movie(){ MovieId = 3, Title = "The Avengers", ReleaseYear=2012, Director="Joss Whedon" , Genre="Comic Book, Superhero", FranchiseId = 5},
                new Movie(){ MovieId = 4, Title = "SpiderMan Homecoming", ReleaseYear=2017, Director="Jon Watts" , Genre="Comic Book, Superhero", FranchiseId = 2}
            };
            return movies;
        }
    }
}
