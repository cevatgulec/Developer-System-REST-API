using Domain.Entities;
using MediatR;
using Domain.Interfaces;
using DataAccess.EFCore.UnitOfWork;

namespace WebApi.Controllers
{
    public class GetByIDQuery: IRequest<Developer>
    {
        public int Id { get; set; }

    }

    public class GetByIdQueryHandler: IRequestHandler<GetByIDQuery, Developer>
    {
        private readonly IDeveloperRepository developerRepo;

        public GetByIdQueryHandler(IDeveloperRepository repository)
        {
            developerRepo = repository; 
        }

        public async Task<Developer> Handle(GetByIDQuery request, CancellationToken cancellationToken)
        {
            return developerRepo.GetDevelopersByID(request.Id);
        }
    }
}
