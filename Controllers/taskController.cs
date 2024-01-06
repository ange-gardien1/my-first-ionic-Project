using Microsoft.AspNetCore.Mvc;
using task_api.Models;
using task_api.Repositories;

namespace task_api.controllers;
[ApiController]
[Route("Task")]
public class taskController : ControllerBase
{
    private readonly ILogger<taskController> _logger;
    private readonly iTaskRepositories _taskRepository;

    public taskController(ILogger<taskController> logger, iTaskRepositories repository)
    {
        _logger = logger;
        _taskRepository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<task>> GetTasks()
    {
        return Ok(_taskRepository.GetAllTasks());
    }

    [HttpGet]
    [Route("{TaskId:int}")]
    public ActionResult<Task> GetTaskById(int TaskId)
    {
        var task = _taskRepository.GetTaskById(TaskId);
        if (task == null)
        {
            return NotFound();
        }
        return Ok(task);
    }

    [HttpPost]
    public ActionResult<task> createTask(task task)
    {
     if(!ModelState.IsValid || task == null)
     {
        return BadRequest();
     }
        var newTask = _taskRepository.createTask(task);
        return Created(nameof(GetTaskById), newTask);
    }

    [HttpPut]
    [Route("{taskId:int}")]

    public ActionResult <task> updateTask(task task)
    {
        if(!ModelState.IsValid || task == null)
        {
            return BadRequest();
        }

        return Ok(_taskRepository.updateTask(task));
    }

    [HttpDelete]
    [Route("{taskId:int}")]

    public ActionResult DeleteTask(int TaskId)
    {
        _taskRepository.DeleteTaskById(TaskId);
        return NoContent();
    }
}
