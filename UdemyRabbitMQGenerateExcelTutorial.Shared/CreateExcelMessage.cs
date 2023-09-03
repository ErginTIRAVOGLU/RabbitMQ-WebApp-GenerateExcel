using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyRabbitMQGenerateExcelTutorial.Shared
{
    public class CreateExcelMessage
    {
        public string UserID { get; set; }
        public int FileId { get; set; }
    }
}
