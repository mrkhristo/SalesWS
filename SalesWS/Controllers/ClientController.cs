using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesWS.Models;
using SalesWS.Models.Response;
using SalesWS.Models.ViewModels;

namespace SalesWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpGet]
        [Route("get-all")]
        public IActionResult GetAll()
        {
            Response response = new Response();
            try
            {
                using (Sales_CourseContext context = new Sales_CourseContext())
                {
                    response.Data = context.Clients.ToList();
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
            Response response = new Response();
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
            Response response = new Response();
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
            Response response = new Response();
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
            Response response = new Response();
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
