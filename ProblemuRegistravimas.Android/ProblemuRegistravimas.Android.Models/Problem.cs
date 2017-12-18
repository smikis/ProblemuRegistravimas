namespace ProblemuRegistravimas.AndroidProject.Models
{
    public class Problem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string Location { get; set; }
        public string AssignedUser { get; set; }
        public string Client { get; set; }
        public bool Closed { get; set; } = false;
    }
}