using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URl_Project.Models;
using URl_Project.Service;

namespace URl_Project.Interfaces
{
    public interface IModificationUrl
    {
        RequestUrlResult CreateShortUrl(UrlModel urlModel);
        RequestUrlResult GetAllUrlData();
        RequestUrlResult GetUrl(int id);
        RequestUrlResult UpdateUrl(UrlModel urlModel);
        RequestUrlResult DeleteUrl(int id);
        string RedirectUrl(string id);
    }
}
