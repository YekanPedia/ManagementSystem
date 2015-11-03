namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using System.Collections.Generic;
    using Domain.Entity;

    public interface ICourseService
    {
        IEnumerable<Course> GetCourses();
    }
}
