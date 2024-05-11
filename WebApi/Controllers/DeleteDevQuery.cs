using Domain.Entities;
using MediatR;
using Domain.Interfaces;
using DataAccess.EFCore.UnitOfWork;

namespace WebApi.Controllers
{
    public class DeleteDevQuery : IRequest<Developer>
    {
        public int Id { get; set; }
    }

    public class DeleteDevQueryHandler :IRequestHandler<DeleteDevQuery, Developer>
    {
        private readonly IDeveloperRepository developerRepo;

        public DeleteDevQueryHandler(IDeveloperRepository repository)
        {
            developerRepo = repository;

        }

        public async Task<Developer> Handle(DeleteDevQuery request, CancellationToken cancellationToken)
        {
            var dev = developerRepo.GetById(request.Id);
            developerRepo.Remove(dev);
            developerRepo.Save();
            return (dev);
        }

}
}
