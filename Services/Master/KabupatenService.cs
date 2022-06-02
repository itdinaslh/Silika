using Silika.Entity;
using Silika.Data;
using Silika.Repository;
using Microsoft.EntityFrameworkCore;

namespace Silika.Services;

public class KabupatenService : IKabupatenRepo {
    private AppDbContext context;

    public KabupatenService(AppDbContext ctx) => context = ctx;

    public IQueryable<Kabupaten> Kabupatens => context.Kabupatens;
}