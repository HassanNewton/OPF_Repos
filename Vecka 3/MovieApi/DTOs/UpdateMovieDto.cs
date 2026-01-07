namespace MovieApi.DTOs
{
    public class UpdateMovieDto
    {
        public string Title { get; set; }
        public DirectorDto Director { get; set; }
        public string Description { get; set; }
    }
}
