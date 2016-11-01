using PasteBook.Manager;
using PasteBookBusinessLogic;
using PasteBookDataAccess;
using PasteBookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PasteBook.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        Post post = new Post();
        Like like = new Like();
        Comment comment = new Comment();
        PostRepository postRepo = new PostRepository();
        CommentRepository commentRepo = new CommentRepository();
        LikeRepository likeRepo = new LikeRepository();
        FilterManager filter = new FilterManager();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult AddPost(int userId, string post, int ProfileOwnerID)
        {

            var result = this.post.AddPost(userId, filter.trimOneString(post), ProfileOwnerID);
            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddOrDeleteLike(int postID)
        {
            string status = "";
            int user;
            int.TryParse(Session["ID"].ToString(), out user);
            var result = like.AddOrDeleteLike(user, postID, out status);
            return Json(new { result = result, status = status }, JsonRequestBehavior.AllowGet);
        }
        [Route("posts/{id}")]
        [CustomAuthorization]
        public ActionResult Posts(int id)
        {
            var result = postRepo.GetPost(id);
            return View(result);
        }
        public JsonResult AddComment(int postID, int posterID, string content)
        {
            var result = comment.AddComment(new PB_COMMENTS
            {
                POST_ID = postID,
                POSTER_ID = posterID,
                CONTENT = content,
                DATE_CREATED = DateTime.Now

            });
            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }
    }
}