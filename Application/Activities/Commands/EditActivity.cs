using AutoMapper;
using Domain;
using MediatR;
using Persistence;

public class EditActivity
{
    public class Command : IRequest
    {
        public required Activity Activity { get; set; }
    }
    public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = await context.Activities.FindAsync([request.Activity.Id], cancellationToken) ?? throw new Exception("Activity not found");

            // activity.Title = request.Activity.Title;
            mapper.Map(request.Activity, activity);


            await context.SaveChangesAsync(cancellationToken);
           
        }
    }
}