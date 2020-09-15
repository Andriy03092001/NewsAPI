using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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


        //https://localhost:44566/api/News/removeNews/13
        [HttpGet("removeNews/{id}")]
        public ResultDTO removeNews([FromRoute]int id)
        {
            try
            {
                var this_news = _context.News.FirstOrDefault(t => t.Id == id);
                if (this_news == null)
                {
                    return new ResultDTO
                    {
                        Status = 504,
                        Message = "Not foud news"
                    };
                }

                _context.News.Remove(this_news);
                _context.SaveChanges();
                return new ResultDTO{
                    Status = 200,
                    Message = "OK"
                };
            }
            catch (Exception e)
            {
                return new ResultDTO
                {
                    Message = e.Message,
                    Status = 500
                };
            }
        }


        [HttpPost("editNews/{id}")]
        public ResultDTO editNews([FromRoute]int id, [FromBody]NewsCreateDTO model)
        {
            try
            {
                var this_news = _context.News.FirstOrDefault(t => t.Id == id);
                if (this_news == null)
                {
                    return new ResultDTO
                    {
                        Status = 504,
                        Message = "Not foud news"
                    };
                }

                this_news.Title = model.Title;
                this_news.LinkImage = model.LinkImage;
                this_news.Description = model.Description;
                this_news.DatePost = model.DatePost;
                _context.SaveChanges();

                return new ResultDTO
                {
                    Message = "OK",
                    Status = 200
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