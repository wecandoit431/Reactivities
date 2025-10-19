using System;
using System.Diagnostics;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities.Query;

public class GetActivityList
{
    public class Query : IRequest<List<Domain.Activity>> { }

    public class Handler(AppDbContext context, ILogger<Handler> logger) : IRequestHandler<Query, List<Domain.Activity>>
    {
       
        public async Task<List<Domain.Activity>> Handle(Query request, CancellationToken cancellationToken)
        {
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    await Task.Delay(1000, cancellationToken);
                    logger.LogInformation($"Task {i} completed");
                }
            }
            catch (Exception)
            {
                logger.LogInformation("Task was cancelled");
            }

           return await context.Activities.ToListAsync(cancellationToken);
        }
    }

}
