using Domain.Entities;
using MediatR;
using Domain.Interfaces;
using DataAccess.EFCore.UnitOfWork;

namespace WebApi.Controllers
{
    public class PutQuery : IRequest<Developer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Followers { get; set; }  

    }

    public class PutQueryHandler : IRequestHandler<PutQuery, Developer>
    {
        private readonly IDeveloperRepository developerRepo;

        public PutQueryHandler(IDeveloperRepository repository)
        {
            developerRepo = repository;
        }


        public async Task<Developer> Handle(PutQuery request, CancellationToken cancellationToken)
        {
            var dev = developerRepo.GetDevelopersByID(request.Id);
            dev.Name = request.Name;

            dev.Followers = request.Followers;

            developerRepo.Save();
            return (dev);

        }
    }
}
