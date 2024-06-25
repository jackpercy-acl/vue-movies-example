using MoviesApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(cors =>
{
    cors.AllowAnyOrigin();
    cors.AllowAnyMethod();
    cors.AllowAnyHeader();
});

List<Movie> movies = new()
{
    new()
    {
        Id = Guid.NewGuid(),
        Title = "Shrek",
        Year = 2001,
        Summary = "A mean lord exiles fairytale creatures to the swamp of a grumpy ogre, who must go on a quest and rescue a princess for the lord in order to get his land back.",
        Director = "Andrew Adamson",
        Genres = [
            "Animation",
            "Family",
            "Fantasy"
        ],
        Actors = [
            new()
            {
                Name = "Mike Myers"
            },
            new()
            {
                Name = "Eddie Murphy"
            },
            new()
            {
                Name = "Cameron Diaz"
            }
        ],
        PosterPath = "https://m.media-amazon.com/images/M/MV5BOGZhM2FhNTItODAzNi00YjA0LWEyN2UtNjJlYWQzYzU1MDg5L2ltYWdlL2ltYWdlXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_FMjpg_UY714_.jpg"
    },
    new()
    {
        Id = Guid.NewGuid(),
        Title = "Inception",
        Year = 2010,
        Summary = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O., but his tragic past may doom the project and his team to disaster.",
        Director = "Christopher Nolan",
        Genres = [
            "Action",
            "Adventure",
            "Sci-Fi"
        ],
        Actors = [
            new()
            {
                Name = "Leonardo DiCaprio"
            },
            new()
            {
                Name = "Joseph Gordon-Levitt"
            },
            new()
            {
                Name = "Elliot Page"
            }
        ],
        PosterPath = "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_.jpg"
    },
    new()
    {
        Id = Guid.NewGuid(),
        Title = "Jaws",
        Year = 1975,
        Summary = "When a killer shark unleashes chaos on a beach community off Cape Cod, it's up to a local sheriff, a marine biologist, and an old seafarer to hunt the beast down.",
        Director = "Steven Spielberg",
        Genres = [
            "Adventure",
            "Mystery",
            "Thriller"
        ],
        Actors = [
            new()
            {
                Name = "Roy Scheider"
            },
            new()
            {
                Name = "Lorraine Gary"
            },
            new()
            {
                Name = "Robert Shaw"
            }
        ],
        PosterPath = "https://m.media-amazon.com/images/M/MV5BMmVmODY1MzEtYTMwZC00MzNhLWFkNDMtZjAwM2EwODUxZTA5XkEyXkFqcGdeQXVyNTAyODkwOQ@@._V1_.jpg"
    }
};

app.MapGet("/api/movies/", () =>
{
    return TypedResults.Ok(movies);
});

app.MapGet("/api/movies/{id:guid}", (Guid id) =>
{
    return TypedResults.Ok(movies.Single(x => x.Id == id));
});

app.MapPost("/api/movies/", (Movie movie) =>
{
    movies.Add(movie);

    return TypedResults.NoContent();
});

app.MapPut("/api/movies/{id:guid}", (Guid id, Movie movie) =>
{
    var index = movies.FindIndex(x => x.Id == id);
    movies[index] = movie;

    return TypedResults.Ok(movies);
});

app.MapDelete("/api/movies/{id:guid}", (Guid id) =>
{
    movies.Remove(movies.Single(x => x.Id == id));

    return TypedResults.NoContent();
});

app.Run();
