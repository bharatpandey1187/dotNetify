using dotNetify.SampleAPI.EDMX;
using dotNetify.SampleAPI.Entity;
using dotNetify.SampleAPI.Faker;
using dotNetify.SampleAPI.UserPersonaModels;
using dotNetify.SampleAPI.ViewModels;
using DotNetify.SampleAPI.UserPersonaModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotNetify.SampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly UserPersonaVM _usersVM;
        public PersonaController(IDbContextFactory<UserPersonaDbContext> dbContextFactory)
        {
            _usersVM = new UserPersonaVM(dbContextFactory);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create()
        {
            var candidateTransitions = FakerService.GetFakeCandidateTransitions(1).
                Select(candidateTransition => new CandidateTransition
                {
                    Id=candidateTransition.Id,
                    CandidateStatusReasonId=candidateTransition.CandidateStatusReasonId,
                    Active=candidateTransition.Active,
                    EmployeeId=candidateTransition.EmployeeId,
                    CompanyId=candidateTransition.CompanyId,
                    ContractId=candidateTransition.ContractId,
                    ProgramCompletionDate=candidateTransition.ProgramCompletionDate,
                    GracePeriodEndDate=candidateTransition.GracePeriodEndDate,
                    LastUpdatedDate=candidateTransition.LastUpdatedDate,
                    CreatedDate=candidateTransition.CreatedDate,
                    CountryExpirationDate=  candidateTransition.CountryExpirationDate,
                    LastUpdatedByUserId=candidateTransition.LastUpdatedByUserId,
                    ResumeExpirationDate=candidateTransition.ResumeExpirationDate,
                    ProgramId=candidateTransition.ProgramId,
                    ProjectName=candidateTransition.ProjectName,
                    UserId= candidateTransition.UserId,
                 
                });
            _usersVM.Add(candidateTransitions.First());

            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(UserEntity userEntity)
        {
            //   _usersVM.Update(user);

            return Ok();
        }


        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(UserEntity userEntity)
        {
            var user = new User()
            {
                Id = userEntity.Id
            };
          //  _usersVM.Remove(user);

            return Ok();
        }


        [HttpPut]
        [Route("Address")]
        public IActionResult Update(AddressEntity addressEntity)
        {
            var address = new Address { Id = addressEntity.Id, UserId = addressEntity.UserId };
            //_usersVM.Update(address);

            return Ok();
        }
    }
}
