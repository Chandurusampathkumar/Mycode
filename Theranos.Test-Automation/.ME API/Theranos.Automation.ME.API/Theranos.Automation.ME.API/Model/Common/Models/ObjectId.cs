using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.Common.Models
{
    // This class is supposed to be "MongoDB.Bson.ObjectId"

    public class ObjectId
    {
        public int Timestamp { get; set; }
        public int Machine { get; set; }
        public int Pid { get; set; }
        public int Increment { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
