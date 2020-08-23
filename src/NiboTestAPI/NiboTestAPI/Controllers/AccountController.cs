using Microsoft.AspNetCore.Mvc;
using NiboTestApplication.Data;
using NiboTestApplication.Dto;
using NiboTestApplication.Interface;
using NiboTestApplication.Models;
using System;

namespace NiboTestAPI.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public AccountController(IAccountService accService)
        {
            _accService = accService;
        }

        public IAccountService _accService { get; set; }

        /// <summary>
        /// Create new account
        /// </summary>
        /// <param name="context"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("createAccount")]
        public ActionResult<DtoDefaultResponse> CreateAccount([FromServices] DataContext context, [FromBody]Account dto)
        {
            try
            {
                var response = _accService.CreateAccount(context, dto);

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
        /// Get accounts according to parameters entered
        /// </summary>
        /// <param name="context"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("readAccounts")]
        public ActionResult<DtoDefaultResponse> ReadAccount([FromServices] DataContext context, [FromBody]DtoAccountRead dto)
        {
            try
            {
                var response = _accService.ReadAccounts(context, dto);

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
        /// Update account informations
        /// </summary>
        /// <param name="context"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("updateAccount")]
        public ActionResult<DtoDefaultResponse> UpdateAccount([FromServices] DataContext context, [FromBody]Account dto)
        {
            try
            {
                var response = _accService.UpdateAccount(context, dto);

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
        /// Delete selected account and deleted transactions related to informed account
        /// </summary>
        /// <param name="context"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("deleteAccount")]
        public ActionResult<DtoDefaultResponse> DeleteAccount([FromServices] DataContext context, [FromBody]Account dto)
        {
            try
            {
                var response = _accService.DeleteAccount(context, dto.AccountId);

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