using task_api.Migrations;
using task_api.Models;

namespace task_api.Repositories;

public class TaskRepositories : iTaskRepositories
{
   private readonly taskDbContext _context;

   public TaskRepositories(taskDbContext context)
   {
    _context = context;
   }

    public task createTask(task newTask)
    {
       _context.task.Add(newTask);
       _context.SaveChanges();
       return newTask;
    }

    public void DeleteTaskById(int TaskId)
    {
       var task = _context.task.Find(TaskId);
       if (task != null)
       {
        _context.task.Remove(task);
        _context.SaveChanges();
       }
    }

    public IEnumerable<task> GetAllTasks()
    {
        return _context.task.ToList();
    }

    public task GetTaskById(int TaskId)
    {
        return _context.task.SingleOrDefault(c => c.TaskId == TaskId);
    }

    public task updateTask(task newTask)
    {
        var currentTask = _context.task.Find(newTask.TaskId);
        if (currentTask != null)
        {
            currentTask.Title = newTask.Title;
            currentTask.Completed = newTask.Completed;
            _context.SaveChanges();
        }

        return currentTask;
    }
}