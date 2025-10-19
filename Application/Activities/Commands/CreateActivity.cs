using Domain;
using MediatR;
using Persistence;

namespace Application.Activities.Commands;

public class CreateActivity
{
    public class Commands : IRequest<String>
    {
        public required Activity Activity { get; set; }
    }
    // Implementation for creating an activity would go here
    
    public class Handler(AppDbContext context) : IRequestHandler<Commands, String>
    {
        public Task<String> Handle(Commands request, CancellationToken cancellationToken)
        {
            context.Activities.Add(request.Activity);
            context.SaveChangesAsync(cancellationToken);

            return Task.FromResult(request.Activity.Id);
        }

    }
}