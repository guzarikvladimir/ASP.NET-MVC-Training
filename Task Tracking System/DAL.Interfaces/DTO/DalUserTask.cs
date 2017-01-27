namespace DAL.Interfaces.DTO
{
    public class DalUserTask
    {
        public int UserId { get; set; }
        public int TaskId { get; set; }
        public int PointsCompleted { get; set; }
        public int StatusId { get; set; }
    }
}
