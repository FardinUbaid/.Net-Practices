using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _3tierTestapi.Controllers
{
    public class ProductController : ApiController
    {
        [HttpGet]
        [Route("api/products/getall")]
        public HttpResponseMessage GetAll()
        {
            var data = ProductService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/products/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = ProductService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPost]
        [Route("api/products/create")]
        public HttpResponseMessage Create(ProductDTO s)
        {
            ProductService.Create(s);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
