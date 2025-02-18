using AutoMapper;
using BLL.DTOs.BLL.DTOs;
using DAL.EF;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    
        public class NewsService
        {
            public static List<NewsDTO> GetAll()
            {
                var newsRepo = new NewsRepo();
                var data = newsRepo.Get();
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<News, NewsDTO>();
                });
                var mapper = new Mapper(config);
                var ret = mapper.Map<List<NewsDTO>>(data);

                return ret;
            }

            public static NewsDTO Get(int id)
            {
                var newsRepo = new NewsRepo();
                var data = newsRepo.Get(id);
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<News, NewsDTO>();
                });
                var mapper = new Mapper(config);
                var ret = mapper.Map<NewsDTO>(data);

                return ret;
            }

            public static void Create(NewsDTO news)
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<NewsDTO, News>();
                });
                var mapper = new Mapper(config);
                var newsEntity = mapper.Map<News>(news);
                var newsRepo = new NewsRepo();
                newsRepo.Create(newsEntity);
            }

            public static void Update(NewsDTO news)
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<NewsDTO, News>();
                });
                var mapper = new Mapper(config);
                var newsEntity = mapper.Map<News>(news);
                var newsRepo = new NewsRepo();
                newsRepo.Update(newsEntity);
            }

            public static void Delete(int id)
            {
                var newsRepo = new NewsRepo();
                newsRepo.Delete(id);
            }

            public static List<NewsDTO> GetByCategory(string category)
            {
                var newsRepo = new NewsRepo();
                var data = newsRepo.GetByCategory(category);
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<News, NewsDTO>();
                });
                var mapper = new Mapper(config);
                var ret = mapper.Map<List<NewsDTO>>(data);

                return ret;
            }

            public static List<NewsDTO> GetByTitle(string title)
            {
                var newsRepo = new NewsRepo();
                var data = newsRepo.GetByTitle(title);
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<News, NewsDTO>();
                });
                var mapper = new Mapper(config);
                var ret = mapper.Map<List<NewsDTO>>(data);

                return ret;
            }

            public static List<NewsDTO> GetByDate(DateTime date)
            {
                var newsRepo = new NewsRepo();
                var data = newsRepo.GetByDate(date);
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<News, NewsDTO>();
                });
                var mapper = new Mapper(config);
                var ret = mapper.Map<List<NewsDTO>>(data);

                return ret;
            }

            public static List<NewsDTO> GetByTitleAndCategory(string title, string category)
            {
                var newsRepo = new NewsRepo();
                var data = newsRepo.GetByTitleAndCategory(title, category);
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<News, NewsDTO>();
                });
                var mapper = new Mapper(config);
                var ret = mapper.Map<List<NewsDTO>>(data);

                return ret;
            }

            public static List<NewsDTO> GetByTitleAndDate(string title, DateTime date)
            {
                var newsRepo = new NewsRepo();
                var data = newsRepo.GetByTitleAndDate(title, date);
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<News, NewsDTO>();
                });
                var mapper = new Mapper(config);
                var ret = mapper.Map<List<NewsDTO>>(data);

                return ret;
            }

            public static List<NewsDTO> GetByTitleDateAndCategory(string title, DateTime date, string category)
            {
                var newsRepo = new NewsRepo();
                var data = newsRepo.GetByTitleDateAndCategory(title, date, category);
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<News, NewsDTO>();
                });
                var mapper = new Mapper(config);
                var ret = mapper.Map<List<NewsDTO>>(data);

                return ret;
            }
            
    }
}


