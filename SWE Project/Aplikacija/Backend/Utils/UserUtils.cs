namespace Backend.Utils;

public static class UserUtils
{
    public static async Task<BannedDto?> IsBanned(Korisnik korisnik, Context context)
    {
        return await context.Zabrane.Where(x => x.Korisnik == korisnik && x.DatumDo > DateTime.Now)
                                    .Select(x => new BannedDto
                                    {
                                        Razlog = x.Razlog!,
                                        DatumDo = x.DatumDo
                                    })
                                    .FirstOrDefaultAsync();
    }
}