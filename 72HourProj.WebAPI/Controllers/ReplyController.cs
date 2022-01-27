using _72HourProj.Models.ReplyModels;
using _72HourProj.Services.ReplyService;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _72HourProj.WebAPI.Controllers
{
    [Authorize]
    public class ReplyController : ApiController
    {
       
        public ReplyService CreateReplyService()
        {
            var authorId = Guid.Parse(User.Identity.GetUserId());
            var replyService = new ReplyService(authorId);
            return replyService;
        }
        
        public IHttpActionResult Post (ReplyCreate reply)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateReplyService();
            if (!service.CreateReply(reply))
                return InternalServerError();

            return Ok();
        }
        

        public IHttpActionResult Get(int id)
        {
            ReplyService replyService = CreateReplyService();
            var reply = replyService.GetRepliesById(id);
            return Ok(reply);
        }
    }
}
