namespace gubiarpa.onnesta.api.Dtos
{
    public class JobDto
    {
        public Guid Idjob { get; set; }
        public string JobTitle { get; set; } = null!;
        public Guid Idemployer { get; set; }
        public decimal? Salary { get; set; }
        public Guid IdworkplaceType { get; set; }
        public Guid IdjobType { get; set; }
        public Guid Idstatus { get; set; }
    }
}
