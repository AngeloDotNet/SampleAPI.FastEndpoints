using FastEndpoints;
using SampleAPI.FastEndpoints.Entity;
using SampleAPI.FastEndpoints.Infrastructure;

namespace SampleAPI.FastEndpoints.Controllers.CreatePerson;

public class CreatePersonEndpoint : Endpoint<CreatePersonRequest, CreatePersonResponse>
{
    private readonly DataDbContext dbContext;

    public CreatePersonEndpoint(DataDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public override void Configure()
    {
        Post("/api/people");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreatePersonRequest req, CancellationToken ct)
    {
        var input = new PersonEntity
        {
            UserId = Guid.NewGuid(),
            Cognome = req.Cognome,
            Nome = req.Nome,
            Email = req.Email
        };

        dbContext.People.Add(input);

        try
        {
            await dbContext.SaveChangesAsync(ct);

            var result = new CreatePersonResponse()
            {
                Id = input.Id,
                UserId = input.UserId,
                Cognome = input.Cognome,
                Nome = input.Nome,
                Email = input.Email
            };

            await SendAsync(result, 200, ct);
        }
        catch
        {
            await SendAsync(null, 400, ct);
        }
    }
}