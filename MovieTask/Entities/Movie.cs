namespace MovieTask.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Year { get; set; }
        public int RunTime { get; set; }
        public string? Genre { get; set; }
        public string? Director { get; set; }
    }
}
