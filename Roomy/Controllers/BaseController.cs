using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Roomy.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomy.Controllers
{
    public class BaseController : Controller
    {
        protected RoomyDbContext db;
        public BaseController(RoomyDbContext db)
        {
            this.db = db;
        }

        protected void DisplayMessage(string message, MessageType type)
        {
            TempData["Display"] = JsonConvert.SerializeObject( new Display { Message = message, Type = type });
        }
    }

    public enum MessageType
    {
        OK = 1,
        ERROR = 2
    }

    public class Display
    {
        public string Message { get; set; }
        public MessageType Type { get; set; }
    }
}
