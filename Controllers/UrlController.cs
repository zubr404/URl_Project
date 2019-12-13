using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using URl_Project.Models;
using URl_Project.Interfaces;
using URl_Project.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace URl_Project.Controllers
{
    [Route(UrlRoutesHelper.ROUTECONTROLLER)]
    public class UrlController : Controller
    {
        IModificationUrl modificationUrl;
        public UrlController(IModificationUrl modificationUrl)
        {
            this.modificationUrl = modificationUrl;
        }

        [Route(UrlRoutesHelper.ROUTEGETURLS)]
        public IActionResult GetUrls()
        {
            return Ok(modificationUrl.GetAllUrlData());
        }

        [Route(UrlRoutesHelper.ROUTEGETURL)]
        public IActionResult GetUrl(int id)
        {
            return Ok(modificationUrl.GetUrl(id));
        }

        [Route(UrlRoutesHelper.ROUTECREATEURL)]
        public IActionResult CreateUrlData([FromBody]UrlModel value)
        {
            RequestUrlResult result = modificationUrl.CreateShortUrl(value);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Put([FromBody]UrlModel value)
        {
            return Ok(modificationUrl.UpdateUrl(value));
        }

        [HttpDelete(UrlRoutesHelper.ROUTEDELETEURL)]
        public IActionResult Delete(int id)
        {
            return Ok(modificationUrl.DeleteUrl(id));
        }

        [HttpGet (UrlRoutesHelper.ROUTEREDIRECTURL)]
        public IActionResult RedirectUrl(string id)
        {
            string url = modificationUrl.RedirectUrl(id);
            return Redirect(url);
        }
    }
}
