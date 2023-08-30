
namespace sacral
{
    public class UserStoryModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
    }

    public class AcceptanceCriteriaModel
    {
        public int Id { get; set; }
        public string Criteria { get; set; }
    }

    public class DocumentModel
    {
        public int Id { get; set; }
        public string Format { get; set; }
    }

    public class CustomerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int CreditScore { get; set; }
        public decimal Income { get; set; }
    }

    public class ApplicationModel
    {
        public int Id { get; set; }
        public DocumentModel Document { get; set; }
        public CustomerModel Customer { get; set; }
        public bool IsRejected { get; set; }
        public bool IsApproved { get; set; }
    }

    public class UserRoleModel
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public List<string> Permissions { get; set; }
    }

    public class RecipientProfileModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string BankAccountDetails { get; set; }
    }

    public class LoanDisbursementModel
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Receiver { get; set; }
    }
}
