using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bibliobabel.Data;
using Bibliobabel.Data.Repositories;
using Bibliobabel.Domain.Models;
using Bibliobabel.Web.Areas.Api.Controllers;
using Microsoft.AspNet.Identity;

namespace Bibliobabel.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var userId = User.Identity.GetUserId();
            var post = new Post() { Content = "my post koon", UserId = long.Parse(userId) };
            var comment = new Comment { Content = "first comment koon", Id = long.Parse(userId) };
            var repo = new Repository<Comment>(new ApplicationDbContext()) ;
            repo.Insert(comment);
            using (var context = new ApplicationDbContext())
            {
                //context.Comments.Add(comment);
                //context.Posts.Add(post);
                //context.SaveChanges();
            }
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}