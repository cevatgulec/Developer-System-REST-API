using Domain.Entities;
using MediatR;
using Domain.Interfaces;
using DataAccess.EFCore.UnitOfWork;


namespace WebApi.Controllers
{
    public class AddDevCommand : IRequest<Developer>
    {
        public string Name { get; set; }
        public int Followercount { get; set; }

        //public Developer developer { get; set; }

    }

    public class AddDevCommandHandler : IRequestHandler<AddDevCommand, Developer>
    {
        //private readonly IDeveloperRepository developerRepo;
        private readonly IDeveloperRepository developerRepo;

        public AddDevCommandHandler(IDeveloperRepository repository)
        {

            developerRepo = repository;

        }

        public async Task<Developer> Handle(AddDevCommand request, CancellationToken cancellationToken)
        {
            Developer dev = new Developer();

            dev.Name = request.Name;
            dev.Followers = request.Followercount;

            developerRepo.Add(dev);
            developerRepo.Save();
            
            

            

            return (dev);
        }
    }
}
