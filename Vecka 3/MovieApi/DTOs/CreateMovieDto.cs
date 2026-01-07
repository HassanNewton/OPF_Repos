namespace MovieApi.DTOs
{
    public class CreateMovieDto
    {
        public string Title { get; set; }
        public DirectorDto Director { get; set; }
        public string Description { get; set; }
    }
}
