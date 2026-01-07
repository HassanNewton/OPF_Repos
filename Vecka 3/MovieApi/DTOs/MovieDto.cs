namespace MovieApi.DTOs
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DirectorDto Director { get; set; }
        public string Description { get; set; }
    }
}

//DTOs = exakt det API:t skickar och tar emot.
//Vi skickar INTE DirectorId i requesten – precis som i uppgiften.