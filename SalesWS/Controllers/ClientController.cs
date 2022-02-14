using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesWS.Models;
using SalesWS.Models.Response;
using SalesWS.Models.ViewModels;

namespace SalesWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClientController : ControllerBase
    {
        [HttpGet]
        [Route("get-all")]
        public IActionResult GetAll()
        {
            ApiResponse response = new ApiResponse();
            try
            {
                using (Sales_CourseContext context = new Sales_CourseContext())
                {
                    response.Data = context.Clients.OrderByDescending(c=>c.Id).ToList();
                    response.Success = 1;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("get-by-id/{id}")]
        public IActionResult GetById(long id)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                using (Sales_CourseContext context = new Sales_CourseContext())
                {
                    response.Data = context.Clients.Find(id);
                    response.Success = 1;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(ClientViewModel model)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                using (Sales_CourseContext db = new Sales_CourseContext())
                {
                    Client client = new Client();
                    client.Name = model.Name;
                    db.Clients.Add(client);
                    db.SaveChanges();
                    response.Success = 1;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("edit")]
        public IActionResult Edit(ClientViewModel model)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                using (Sales_CourseContext db = new Sales_CourseContext())
                {
                    Client client = db.Clients.Find(model.Id);
                    client.Name = model.Name;
                    db.Entry(client).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    response.Success = 1;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult Delete(long id)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                using (Sales_CourseContext db = new Sales_CourseContext())
                {
                    Client client = db.Clients.Find(id);
                    db.Remove(client);
                    db.Entry(client).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    db.SaveChanges();
                    response.Success = 1;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return Ok(response);
        }
    }
}
