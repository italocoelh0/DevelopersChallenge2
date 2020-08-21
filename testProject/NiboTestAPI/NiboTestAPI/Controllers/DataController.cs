using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NiboTestApplication.Data;
using NiboTestApplication.Dto;
using NiboTestApplication.Interface;
using NiboTestApplication.Models;

namespace NiboTestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private IDataService DataService { get; set; }

        public DataController(IDataService dataService)
        {
            this.DataService = dataService;
        }

        [HttpPost]
        [Route("/insertFile")]
        public ActionResult<DtoDefaultResponse> DataImport([FromServices]DataContext context, [FromBody]DtoDataImport dto)
        {
            try
            {
                var response = DataService.DataImport(context, dto);

                if (response != null)
                    return Ok(new DtoDefaultResponse { StatusCode = 200, Message = response });
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/getTransactions")]
        public ActionResult<List<Transaction>> DataSelect([FromServices]DataContext context, [FromBody]DtoDataSelect dto)
        {
            try
            {
                var response = DataService.DataSelect(context, dto);

                if (response != null)
                    return Ok(response);
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}