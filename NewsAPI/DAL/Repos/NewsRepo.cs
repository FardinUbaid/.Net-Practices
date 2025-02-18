using DAL.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class NewsRepo
    {
        private readonly Context db;

        public NewsRepo()
        {
            db = new Context();
        }

        public void Create(News news)
        {
            db.News.Add(news);
            db.SaveChanges();
        }

        public List<News> Get()
        {
            return db.News.ToList();
        }

        public void Update(News news)
        {
            var exobj = Get(news.Id);
            if (exobj != null)
            {
                db.Entry(exobj).CurrentValues.SetValues(news);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var exobj = db.News.Find(id);
            if (exobj != null)
            {
                db.News.Remove(exobj);
                db.SaveChanges();
            }
        }

        public News Get(int id)
        {
            return db.News.Find(id);
        }

        public List<News> GetByCategory(string category)
        {
            return db.News.Where(n => n.Category == category).ToList();
        }

        public List<News> GetByTitle(string title)
        {
            return db.News.Where(n => n.Title.Contains(title)).ToList();
        }

        public List<News> GetByDate(DateTime date)
        {
            return db.News.Where(n => DbFunctions.TruncateTime(n.Date) == DbFunctions.TruncateTime(date)).ToList();
        }

        public List<News> GetByTitleAndCategory(string title, string category)
        {
            return db.News.Where(n => n.Title.Contains(title) && n.Category == category).ToList();
        }

        public List<News> GetByTitleAndDate(string title, DateTime date)
        {
            return db.News.Where(n => n.Title.Contains(title) && DbFunctions.TruncateTime(n.Date) == DbFunctions.TruncateTime(date)).ToList();
        }

        public List<News> GetByTitleDateAndCategory(string title, DateTime date, string category)
        {
            return db.News.Where(n => n.Title.Contains(title) && DbFunctions.TruncateTime(n.Date) == DbFunctions.TruncateTime(date) && n.Category == category).ToList();
        }
    }
}
