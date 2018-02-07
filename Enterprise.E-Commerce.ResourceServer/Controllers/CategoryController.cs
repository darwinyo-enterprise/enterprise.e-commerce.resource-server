using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enterprise.ActionResults.NetStandard;
using Enterprise.Constants.NetStandard;
using Enterprise.E_Commerce.NetStandard.DataLayers.ECommerceDB;
using Enterprise.E_Commerce.NetStandard.Interfaces.ECommerceDB;
using Enterprise.Enums.NetStandard;
using Enterprise.Exceptions.NetStandard;
using Enterprise.Extension.NetStandard;
using Enterprise.Interfaces.NetStandard.Services;
using Enterprise.Models.NetStandard;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Enterprise.E_Commerce.ResourceServer.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly IECommerceDBUnitOfWork _eCommerceDBUnitOfWork;

        #region Template
        private readonly ILoggingServices _loggingServices;
        private readonly LogModel logModel;
        private readonly UserScopesModel userScopesModel;
        #endregion

        public CategoryController(IECommerceDBUnitOfWork eCommerceDBUnitOfWork, ILoggingServices loggingServices)
        {
            _eCommerceDBUnitOfWork = eCommerceDBUnitOfWork;

            _loggingServices = loggingServices;

            #region Template
            logModel = new LogModel();
            userScopesModel = new UserScopesModel(HttpContext);
            logModel.SetModel(userScopesModel.Subject.ToString(), userScopesModel.Name, nameof(CategoryController), ApplicationNames.ECommerce_ResourceServer, LogTypeEnum.Info);
            #endregion
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            IEnumerable<Category> categories = null;
            try
            {
                logModel.LogMessage = "User Attempt To Get All Categories List";
                await _loggingServices.LogAsync(logModel);

                categories = await _eCommerceDBUnitOfWork.CategoryRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                return new ExceptionResult(ex, _loggingServices);
            }
            return Ok(categories);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            Category category = null;
            try
            {
                logModel.LogMessage = string.Format("User Attempt To Get Single Categories By ID: {0}", id);
                await _loggingServices.LogAsync(logModel);

                category = await _eCommerceDBUnitOfWork.CategoryRepository.GetSingleAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                return new ExceptionResult(ex, _loggingServices);
            }
            return Ok(category);
        }

        // POST api/<controller>
        [HttpPost]
        // Admin Access
        public async Task<IActionResult> Post([FromBody]Category value)
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
                if (value.SubCategory.Count > 0)
                {
                    value.SubCategory = value.SubCategory.Select(x =>
                     {
                         x.CategoryId = value.Id;
                         x.CreatedBy = userScopesModel.Subject.Value;
                         x.CreatedDateTime = DateTime.Now;
                         x.Id = Guid.NewGuid();
                         return x;
                     }).ToList();
                }

                logModel.LogMessage = "User Attempt To Add New Category => " + JsonConvert.SerializeObject(value);
                await _loggingServices.LogAsync(logModel);

                await _eCommerceDBUnitOfWork.CategoryRepository.AddAsync(value);

                logModel.LogMessage = "User Successfully To Add New Category => " + JsonConvert.SerializeObject(value);
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
        public async Task<IActionResult> Put(Guid id, [FromBody]Category value)
        {
            try
            {
                logModel.LogMessage = string.Format("User Attempt To Update Categories By ID: {0}", id);
                await _loggingServices.LogAsync(logModel);

                // If Parameter Null
                if (value == null)
                {
                    throw new ParameterNullException();
                }

                var target = await _eCommerceDBUnitOfWork.CategoryRepository.GetSingleAsync(x => x.Id == id);

                // If Item Not Exists
                if (target == null)
                {
                    throw new ItemNotFoundException();
                }

                // Copy 
                var targetMod = target;
                targetMod.Name = value.Name;
                targetMod.Enabled = value.Enabled;
                targetMod.Images = value.Images;
                targetMod.LastUpdated = DateTime.Now;
                targetMod.UpdatedBy = userScopesModel.Subject.Value;

                // update subcategory
                // TODO : Continue this Workflow
                //targetMod.SubCategory = target.SubCategory
                //    .Select(x => new
                //    {
                //        x.UpdatedBy = userScopesModel.Subject.Value;
                //        if (x.CategoryId == null)
                //        {
                //            x.CategoryId = target.Id;
                //        }
                //        x.CreatedBy = x.CreatedBy == Guid.Empty ? x.CreatedBy : userScopesModel.Subject.Value;


                //    });

                logModel.LogMessage = string.Format("User Attempt To Update Category By From {0} To {1}",
                    JsonConvert.SerializeObject(target), JsonConvert.SerializeObject(targetMod));
                await _loggingServices.LogAsync(logModel);

                _eCommerceDBUnitOfWork.CategoryRepository.Update(targetMod);
                await _eCommerceDBUnitOfWork.SaveAsync();

                logModel.LogMessage = string.Format("User Successfully Updated Category => " + JsonConvert.SerializeObject(targetMod));
                await _loggingServices.LogAsync(logModel);
            }
            catch (Exception ex)
            {
                return new ExceptionResult(ex, _loggingServices);
            }
            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                logModel.LogMessage = string.Format("User Attempt To Delete Categories By ID: {0}", id);
                await _loggingServices.LogAsync(logModel);

                _eCommerceDBUnitOfWork.CategoryRepository.DeleteWhere(x => x.Id == id);
                await _eCommerceDBUnitOfWork.SaveAsync();

                logModel.LogMessage = string.Format("User Successfully Delete Single Categories By ID: {0}", id);
                await _loggingServices.LogAsync(logModel);
            }
            catch (Exception ex)
            {
                return new ExceptionResult(ex, _loggingServices);
            }
            return Ok();
        }

        // DELETE api/<controller>
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            try
            {
                logModel.LogMessage = string.Format("User Attempt To Delete all Categories");
                await _loggingServices.LogAsync(logModel);

                _eCommerceDBUnitOfWork.CategoryRepository.DeleteWhere(x => x.Id != null);
                await _eCommerceDBUnitOfWork.SaveAsync();

                logModel.LogMessage = string.Format("User Successfully Deleted all Categories");
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
