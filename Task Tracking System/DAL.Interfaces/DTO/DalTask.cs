using System;
using System.Collections.Generic;

namespace DAL.Interfaces.DTO
{
    public class DalTask : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime DeadlineDate { get; set; }
        public TimeSpan DeadlineTime { get; set; }
        public int TotalPoints { get; set; }
        public int PointsCompleted { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public List<DalUser> Users { get; set; }
    }
}
