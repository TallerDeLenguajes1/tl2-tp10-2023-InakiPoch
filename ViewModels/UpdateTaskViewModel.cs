using tl2_tp10_2023_InakiPoch.Models;
using System.ComponentModel.DataAnnotations;

namespace tl2_tp10_2023_InakiPoch.ViewModels;

public class UpdateTaskViewModel {
    [Required(ErrorMessage = "Campo requerido")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    public TasksState State { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    public string Color { get; set; }


    public UpdateTaskViewModel() {}

    public UpdateTaskViewModel(Tasks task) {
        Id = task.Id;
        Name = task.Name;
        State = task.State;
        Description = task.Description;
        Color = task.Color;
    }
}