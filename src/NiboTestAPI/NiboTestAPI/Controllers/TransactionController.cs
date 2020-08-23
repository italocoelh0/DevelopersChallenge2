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
    [Route("api/[controller]/")]
    public class TransactionController : ControllerBase
    {
        private iTransactionService _transService { get; set; }

        public TransactionController(iTransactionService transactionService)
        {
            _transService = transactionService;
        }

        /// <summary>
        /// Import information from selected Angular SPA files
        /// </summary>
        /// <param name="context"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("importFile")]
        public ActionResult<DtoDefaultResponse> ImportTransactiosFile([FromServices]DataContext context, [FromBody]DtoImportFiles dto)
        {
            try
            {
                var response = _transService.ImportTransactiosFile(context, dto);

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

        /// <summary>
        /// Get all transaction types to fill DropDown at Angular SPA
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getTypes")]
        public ActionResult<TransactionType> ReadTransactionTypes([FromServices]DataContext context)
        {
            try
            {
                var response = _transService.ReadTransactionTypes(context);

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

        /// <summary>
        /// Create new transaction
        /// </summary>
        /// <param name="context"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("createTransaction")]
        public ActionResult<DtoDefaultResponse> CreateTransaction([FromServices] DataContext context, [FromBody]Transaction dto)
        {
            try
            {
                var response = _transService.CreateTransaction(context, dto);

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

        /// <summary>
        /// Get transactions according to parameters entered
        /// </summary>
        /// <param name="context"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("readTransactions")]
        public ActionResult<List<Transaction>> ReadTransactions([FromServices]DataContext context, [FromBody]DtoTransactionRead dto)
        {
            try
            {
                var response = _transService.ReadTransactions(context, dto);

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

        /// <summary>
        /// Update selected transactions
        /// </summary>
        /// <param name="context"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("updateTransaction")]
        public ActionResult<DtoDefaultResponse> UpdateTransaction([FromServices] DataContext context, [FromBody]Transaction dto)
        {
            try
            {
                var response = _transService.UpdateTransaction(context, dto);

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

        /// <summary>
        /// Delete selected transaction
        /// </summary>
        /// <param name="context"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("deleteTransaction")]
        public ActionResult<DtoDefaultResponse> DeleteTransaction([FromServices] DataContext context, [FromBody]Transaction dto)
        {
            try
            {
                var response = _transService.DeleteTransaction(context, dto.Id);

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
    }
}