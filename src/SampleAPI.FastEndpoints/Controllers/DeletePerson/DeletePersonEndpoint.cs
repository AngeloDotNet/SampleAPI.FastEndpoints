using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using SampleAPI.FastEndpoints.Infrastructure;

namespace SampleAPI.FastEndpoints.Controllers.DeletePerson;

public class DeletePersonEndpoint : Endpoint<DeletePersonRequest>
{
    private readonly DataDbContext dbContext;

    public DeletePersonEndpoint(DataDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public override void Configure()
    {
        Delete("/api/people/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeletePersonRequest req, CancellationToken ct)
    {
        var user = await dbContext.People.FirstOrDefaultAsync(x => x.Id == req.Id);

        if (user == null)
        {
            await SendAsync(null, 404, ct);
        }
        else
        {
            dbContext.People.Remove(user);
            await dbContext.SaveChangesAsync(ct);

            await SendAsync(null, 200, ct);
        }
    }
}