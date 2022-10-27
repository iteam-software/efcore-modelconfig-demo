using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

namespace efcore_modelconfig_demo.Model; 

public class Book : IModel {
  public int Id { get; set; }

  public string Name { get; set; }

  public void ConfigureModel(EntityTypeBuilder builder) {
    Console.WriteLine("We're configuring in a type-safe way");
    builder.HasKey(nameof(Id));
    builder.Property<int>(nameof(Id)).ValueGeneratedOnAdd();
  }
}