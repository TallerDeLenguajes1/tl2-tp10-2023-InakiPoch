using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_InakiPoch.Repositories;
using tl2_tp10_2023_InakiPoch.Models;

namespace tl2_tp10_2023_InakiPoch.Controllers;

public class TasksController : Controller {
    private readonly ILogger<TasksController> _logger;
    TasksRepository tasksRepository;

    public TasksController(ILogger<TasksController> logger) {
        tasksRepository = new TasksRepository();
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index() {
        if(HttpContext.Session.GetString("Usuario") == string.Empty) 
            return RedirectToRoute(new { controller = "Login", action = "Index"});
        return View(tasksRepository.GetAll());
    }

    [HttpGet]
    public IActionResult Add() => View(new Tasks());

    [HttpPost]
    public IActionResult Add(Tasks tasks) {
        tasksRepository.Add(tasks.BoardId, tasks);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Update(int id) => View(tasksRepository.GetById(id));

    [HttpPost]
    public IActionResult Update(Tasks tasks) {
        tasksRepository.Update(tasks.Id, tasks);
        return RedirectToAction("Index");
    }


    [HttpGet]
    public IActionResult Delete(int id) {
        tasksRepository.Delete(id);
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
