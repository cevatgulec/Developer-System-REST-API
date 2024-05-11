using DataAccess.EFCore;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using MediatR;



namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        public readonly IMediator _mediator;
        public DeveloperController(IMediator mediator)
        {
            _mediator = mediator;
        
        }

        //private readonly IUnitOfWork _unitOfWork;
        //public DeveloperController(IUnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllDevs()
        {
            var req = new CreateDeveloperQuery();
            var developer = await _mediator.Send(req);

            return Ok(developer);
        }


        [HttpGet("GetByName")]


        public async Task<IActionResult> GetDev([FromQuery]string name)
        {
            var req = new GetByNameQuery
            {
                Name = name
            };
            var developer = await _mediator.Send(req);
            //var developer = _unitOfWork.Developers.GetDevelopersByName(name);

            //_unitOfWork.Complete();
            return Ok(developer);

        }

        [HttpGet("GetById")]

        public async  Task<IActionResult> GetDevID([FromQuery] int id)
        {
            var req = new GetByIDQuery
            {
                Id = id
            };
            var developer = await _mediator.Send(req);
            return Ok(developer);

        }

        [HttpDelete("DeleteById")]

        public async Task<IActionResult> DeleteDev([FromQuery] int id)
        {
            var req= new DeleteDevQuery
            {
                Id = id
            };
            await _mediator.Send(req);
            return NoContent();
        }

        [HttpPut("UpdateDev")]

        public async Task<IActionResult> UpdateDevs(Developer dev)
        {

            var req = new PutQuery
            {
                Id = dev.Id,
                Name= dev.Name,
                Followers= dev.Followers
            };

            await _mediator.Send(req);
            return NoContent();

            //var developer = _unitOfWork.Developers.GetDevelopersByID(dev.Id);
            //developer.Name = dev.Name;
            //developer.Followers = dev.Followers;

            //_unitOfWork.Developers.UpdateDev(developer);

            //_unitOfWork.Complete();


        }

        [HttpPost("CreateDev")]

        public async Task<ActionResult> PostDev([FromQuery] string name, [FromQuery] int followerCount)
        {


            Developer developer = new Developer();

            var req = new AddDevCommand
            {
                Name = name,
                Followercount = followerCount

            };
            //AddDevCommand addDevCommand = new AddDevCommand();
            //addDevCommand.developer = developer;
            await _mediator.Send(req);

            //_unitOfWork.Developers.Add(developer);
            //_unitOfWork.Complete();

            return Ok();
        }




        ////[HttpGet("{name}")]

        ////public async Task<ActionResult<Developer>> GetDevelope(string name)
        ////{
        ////    var developer = _unitOfWork.Developers.GetAsync(name);
        ////    return Ok(developer);

        ////}

        //[HttpDelete("DeleteById/{id}")]

        //public async Task<IActionResult> DeleteDev(int id)
        //{
        //    var dev = _unitOfWork.Developers.GetById(id);
        //      _unitOfWork.Developers.Remove(dev);
        //    _unitOfWork.Complete();
        //    return NoContent();
        //}



        //[HttpPut("UpdateDev")]

        //public async Task<IActionResult> UpdateDevs(Developer dev)
        //{

        //    var d =  new PutQuery
        //    {
        //        Id = id
        //    };

        //    var developer = _unitOfWork.Developers.GetDevelopersByID(dev.Id);
        //    developer.Name = dev.Name;
        //    developer.Followers = dev.Followers;

        //    _unitOfWork.Developers.UpdateDev(developer);

        //    _unitOfWork.Complete();

        //    return NoContent();
        //}

        ////[HttpGet]

        ////public async Task<ActionResult<IEnumerable<Developer>>> GetDevs()
        ////{
        ////    return await _unitOfWork.Developers.ToListAsync();
        ////}

        ////[HttpGet]
        ////public IActionResult GetPopularDevelopers([FromQuery] string name)


        ///////
        ////[HttpPost]
        ////public IActionResult AddDeveloperAndProject()
        ////{
        ////    var developer = new Developer
        ////    {
        ////        Followers = 35,
        ////        Name = "Mukesh Murugan"

        ////    };



        ////    var project = new Project
        ////    {
        ////        Name = "codewithmukesh"
        ////    };
        ////    _unitOfWork.Developers.Add(developer);
        ////    _unitOfWork.Projects.Add(project);
        ////    _unitOfWork.Complete();
        ////     return Ok();



        ////    //return CreatedAtAction("asda", new { id = developer.Id }, developer);
        ///
        ////}

        //[HttpGet("GetAll")]
        //public IActionResult GetAllDevs()
        //{
        //    var developer = _unitOfWork.Developers.AllGet();

        //    return Ok(developer);
        //}



        //[HttpGet]
        //public IActionResult GetPopularDevelopers([FromQuery] int count)
        //{
        //    var popularDevelopers = _unitOfWork.Developers.GetPopularDevelopers(count);
        //    return Ok(popularDevelopers);
        //}




    }
    

}
