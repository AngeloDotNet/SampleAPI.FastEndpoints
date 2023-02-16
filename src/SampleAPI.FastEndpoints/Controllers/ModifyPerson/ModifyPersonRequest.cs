namespace SampleAPI.FastEndpoints.Controllers.ModifyPerson;

public class ModifyPersonRequest
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public string Cognome { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
}