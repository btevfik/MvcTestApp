using System;
using System.Web;
using Microsoft.AspNet.SignalR;
using MvcAppTest2.Models;

namespace MvcAppTest2.Hubs
{
    public class ChatHub : Hub
    {

        public void AddComment(int sessionID, string content)
        {
            ConferenceContext context = new ConferenceContext();
            Comment commment = new Comment() { SessionID = sessionID, Content = content };
            context.Comments.Add(commment);
            context.SaveChanges();

            Clients.Group(sessionID.ToString()).AddNewComment(content);
        }

        public void Register(int sessionID)
        {
            Groups.Add(Context.ConnectionId, sessionID.ToString());
        }
    }
}