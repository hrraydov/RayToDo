using RayToDo.Data.EntityFramework.Models;
using System.Collections.Generic;

namespace RayToDo.Services.Interfaces
{
    public interface ITaskListService : IDataService<TaskList>
    {
        IEnumerable<TaskList> GetByCreatorId(int creatorId);

        IEnumerable<TaskList> GetInvolvedInto(int userId);

        /// <summary>
        /// Invites user to task list
        /// </summary>
        /// <param name="taskList"></param>
        /// <param name="username"></param>
        void Invite(TaskList taskList, string username);

        /// <summary>
        /// Accepts given invitation
        /// </summary>
        /// <param name="taskList"></param>
        /// <param name="username"></param>
        void AcceptInvitation(TaskList taskList, string username);

        /// <summary>
        /// Declines given invitation
        /// </summary>
        /// <param name="taskList"></param>
        /// <param name="username"></param>
        void DeclineInvitation(TaskList taskList, string username);

        /// <summary>
        /// Gives a right to a member
        /// </summary>
        /// <param name="taskList"></param>
        /// <param name="username"></param>
        /// <param name="right"></param>
        void AddRight(TaskList taskList, string username, string right);

        /// <summary>
        /// Removes a right from a member
        /// </summary>
        /// <param name="taskList"></param>
        /// <param name="username"></param>
        /// <param name="right"></param>
        void RemoveRight(TaskList taskList, string username, string right);

        /// <summary>
        /// Checks if user has right
        /// </summary>
        /// <param name="taskList"></param>
        /// <param name="username"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        bool CheckRight(TaskList taskList, string username, string right);
    }
}