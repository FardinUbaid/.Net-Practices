using AutoMapper;
using BLL.DTOs;
using DAL.EF;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService
    {
        public static List<ProductDTO> GetAll()
        {
            var srepo = new ProductRepo();
            var data = srepo.Get();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(config); ;
            var ret = mapper.Map<List<ProductDTO>>(data);

            return ret;

        }
        public static ProductDTO Get(int id)
        {
            var srepo = new ProductRepo();
            var data = srepo.Get(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(config); ;
            var ret = mapper.Map<ProductDTO>(data);

            return ret;

        }
        public static void Create(ProductDTO s)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ProductDTO, Product>();
            });
            var mapper = new Mapper(config); ;
            var st = mapper.Map<Product>(s);
            var repo = new ProductRepo();
            repo.Create(st);

        }
    }
}
