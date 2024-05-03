using Core.Abstacts;
using Core.Models;
using Data.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concretes
{
    public class ProductRepository : IProductRepository
    {
        AppDb _appDb=new AppDb();
        void IProductRepository.Add(string command)
        {
            _appDb.NonQuery(command);
        }

        void IProductRepository.Delete(string command)
        {
            _appDb.NonQuery(command);
        }

        Product Get(string command)
        {
            var dt = _appDb.Query(command);
           Product product = null;
            foreach (DataRow item in dt.Rows)
            {
                product = new Product
                {
                    Id = int.Parse(item[0].ToString()),
                    Name = item[1].ToString(),
                    Price = decimal.Parse(item[2].ToString())
                };
            }

            return product;

        }

        List<Product> GetAll(string command)
        {
            var dt = _appDb.Query(command);
            List<Product> products = new List<Product>();

            foreach (DataRow item in dt.Rows)
            {
                Product product = new Product
                {
                    Id = int.Parse(item[0].ToString()),
                    Name = item[1].ToString(),
                    Price = decimal.Parse(item[2].ToString())
                };

                products.Add(product);
            }

            return products;
        }

        void IProductRepository.Update(string command)
        {
            _appDb.NonQuery(command);
        }
    }
}
