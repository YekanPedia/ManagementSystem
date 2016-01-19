namespace YekanPedia.ManagementSystem.Service.Interfaces
{
    using System.Collections.Generic;
    using Domain.Entity;

    public interface ITopicService
    {
        List<Topic> GetAllTopic();
        Topic Find(int topicId);
    }
}
