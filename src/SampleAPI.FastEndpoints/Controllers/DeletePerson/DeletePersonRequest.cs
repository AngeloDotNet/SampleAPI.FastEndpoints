using Microsoft.AspNetCore.Mvc;

namespace SampleAPI.FastEndpoints.Controllers.DeletePerson;

public class DeletePersonRequest
{
    [FromBody]
    public int Id { get; set; }
}