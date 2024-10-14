using System.Runtime.Serialization;

namespace GameZone.Data.Models
{
    public static class DataConstants
    {
        public static class Common
        {
            public static string DateTimeFormat = "yyyy-MM-dd";
        }
       
        public static class Game
        {
            public const int MinTitleLength = 2;
            public const int MaxTitleLength = 50;

            public const int MinDescriptionLength = 10;
            public const int MaxDescriptionLength = 500;
        }

        public static class Genre
        {
            public const int MinGenreLength = 3;
            public const int MaxGenreLength = 25;
        }
    }
}
