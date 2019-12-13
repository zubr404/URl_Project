using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URl_Project.Interfaces;
using URl_Project.Models;

namespace URl_Project.Service
{
    public class ModificationUrlService : IModificationUrl
    {
        IUnitOfWork db;
        public ModificationUrlService(IUnitOfWork context)
        {
            db = context;
        }

        public RequestUrlResult GetAllUrlData()
        {
            RequestUrlResult result = new RequestUrlResult();
            List<UrlModel> urls = db.UrlModels.GetAll();

            if(urls != null)
            {
                if (urls.Count > 0)
                {
                    result.IsSuccess = true;
                    result.UrlModelsResult = urls;
                }
                else
                {
                    result.IsSuccess = false;
                }
            }
            else
            {
                result.IsSuccess = false;
            }

            if (!result.IsSuccess)
            {
                result.ErrorMes = "Получение всех данных не дало результатов.";
            }
            
            return result;
        }

        public RequestUrlResult GetUrl(int id)
        {
            RequestUrlResult result = new RequestUrlResult();
            UrlModel url = db.UrlModels.Get(id);

            if(url != null)
            {
                result.IsSuccess = true;
                result.UrlModelResult = url;
            }
            else
            {
                result.IsSuccess = false;
                result.ErrorMes = "Получение данных Url не дало результатов";
            }

            return result;
        }

        public RequestUrlResult CreateShortUrl(UrlModel urlModel)
        {
            RequestUrlResult result = new RequestUrlResult();

            if (urlModel != null)
            {
                if (GetIsCorrectUrl(urlModel.UrlLong))
                {
                    if (!GetIsSameUrlLong(urlModel.UrlLong))
                    {
                        if (urlModel.UrlShort == "")
                        {
                            string shortUrl = new UniqueSequenceGenerator().GetSequence();
                            UrlModel _urlmodel = AddUrlModel(urlModel.UrlLong, shortUrl, DateTime.Now);
                            result.IsSuccess = true;
                            result.UrlModelResult = _urlmodel;
                            result.UrlShortCustomer = UrlRoutesHelper.ROUTEHOST.Replace("http", "https") + UrlRoutesHelper.ROUTECONTROLLER + "/" + shortUrl;
                        }
                        else
                        {
                            if (GetIsCorrectUrl(urlModel.UrlShort, isLongUrl: false))
                            {
                                if (!GetIsSameUrlShort(urlModel.UrlShort))
                                {
                                    UrlModel _urlmodel = AddUrlModel(urlModel.UrlLong, urlModel.UrlShort, DateTime.Now);
                                    result.IsSuccess = true;
                                    result.UrlModelResult = _urlmodel;
                                }
                                else
                                {
                                    result.IsSuccess = false;
                                    result.ErrorMes = "Короткий URL уже имеется!";
                                }
                            }
                            else
                            {
                                result.IsSuccess = false;
                                result.ErrorMes = "Короткий URL имеет неверный формат!";
                            }
                        }
                    }
                    else
                    {
                        result.IsSuccess = false;
                        result.ErrorMes = "Изначальный URL уже имеется!";
                    }
                }
                else
                {
                    result.IsSuccess = false;
                    result.ErrorMes = "Изначальный URL имеет неверный формат!";
                }
            }
            else
            {
                result.IsSuccess = false;
                result.ErrorMes = "Неизвестная ошибка!";
            }
            return result;
        }

        public RequestUrlResult UpdateUrl(UrlModel urlModel)
        {
            RequestUrlResult result = new RequestUrlResult();

            if (GetIsCorrectUrl(urlModel.UrlShort, isLongUrl: false))
            {
                if (!GetIsSameUrlShort(urlModel.UrlShort))
                {
                    UrlModel urlModel1 = db.UrlModels.Get(urlModel.ID);
                    urlModel1.UrlShort = urlModel.UrlShort;
                    db.Save();
                    result.IsSuccess = true;
                    result.UrlModelResult = urlModel1;
                    result.UrlShortCustomer = UrlRoutesHelper.ROUTEHOST.Replace("http", "https") + UrlRoutesHelper.ROUTECONTROLLER + "/" + urlModel.UrlShort;
                }
                else
                {
                    result.IsSuccess = false;
                    result.ErrorMes = "Короткий URL уже имеется!";
                }
            }
            else
            {
                result.IsSuccess = false;
                result.ErrorMes = "Короткий URL имеет неверный формат!";
            }
            return result;
        }

        public RequestUrlResult DeleteUrl(int id)
        {
            RequestUrlResult result = new RequestUrlResult();

            db.UrlModels.Delete(id);
            result.IsSuccess = true;
            result.UrlModelResult = db.UrlModels.Get(id);
            db.Save();

            return result;
        }

        public string RedirectUrl(string id)
        {
            string result = string.Empty;
            UrlModel url = GetAllUrlData().UrlModelsResult.SingleOrDefault(x => x.UrlShort == id);
            url.NumberClick += 1;
            result = url.UrlLong;
            db.Save();

            return result;
        }

        private UrlModel AddUrlModel(string longUrl, string shortUrl, DateTime dateTime, int numberClick = 0)
        {
            UrlModel _urlmodel = new UrlModel { UrlLong = longUrl, UrlShort = shortUrl, DateTimeInput = dateTime, NumberClick = numberClick };
            db.UrlModels.Create(_urlmodel);
            db.Save();
            return _urlmodel;
        }

        private bool GetIsCorrectUrl(string url, bool isLongUrl = true)
        {
            if (!string.IsNullOrWhiteSpace(url))
            {
                if(Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
                {
                    if (isLongUrl)
                    {
                        if (url.Substring(0, 20).Contains("://"))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private bool GetIsSameUrlShort(string shortUrl)
        {
            List<UrlModel> urls = db.UrlModels.Find(x => x.UrlShort == shortUrl);
            if (urls != null)
            {
                if (urls.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private bool GetIsSameUrlLong(string longUrl)
        {
            List<UrlModel> urls = db.UrlModels.Find(x => x.UrlLong == longUrl);
            if (urls != null)
            {
                if (urls.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
