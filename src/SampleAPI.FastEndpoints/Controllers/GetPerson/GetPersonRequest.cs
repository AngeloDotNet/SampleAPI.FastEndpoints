using Microsoft.AspNetCore.Mvc;

namespace SampleAPI.FastEndpoints.Controllers.GetPerson;

public class GetPersonRequest
{
    [FromBody]
    public int Id { get; set; }
}
