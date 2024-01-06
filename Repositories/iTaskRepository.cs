using System.Reflection;
using task_api.Models;

namespace task_api.Repositories;
public interface iTaskRepositories
{
    IEnumerable<task> GetAllTasks();
    task GetTaskById(int TaskId);
    task createTask(task newTask);
    task updateTask(task newTask);
    void DeleteTaskById(int TaskId);
}