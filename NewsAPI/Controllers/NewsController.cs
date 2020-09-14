using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using News.DataAccess;
using News.DataAccess.Entity;
using NewsAPI.Models;

namespace NewsAPI.Controllers
{
    [ApiController]
    [Route("api/News")]
    public class NewsController : Controller
    {
        private readonly EFContext _context;
        public NewsController(EFContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<NewsViewModel> getNews()
        {
            List<NewsViewModel> data = _context.News.Select(t => new NewsViewModel()
            {
                Id = t.Id,
                DatePost = t.DatePost,
                Description = t.Description,
                LinkImage = t.LinkImage,
                Title = t.Title
            }).ToList();

            return data;
        }

        [HttpPost("postNews")]
        public ResultDTO postNews([FromBody]NewsCreateDTO model)
        {
            try
            {
                tblNews newNews = new tblNews() { 
                    DatePost = model.DatePost,
                    Description = model.Description,
                    LinkImage = model.LinkImage,
                    Title = model.Title
                };

                _context.News.Add(newNews);
                _context.SaveChanges();

                return new ResultDTO
                {
                    Status = 200,
                    Message = "OK"
                };
            }
            catch (Exception e)
            {
                return new ResultDTO
                {
                    Status = 500,
                    Message = e.Message
                };
            }


        }


    }
}