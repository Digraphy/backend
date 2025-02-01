using DigraphyApi.Data;

namespace DigraphyApi.Scripts;

public class Seed(AppDbContext context)
{
    public void SeedDataContext()
    {
        // TODO
        context.SaveChanges();
    }
}
