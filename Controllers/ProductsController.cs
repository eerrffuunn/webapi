using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using webapi.DAL;
using webapi.Model;

namespace webapi.Controllers
{
    // Keep the URL as-is
    [Route("api/product")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository productRepository;

        // Keep this contructor as-is
        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return productRepository.List();
        }


        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeletebyID(string id)
        {
            bool result = this.productRepository.Delete(int.Parse(id));

            if (result)
                return NoContent();
            else
            {
                return NotFound();

            }
        }


        [HttpHead]
        [Route("{id}")]
        public ActionResult SearchByID(string id)
        {
            Product result = productRepository.GetById(int.Parse(id));
            if (result == null)
                return NotFound();
            else
            {
                return Ok();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Model.Product> GetbyID(string id)
        {
            Product result = productRepository.GetById(int.Parse(id));
            if (result == null)
                return NotFound();
            else
            {
                Ok();
                return result;

            }
        }

        [HttpGet]
        [Route("-/count")]
        public ActionResult<CountResult> CountAll()
        {
            CountResult result = new CountResult();
            result.Count = productRepository.List().Count;
            return result;
        }


    }
}