using Domain.Entities;
using MediatR;
using Domain.Interfaces;
using DataAccess.EFCore.UnitOfWork;

namespace WebApi.Controllers
{
    public class CreateDeveloperQuery :IRequest<IEnumerable<Developer>>
    {   

       

    }

    public class CreateDeveloperQueryHandler :IRequestHandler<CreateDeveloperQuery, IEnumerable<Developer>>
    {

        private readonly IDeveloperRepository developerRepo;

        public CreateDeveloperQueryHandler(IDeveloperRepository repository)
        {
            developerRepo = repository;   
        }

        //GetAll method will change
        public async Task<IEnumerable<Developer>> Handle(CreateDeveloperQuery request, CancellationToken cancellationToken)
        {
            return developerRepo.GetAll();
            //    return developerRepo.GetDevelopersByName(request.Name);
        }
    }


}
