using Microsoft.EntityFrameworkCore;
using Task_12_Cinema.Models;

namespace Task_12_Cinema.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            _modelBuilder.Entity<Genre>(x =>
            {
                x.HasData(new Genre()
                {
                    Id = 1,
                    Name = "Action",
                    Description = "Associated with particular types of spectacle (e.g., explosions, chases, combat)."
                });
                x.HasData(new Genre()
                {
                    Id = 2,
                    Name = "Adventure",
                    Description = "Implies a narrative that is defined by a journey (often including some form of pursuit) " +
                                  "and is usually located within a fantasy or exoticized setting."
                });
                x.HasData(new Genre()
                {
                    Id = 3,
                    Name = "Comedy",
                    Description = "Defined by events that are primarily intended to make the audience laugh."
                });
                x.HasData(new Genre()
                {
                    Id = 4,
                    Name = "Drama",
                    Description = "Focused on emotions and defined by conflict, often looking to reality rather than sensationalism."
                });
                x.HasData(new Genre()
                {
                    Id = 5,
                    Name = "Fantasy",
                    Description = "Films defined by situations that transcend natural laws and/or by settings inside a " +
                                  "fictional universe, with narratives that are often inspired by or involve human myths."
                });
                x.HasData(new Genre()
                {
                    Id = 6,
                    Name = "Horror",
                    Description = "Films that seek to elicit fear or disgust in the audience for entertainment purposes."
                });
            });

            _modelBuilder.Entity<Director>(x =>
            {
                x.HasData(new Director()
                {
                    Id = 1,
                    FirstName = "Martin",
                    MiddleName = null,
                    LastName = "Scorsese",
                    ShortBio = "We`re talking about the guy who made Taxi Driver here! No one has more classics than Scorsese, " +
                                "including directors like James Cameron and David Fincher. His resume includes Raging Bull, Goodfellas, " +
                                "Mean Streets, Cape Fear, Shutter Island, and The Last Waltz. Famously, it took Scorsese a while to win an Oscar," +
                                " but they eventually gave him one for The Departed."
                });
                x.HasData(new Director()
                {
                    Id = 2,
                    FirstName = "Guillermo",
                    MiddleName = null,
                    LastName = "del Toro",
                    ShortBio = "For the longest time, Guillermo del Toro was one of those under-the-radar directors. Then he made Pan`s Labyrinth," +
                               " Hellboy, and The Shape of Water. Now you can`t watch a football game without seeing an ad for Nightmare Alley. His success is " +
                               "further proof that good work+hard work will eventually= acclaim."
                });
                x.HasData(new Director()
                {
                    Id = 3,
                    FirstName = "Christopher",
                    MiddleName = null,
                    LastName = "Nolan",
                    ShortBio = "Like Fincher, Nolan is a track-record director. He`s 11 for 11 on feature films. Sure, he`s only made a couple of " +
                               "great films (Dunkirk, The Dark Knight), but he`s never made a movie that isn`t worth watching."
                });
                x.HasData(new Director()
                {
                    Id = 4,
                    FirstName = "James",
                    MiddleName = null,
                    LastName = "Cameron",
                    ShortBio = "Is anyone talking about Apichatapong? Not really. Cameron, on the other hand? He`s a living legend. " +
                               "He`s discussed more than any other director on here. Whether we`re talking about Terminator 2 or The Titanic, " +
                               "Cameron has managed to stay relevant for as long as I`ve been alive. His Avatar films will keep it that way for years to come."
                });
                x.HasData(new Director()
                {
                    Id = 5,
                    FirstName = "Steven",
                    MiddleName = null,
                    LastName = "Spielberg",
                    ShortBio = "Pick an age, any age: Spielberg has the power to make you feel like a kid again. It doesn`t matter if you`re 8 or 88," +
                               " ET,  Indiana Jones, and Jurassic Park will have you grinning from ear-to-ear. Even at 75, the man is still finding ways to make us smile. "
                });
            });

            _modelBuilder.Entity<Film>(x =>
            {
                x.HasData(new Film()
                {
                    Id = 1,
                    Name = "Killers of the Flower Moon",
                    GenreId = 4,
                    DirectorId = 1,
                    Description = "Its plot centers on a series of Oklahoma murders in the Osage Nation during the 1920s, committed after oil was discovered on tribal land."
                });
                x.HasData(new Film()
                {
                    Id = 2,
                    Name = "Shutter Island",
                    GenreId = 6,
                    DirectorId = 1,
                    Description = "In 1954, U.S. Marshal Edward \"Teddy\" Daniels and his new partner Chuck Aule travel to Ashecliffe Hospital " +
                                  "for the criminally insane on Shutter Island, Boston Harbor to investigate the disappearance of Rachel Solando, a patient " +
                                  "of the hospital who had previously drowned her three children."
                });
                x.HasData(new Film()
                {
                    Id = 3,
                    Name = "Hellboy",
                    GenreId = 2,
                    DirectorId = 2,
                    Description = "The film draws inspiration from the debut comic Hellboy: Seed of Destruction. In the film, a charismatic " +
                                  "demon-turned-investigator named \"Hellboy\" works with the secretive Bureau of Paranormal " +
                                  "Research and Defense to suppress paranormal threats, but a resurrected sorcerer seeks to make Hellboy " +
                                  "fulfill his destiny by triggering the apocalypse."
                });
                x.HasData(new Film()
                {
                    Id = 4,
                    Name = "Interstellar",
                    GenreId = 5,
                    DirectorId = 3,
                    Description = "In 2067, humanity is facing extinction following a global famine caused by ecocide. " +
                                  "As a result, ex-NASA pilot, Joseph Cooper, is forced to work as a farmer, with his son Tom," +
                                  " daughter Murph and father-in-law Donald."
                });
                x.HasData(new Film()
                {
                    Id = 5,
                    Name = "The Terminator",
                    GenreId = 1,
                    DirectorId = 4,
                    Description = "Two men arrive separately in 1984 Los Angeles, having time traveled from 2029. One is a " +
                                  "cybernetic assassin known as a Terminator, programmed to hunt and kill a woman named Sarah Connor. " +
                                  "The other is a human soldier named Kyle Reese, intent on stopping it. They both steal guns and clothing."
                });
                x.HasData(new Film()
                {
                    Id = 6,
                    Name = "Catch Me If You Can",
                    GenreId = 2,
                    DirectorId = 5,
                    Description = "In 1969, FBI agent Carl Hanratty arrives in Marseille, France," +
                                  " to pick up a prisoner named Frank Abagnale Jr. who became ill due to the prison`s conditions."
                });
            });

            _modelBuilder.Entity<Session>(x =>
            {
                x.HasData(new Session()
                {
                    Id = 1,
                    EventDateTime = Convert.ToDateTime("2023/11/01 18:00"),
                    FilmId = 1
                });
                x.HasData(new Session()
                {
                    Id = 2,
                    EventDateTime = Convert.ToDateTime("2023/11/02 20:00"),
                    FilmId = 1
                });
                x.HasData(new Session()
                {
                    Id = 3,
                    EventDateTime = Convert.ToDateTime("2023/11/01 19:00"),
                    FilmId = 2
                });
                x.HasData(new Session()
                {
                    Id = 4,
                    EventDateTime = Convert.ToDateTime("2023/11/02 20:00"),
                    FilmId = 2
                });
                x.HasData(new Session()
                {
                    Id = 5,
                    EventDateTime = Convert.ToDateTime("2023/11/01 18:00"),
                    FilmId = 3
                });
                x.HasData(new Session()
                {
                    Id = 6,
                    EventDateTime = Convert.ToDateTime("2023/11/02 18:00"),
                    FilmId = 3
                });
                x.HasData(new Session()
                {
                    Id = 7,
                    EventDateTime = Convert.ToDateTime("2023/11/03 19:00"),
                    FilmId = 4
                });
                x.HasData(new Session()
                {
                    Id = 8,
                    EventDateTime = Convert.ToDateTime("2023/11/02 20:00"),
                    FilmId = 4
                });
                x.HasData(new Session()
                {
                    Id = 9,
                    EventDateTime = Convert.ToDateTime("2023/11/02 17:00"),
                    FilmId = 5
                });
                x.HasData(new Session()
                {
                    Id = 10,
                    EventDateTime = Convert.ToDateTime("2023/11/03 20:00"),
                    FilmId = 5
                });
                x.HasData(new Session()
                {
                    Id = 11,
                    EventDateTime = Convert.ToDateTime("2023/11/03 21:00"),
                    FilmId = 6
                });
                x.HasData(new Session()
                {
                    Id = 12,
                    EventDateTime = Convert.ToDateTime("2023/11/04 18:00"),
                    FilmId = 6
                });
            });
        }
    }
}
