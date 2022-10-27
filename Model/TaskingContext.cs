using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace efcore_modelconfig_demo.Model; 

public class TaskingContext : DbContext {
  private readonly IEnumerable<IModel> models_;
  public TaskingContext(DbContextOptions<TaskingContext> options, IEnumerable<IModel> models) : base(options) {
    models_ = models;
  }

  protected override void OnModelCreating(ModelBuilder model_builder) {
    foreach (var model in models_) {
      model.ConfigureModel(model_builder.Entity(model.GetType()));
    }
  }
}