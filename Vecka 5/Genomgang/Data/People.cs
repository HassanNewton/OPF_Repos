namespace Genomgang.Data
{
    public static class People
    {
        public static List<Person> Persons { get; } = new()
    {
        new Person { Id = 1, Name = "Ali",  Age = 21, Address = "Malmö" },
        new Person { Id = 2, Name = "Sara", Age = 25, Address = "Lund" },
        new Person { Id = 3, Name = "John", Age = 30, Address = "Stockholm" },
        new Person { Id = 4, Name = "Mona", Age = 28, Address = "Göteborg" }
    };

        public static Person? GetById(int id)
            => Persons.FirstOrDefault(p => p.Id == id);
    }
}
