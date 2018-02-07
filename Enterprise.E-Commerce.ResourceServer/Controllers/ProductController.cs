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
using Enterprise.Interfaces.NetStandard.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Enterprise.E_Commerce.ResourceServer.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IECommerceDBUnitOfWork _eCommerceDBUnitOfWork;
        #region Template
        private readonly ILoggingServices _loggingServices;
        private readonly LogModel logModel;
        private readonly UserScopesModel userScopesModel;
        #endregion 
        public ProductController(IECommerceDBUnitOfWork eCommerceDBUnitOfWork, ILoggingServices loggingServices)
        {
            _eCommerceDBUnitOfWork = eCommerceDBUnitOfWork;
            _loggingServices = loggingServices;

            #region Template
            logModel = new LogModel();
            userScopesModel = new UserScopesModel(HttpContext);
            logModel.SetModel(userScopesModel.Subject.ToString(), userScopesModel.Name, nameof(ProductController), ApplicationNames.ECommerce_ResourceServer, LogTypeEnum.Info);
            #endregion
        }
        //// GET: api/<controller>/hotest
        //[HttpGet("hotest")]
        //public IEnumerable<string> GetHotest()
        //{
        //    IEnumerable<Product> products = null;
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}
        //// GET: api/<controller>/recommended
        //[HttpGet("recommended")]
        //public IEnumerable<string> GetRecommended()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        // GET: api/<controller>/most_reviewed
        [HttpGet("most_reviewed")]
        public IEnumerable<string> GetMostReviewed()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
