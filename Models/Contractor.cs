namespace jobs.Models

{

    public class Contractor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }

    public class PersonnelViewModel : Contractor

    {
        public int PersonnelId { get; set; }
    }
}