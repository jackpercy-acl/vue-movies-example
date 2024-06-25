namespace MoviesApi;

internal class Movie
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public string Summary { get; set; }
    public string Director { get; set; }
    public List<string> Genres { get; set; }
    public List<Actor> Actors { get; set; } = [];
    public string PosterPath { get; set; }
}

internal class Actor
{
    public string Name { get; set; }
}