using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using SampleAPI.FastEndpoints.Infrastructure;

namespace SampleAPI.FastEndpoints.Controllers.ModifyPerson;

public class ModifyPersonEndpoint : Endpoint<ModifyPersonRequest, ModifyPersonResponse>
{
    private readonly DataDbContext dbContext;

    public ModifyPersonEndpoint(DataDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public override void Configure()
    {
        Put("/api/people/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(ModifyPersonRequest req, CancellationToken ct)
    {
        var user = await dbContext.People.FirstOrDefaultAsync(x => x.Id == req.Id);

        if (user == null)
        {
            await SendAsync(null, 404, ct);
            return;
        }

        user.Id = req.Id;
        user.UserId = req.UserId;
        user.Cognome = req.Cognome;
        user.Nome = req.Nome;
        user.Email = req.Email;

        try
        {
            await dbContext.SaveChangesAsync(ct);

            var result = new ModifyPersonResponse()
            {
                Id = user.Id,
                UserId = user.UserId,
                Cognome = user.Cognome,
                Nome = user.Nome,
                Email = user.Email
            };

            await SendAsync(result, 200, ct);
        }
        catch
        {
            await SendAsync(null, 400, ct);
        }
    }
}