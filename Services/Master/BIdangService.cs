using Silika.Entity;
using Silika.Data;
using Silika.Repository;
using Microsoft.EntityFrameworkCore;

namespace Silika.Services;

public class BidangService : IBidangRepo {
    private AppDbContext context;

    public BidangService(AppDbContext ctx) => context = ctx;

    public IQueryable<Bidang> Bidangs => context.Bidangs;

    #nullable disable
    public async Task SaveBidangAsync(Bidang bidang) {
        if(bidang.BidangID == Guid.Empty || bidang.BidangID.ToString() == string.Empty) {
            await context.AddAsync(bidang);
        } else {
            Bidang bid = context.Bidangs.FirstOrDefault(b => b.BidangID == bidang.BidangID);

            bid.NamaBidang = bidang.NamaBidang;
            bid.KepalaBidang = bidang.KepalaBidang;

            context.Update(bid);
        }

        await context.SaveChangesAsync();
    }
}