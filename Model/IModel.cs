using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace efcore_modelconfig_demo.Model; 

public interface IModel {
  void ConfigureModel(EntityTypeBuilder builder);
}