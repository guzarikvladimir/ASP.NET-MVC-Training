using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Entities
{
    public class UserTaskEntity
    {
        public int UserId { get; set; }
        public int TaskId { get; set; }
        public int PointsCompleted { get; set; }
        public int StatusId { get; set; }
    }
}
