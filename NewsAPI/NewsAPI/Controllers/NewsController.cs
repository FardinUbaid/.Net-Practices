using BLL.DTOs.BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NewsAPI.Controllers
{
    public class NewsController : ApiController
    {
        [HttpGet]
        [Route("api/news/all")]
        public HttpResponseMessage GetAll()
        {
            var data = NewsService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/news/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = NewsService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]  
        [Route("api/news/title/{title}")]
        public HttpResponseMessage GetByTitle(string title)
        {
            var data = NewsService.GetByTitle(title);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/news/category/{category}")]
        public HttpResponseMessage GetByCategory(string category)
        {
            var data = NewsService.GetByCategory(category);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/news/title/{title}/date/{date}")]
        public HttpResponseMessage GetByTitleAndDate(string title, string date)
        {
            DateTime parsedDate;
            if (DateTime.TryParse(date, out parsedDate))
            {
                var data = NewsService.GetByTitleAndDate(title, parsedDate);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid date format.");
            }
        }

        [HttpGet]
        [Route("api/news/title/{title}/category/{category}")]
        public HttpResponseMessage GetByTitleAndCategory(string title, string category)
        {
            var data = NewsService.GetByTitleAndCategory(title, category);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/news/title/{title}/date/{date}/category/{category}")]
        public HttpResponseMessage GetByTitleDateAndCategory(string title, string date, string category)
        {
            DateTime parsedDate;
            if (DateTime.TryParse(date, out parsedDate))
            {
                var data = NewsService.GetByTitleDateAndCategory(title, parsedDate, category);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid date format.");
            }
        }

        [HttpPost]
        [Route("api/news/create")]
        public HttpResponseMessage Create(NewsDTO news)
        {
            NewsService.Create(news);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/news/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var data = NewsService.Get(id);
            if (data != null)
            {
                NewsService.Delete(id);  
                return Request.CreateResponse(HttpStatusCode.OK, "News item deleted successfully.");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "News item not found.");
            }
        }


    }
}
