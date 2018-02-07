using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enterprise.E_Commerce.NetStandard.Interfaces.ECommerceDB;
using Enterprise.Models.NetStandard;
using Enterprise.Extension.NetStandard;
using Microsoft.AspNetCore.Mvc;
using Enterprise.Constants.NetStandard;
using Enterprise.Enums.NetStandard;
using Enterprise.E_Commerce.NetStandard.DataLayers.ECommerceDB;
using Enterprise.ActionResults.NetStandard;
using Newtonsoft.Json;
using Enterprise.Exceptions.NetStandard;
using Enterprise.Interfaces.NetStandard.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Enterprise.E_Commerce.ResourceServer.Controllers
{
    [Route("api/[controller]")]
    public class SubCategoryController : Controller
    {
        private readonly IECommerceDBUnitOfWork _eCommerceDBUnitOfWork;
        #region Template
        private readonly ILoggingServices _loggingServices;
        private readonly LogModel logModel;
        private readonly UserScopesModel userScopesModel;
        #endregion
        public SubCategoryController(IECommerceDBUnitOfWork eCommerceDBUnitOfWork, ILoggingServices loggingServices)
        {
            _eCommerceDBUnitOfWork = eCommerceDBUnitOfWork;
            _loggingServices = loggingServices;

            #region Template
            logModel = new LogModel();
            userScopesModel = new UserScopesModel(HttpContext);
            logModel.SetModel(userScopesModel.Subject.ToString(), userScopesModel.Name, nameof(SubCategoryController), ApplicationNames.ECommerce_ResourceServer, LogTypeEnum.Info);
            #endregion
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<SubCategory> subCategories = null;
            try
            {
                logModel.LogMessage = "User Attempt To Get All Sub-Categories List";
                await _loggingServices.LogAsync(logModel);

                subCategories = await _eCommerceDBUnitOfWork.SubCategoryRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                return new ExceptionResult(ex, _loggingServices);
            }
            return Ok(subCategories);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            SubCategory subCategory = null;
            try
            {
                logModel.LogMessage = "User Attempt To Get All Sub-Categories List";
                await _loggingServices.LogAsync(logModel);

                subCategory = await _eCommerceDBUnitOfWork.SubCategoryRepository.GetSingleAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                return new ExceptionResult(ex, _loggingServices);
            }
            return Ok(subCategory);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]SubCategory value)
        {
            try
            {
                // Cant Accept Null Argument
                if (value == null)
                {
                    throw new ParameterNullException();
                }

                // SQL Will throw Exception if Name Already Registered.

                value.CreatedBy = userScopesModel.Subject.Value;
                value.CreatedDateTime = DateTime.Now;
                value.Id = Guid.NewGuid();

                logModel.LogMessage = "User Attempt Create New Sub-Category => " + JsonConvert.SerializeObject(value);
                await _loggingServices.LogAsync(logModel);

                await _eCommerceDBUnitOfWork.SubCategoryRepository.AddAsync(value);

                logModel.LogMessage = "User Successfully Create New Sub-Category => " + JsonConvert.SerializeObject(value);
                await _loggingServices.LogAsync(logModel);
            }
            catch (Exception ex)
            {
                return new ExceptionResult(ex, _loggingServices);
            }
            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                logModel.LogMessage = string.Format("User Attempt To Delete Single Sub-Categories By ID : " + id);
                await _loggingServices.LogAsync(logModel);

                _eCommerceDBUnitOfWork.SubCategoryRepository.DeleteWhere(x => x.Id == id);
                await _eCommerceDBUnitOfWork.SaveAsync();

                logModel.LogMessage = string.Format("User Successfully Deleted Single Sub-Categories By ID : " + id);
                await _loggingServices.LogAsync(logModel);
            }
            catch (Exception ex)
            {
                return new ExceptionResult(ex, _loggingServices);
            }
            return Ok();
        }

        // DELETE api/<controller>
        /// <summary>
        /// For Testing Purpose
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            try
            {
                logModel.LogMessage = string.Format("User Attempt To Delete All Sub-Categories");
                await _loggingServices.LogAsync(logModel);

                _eCommerceDBUnitOfWork.SubCategoryRepository.DeleteWhere(x => x.Id != null);
                await _eCommerceDBUnitOfWork.SaveAsync();

                logModel.LogMessage = string.Format("User Successfully Deleted All Sub-Categories");
                await _loggingServices.LogAsync(logModel);
            }
            catch (Exception ex)
            {
                return new ExceptionResult(ex, _loggingServices);
            }
            return Ok();
        }
    }
}
