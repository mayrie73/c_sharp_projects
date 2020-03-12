using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using wall.Models;

namespace wall.Controllers
{
    public class WallController : Controller
    {
        private readonly DbConnector _dbConnector;

        public WallController(DbConnector connect)
        {
            _dbConnector = connect;
        }
        [HttpGet]
        [Route("wall")]
        public IActionResult Wall()
        {
            int? id = HttpContext.Session.GetInt32("id");
            string name = HttpContext.Session.GetString("user");
            string messageQuery = "SELECT message, users_id, messages.created_at, users.first_name, users.last_name FROM messages JOIN users ON messages.users_id WHERE messages.users_id = users.id";
            var messages = _dbConnector.Query(messageQuery);
            string commentQuery = "SELECT comment, comments.created_at, users.first_name, users.last_name, comments.messages_id FROM comments JOIN users ON comments.users_id WHERE comments.users_id = users.id";
            var comments = _dbConnector.Query(commentQuery);
            ViewBag.name = name;
            ViewBag.id = id;
            ViewBag.messages = messages;
            ViewBag.comments = comments;
            return View();
        }
        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Users");
        }
        [HttpPost]
        [Route("postMessage")]
        public IActionResult postMessage(string message)
        {
            int? id = HttpContext.Session.GetInt32("id");
            if (id == null)
            {
                return RedirectToAction("Index", "Users");
            }
            if (message.Length > 0)
            {
                int users_id = (int)id;
                string query = $"INSERT INTO messages(users_id, message, created_at)VALUES({users_id}, '{message}', NOW())";
                _dbConnector.Execute(query);
            }
            return RedirectToAction("Wall");
        }
        [HttpPost]
        [Route("postComment")]
        public IActionResult postComment(string comment, int messages_id, int users_id)
        {
            int? id = HttpContext.Session.GetInt32("id");
            if (id == null)
            {
                return RedirectToAction("Index", "Users");
            }
            if (comment.Length > 0)
            {
                string query = $"INSERT INTO comments(users_id, messages_id, comment, created_at, updated_at)VALUES({users_id}, {messages_id}, '{comment}', NOW(), NOW())";
                _dbConnector.Execute(query);
            }
            return RedirectToAction("Wall");
        }

        [HttpGet]
        [Route("delete/{messages_id}")]
        public IActionResult deleteMessage(int messages_id)
        {
            string query1 = $"DELETE FROM comments WHERE messages_id = {messages_id}";
            string query2 = $"DELETE FROM messages WHERE message_id = {messages_id}";
            _dbConnector.Execute(query1);
            _dbConnector.Execute(query2);
            return RedirectToAction("Wall");
        }
    }

}


