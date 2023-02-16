namespace SampleAPI.FastEndpoints.Controllers.CreatePerson;

public class CreatePersonResponse
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public string Cognome { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
}