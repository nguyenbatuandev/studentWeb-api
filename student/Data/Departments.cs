namespace student.Data
{
    public class Departments
    {
        public int Id { get; set; }
        public string? DepartmentName { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Students>? Students { get; set; }
    }
}
