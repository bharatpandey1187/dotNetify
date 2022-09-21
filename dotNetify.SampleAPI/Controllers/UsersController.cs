using dotNetify.SampleAPI.EDMX;
using dotNetify.SampleAPI.Entity;
using dotNetify.SampleAPI.Faker;
using dotNetify.SampleAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotNetify.SampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserPIIVM _usersVM;
        public UsersController(IDbContextFactory<UserPIIDbContext> dbContextFactory)
        {
            _usersVM = new UserPIIVM(dbContextFactory);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create()
        {
            for (int index = 1; index <= 10; index++)
            {
                var users = FakerService.GetFakeUsers(30);
                _usersVM.AddBatch(users);
            }

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
            _usersVM.Remove(user);

            return Ok();
        }


        [HttpPut]
        [Route("Address")]
        public IActionResult Update(AddressEntity addressEntity)
        {
            var address = new Address { Id = addressEntity.Id, UserId = addressEntity.UserId };
               _usersVM.Update(address);

            return Ok();
        }
    }
}
