namespace _06_MVC_ViewModel_2.Models
{
    public class FootballPlayer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int PositionId { get; set; }
        public int TeamId { get; set; }

        //Navigation Property
        public Position Position { get; set; }
        public Team Team { get; set; }
    }
}
