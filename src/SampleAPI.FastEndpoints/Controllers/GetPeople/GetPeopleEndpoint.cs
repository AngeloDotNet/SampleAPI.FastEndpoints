using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using SampleAPI.FastEndpoints.Infrastructure;

namespace SampleAPI.FastEndpoints.Controllers.GetPeople;

public class GetPeopleEndpoint : Endpoint<GetPeopleRequest>
{
    private readonly DataDbContext dbContext;

    public GetPeopleEndpoint(DataDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public override void Configure()
    {
        Get("/api/people");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetPeopleRequest req, CancellationToken ct)
    {
        var list = await dbContext.People.ToListAsync(ct);

        await SendAsync(list, 200, ct);
    }
}