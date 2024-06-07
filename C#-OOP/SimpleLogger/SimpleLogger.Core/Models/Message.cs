using SimpleLogger.Core.Enums;
using SimpleLogger.Core.Exceptions;
using SimpleLogger.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.Core.Models
{
    public class Message
    {
        private string dateTime;
        private string messageText;
        public Message(string dateTime, string messageText, ReportLevel reportlevel)
        {
            DateTime = dateTime;
            MessageText = messageText;
            Reportlevel = reportlevel;
        }

        public string DateTime 
        {
            get => dateTime;
            set
            {
                if (string.IsNullOrWhiteSpace(dateTime))
                {
                    throw new EmptyPropertyException();
                }
                if (!DateTimeValidator.Validate(dateTime))
                {
                    throw new NotValidDataException();
                }
                   
                dateTime = value;
            }
        }
        public string MessageText 
        {
            get => messageText;
            set
            {
                if (string.IsNullOrWhiteSpace(messageText))
                {
                    throw new EmptyPropertyException();
                }

                messageText = value;
            }
        }
        public ReportLevel Reportlevel { get; set; }

    }
}
