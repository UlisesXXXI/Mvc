using jim.Frontal.Helpers.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jim.Frontal.Helpers.Controllers
{
    public class BaseController: Controller
    {
        
        private MessageManager _messageManager = new MessageManager();

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

        }


        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            ManageMessages(filterContext);

            
        }


        protected void AddMessage(String message, MessageType type)
        {
            _messageManager.SetMessage(message, type);
        }

        private void ManageMessages(ActionExecutedContext filterContext)
        {
            if (filterContext.Result is JsonResult) return;

            List<Message> oldMessages =  TempData[Constantes.MessageManagerConst.MESSAGES_TEMP_DATA] as List<Message>;
            if(oldMessages == null)
            {
                oldMessages = new List<Message>();
            }
            if (_messageManager.HasMessages)
            {
                foreach (var msg in _messageManager.Messages)
                {
                    oldMessages.Add(msg);
                }
            }

            TempData[Constantes.MessageManagerConst.MESSAGES_TEMP_DATA] = oldMessages;
            
           
        }


    }
}