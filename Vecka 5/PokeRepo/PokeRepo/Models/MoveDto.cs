namespace PokeRepo.Models
{
    public class MoveDto
    {
        public MoveNameDto Move { get; set; } = new();
    }

    public class MoveNameDto
    {
        public string Name { get; set; } = "";
    }
}
