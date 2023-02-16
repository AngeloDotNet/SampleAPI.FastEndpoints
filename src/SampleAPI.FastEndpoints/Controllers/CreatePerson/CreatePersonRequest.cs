namespace SampleAPI.FastEndpoints.Controllers.CreatePerson;

public class CreatePersonRequest
{
    public string Cognome { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
}