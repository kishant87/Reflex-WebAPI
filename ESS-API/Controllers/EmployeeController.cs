using Xpanxion.Reflex.API.Contracts.Responses;
using Xpanxion.Reflex.API.Contracts.Types;
using Xpanxion.Reflex.API.Data.ClientProvider;
using Xpanxion.Reflex.API.Data.ClientProxy;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Xpanxion.Reflex.API.Web.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        // POST api/values
        [HttpPost]
        public async Task<BaseResponse> InsertEmployeeAsync()
        {
            EmployeeProvider e = new EmployeeProvider();
            e.ClientProxyObj = new DocumentDB();

            Employee emp = new Employee();
            emp.Id = 40;
            emp.IsActive = true;
            emp.IsGroup = false;
            emp.FirstName = "Kishan";
            emp.LastName = "Tanpure";
            emp.EmailAddress = "kishant@xpanxion.co.in";
            emp.Rating = true;
            emp.Role = EmployeeRoles.Employee;
            emp.UserName = "kishant";
            emp.OTP = "123";
            emp.EmployeeDevice = new List<Device>
                            {
                                new Device ()
                                {
                                    OTP = 123,
                                    DeviceNumber = "14",
                                    Id = 1,
                                    MobileNumber = "8446247702",
                                    IsLandingEnabled = true,
                                    Type = DeviceType.iOS
                                }
                            };

            return await e.InsertEmployee(emp);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<BaseResponse> GetEmployeeAsync(string id)
        {
            EmployeeProvider e = new EmployeeProvider();
            e.ClientProxyObj = new DocumentDB();
            var vurn = await e.GetEmployee(id);
            return vurn;
        }
    }
}
