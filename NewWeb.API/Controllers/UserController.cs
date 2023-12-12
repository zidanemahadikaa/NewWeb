using Microsoft.AspNetCore.Mvc;
using NewWeb.DataAccess;
using NewWeb.DataModel;
using NewWeb.ViewModel;

namespace NewWeb.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private DAUser user;
        public UserController(TestContext _db)
        {
            user = new DAUser(_db);
        }
        [HttpGet("[action]")]
        public VMResponse GetAll()
        {
            return user.GetAll();
        }
        [HttpPost("[action]")]
        public VMResponse Create(VMTblUser formData)
        {
            return user.Create(formData);
        }
        [HttpPut("[action]")]
        public VMResponse Update(VMTblUser formData)
        {
            return user.Update(formData);
        }
        [HttpDelete("[action]")]
        public VMResponse Delete(int id)
        {
            return user.Delete(id);
        }
    }
}
