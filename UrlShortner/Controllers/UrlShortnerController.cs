using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrlShortner.Models;

namespace UrlShortner.Controllers
{
    public class UrlShortnerController : Controller
    {
        private UrlContext db = new UrlContext();
        // GET: UrlShortner
        public ActionResult Index()
        {
            return View("View");
        }

        // POST: Url/Shorten
        [HttpPost]
        public ActionResult Shorten(string longUrl)
        {
            if (ModelState.IsValid)
            {
                var existingUrl = db.Urls.FirstOrDefault(u => u.LongUrl == longUrl);

                if (existingUrl != null)
                {
                    // Url with the same LongUrl already exists, return the existing record
                    return Json(new { shortUrl = existingUrl.ShortUrl });
                }
                else
                {
                    var shortUrl = GenerateShortUrl();
                    var url = new Url { LongUrl = longUrl, ShortUrl = shortUrl };
                    db.Urls.Add(url);
                    db.SaveChanges();
                    return Json(new { shortUrl = shortUrl });

                }
               
            }
            return Json(new { error = "Invalid URL" });
        }

    
        [HttpPost]
        public ActionResult RedirectUrl(string shortUrl, string ipadress, string browser)
        {
            try
            {
                var url = db.Urls.FirstOrDefault(u => u.ShortUrl == shortUrl);
                if (url != null)
                {
                    var data = Json(new { url = url });

                    // Increment click count
                    url.Clicks++;

                    // Store IP address
                    url.IPAddress = ipadress;

                    // Store user agent
                    url.UserAgent = browser;

                    db.SaveChanges();
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
                return Json(new { error = "Invalid URL" });
            }catch(Exception ex)
            {
                return Json(new { error = "Invalid URL" });
            }
        }

        private string GenerateShortUrl()
        {
          
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var shortUrl = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
            return shortUrl;
        }

        public ActionResult GetAll()
        {
            // Retrieve all data from the Url table
            var urls = db.Urls.ToList();

            // Return the data to the view
            return Json(urls, JsonRequestBehavior.AllowGet);
        }
    }
}