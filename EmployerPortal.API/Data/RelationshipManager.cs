namespace EmployerPortal.API.Data
{
    public class RelationshipManager : BaseIdentity
    {
        public string Title { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string Othernames { get; set; }
        public string Gender { get; set; }
        public string Mobile_Phone { get; set; }
        public string Email { get; set; }
        public string AgentCode { get; set; }
        public string BranchCode { get; set; }
        public string StateOfPosting { get; set; }
    }
}
