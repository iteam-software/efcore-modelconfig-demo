using Microsoft.Extensions.Hosting;
using efcore_modelconfig_demo.Model;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace efcore_modelconfig_demo; 

public class Runner : IHostedService {
  private readonly TaskingContext db_;

  public Runner(TaskingContext db) {
    db_ = db;
  }

  public async Task StartAsync(CancellationToken token) {
    var expanse = new Book {
        Name = "Leviathan Wakes"
    };

    var ilium = new Book {
        Name = "Ilium"
    };

    db_.AddRange(expanse, ilium);
    await db_.SaveChangesAsync(token);

    var books = await db_.Set<Book>().ToListAsync();

    foreach (var entity in books) {
      Console.WriteLine($"{entity.Id}: {entity.Name}");
    }
  }

  public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}