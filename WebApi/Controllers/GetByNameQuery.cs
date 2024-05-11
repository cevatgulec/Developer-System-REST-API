using Domain.Entities;
using MediatR;
using Domain.Interfaces;
using DataAccess.EFCore.UnitOfWork;

namespace WebApi.Controllers
{
    public class GetByNameQuery: IRequest<IEnumerable<Developer>>
    {
        public string Name { get; set; }

       
    }
    public class GetByNameQueryHandler:IRequestHandler<GetByNameQuery, IEnumerable<Developer>>
    {

        private readonly IDeveloperRepository developerRepo;

        public GetByNameQueryHandler(IDeveloperRepository repository)
        {
            developerRepo = repository;
        }

        public async Task<IEnumerable<Developer>> Handle(GetByNameQuery request, CancellationToken cancellationToken)

        {
            return developerRepo.GetDevelopersByName(request.Name);
        }
    }



}
