using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using SampleAPI.FastEndpoints.Infrastructure;

namespace SampleAPI.FastEndpoints.Controllers.GetPerson;

public class GetPersonEndpoint : Endpoint<GetPersonRequest>
{
    private readonly DataDbContext dbContext;

    public GetPersonEndpoint(DataDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public override void Configure()
    {
        Get("/api/people/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetPersonRequest req, CancellationToken ct)
    {
        //opzione 1
        //var user = await dbContext.People.FindAsync(req.Id);

        //opzione 2
        var user = await dbContext.People.FirstOrDefaultAsync(x => x.Id == req.Id);

        if (user == null)
        {
            await SendAsync(null, 404, ct);
        }
        else
        {
            await SendAsync(user, 200, ct);
        }
    }
}