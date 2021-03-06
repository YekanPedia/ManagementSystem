﻿namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using System.Collections.Generic;
    using Domain.Entity;
    using InfraStructure;
    using System;

    public interface ICourseService
    {
        IEnumerable<Course> GetValidCourses();
        IEnumerable<Course> GetAllCourses();
        IServiceResults<bool> ChangeCourseStatus(int id, bool status);
        Course FindCourse(int id);
        IServiceResults<int> AddCourse(string type);
        IEnumerable<Course> GetUserCourses(Guid userId);
        IEnumerable<Course> GetAllCoursesHasStaticFiles();
    }
}
