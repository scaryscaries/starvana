namespace StarVana.DTOs
{
    public class StarshipsResponse
    {
        StarshipsResponse()
        {
            Results = new List<Starship>();
        }

        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<Starship> Results { get; }
    }
}
