using Domain;
using MediatR;
using Persistence;

namespace Application.Activities.Query
{
    public class GetActivityDetails
    {
        public class Query : IRequest<Activity>
        {
           public required String Id { get; set; }
        }

        public class Handler(AppDbContext context) : IRequestHandler<Query, Activity>
        {
            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            {
                var activity = await context.Activities.FindAsync(request.Id);

                return (activity == null) ? throw new Exception("Activity not found") : activity;
            }
        }
    }
}