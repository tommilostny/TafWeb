namespace TafWeb.DAL;

public static class Seed
{
    public static async Task SeedDatabaseAsync(this TafWebDbContext context, UserManager<TafUser> userManager)
    {
        var tom = new TafUser
        {
            UserName = "tom",
            Email = "tmilostny@skupinataf.cz",
            Name = "Tomáš Milostný",
            Description = "Popis 1",
        };
        await userManager.CreateAsync(tom, "Password1!");
        var frank = new TafUser
        {
            UserName = "frank",
            Email = "fpetru@skupinataf.cz",
            Name = "František Petrů",
            Description = "Popis 2",
        };
        await userManager.CreateAsync(frank, "Password2!");
        var aboutUsData = new AboutUs
        {
            ShortDesctiption = "TafWeb",
            LongDescription = "TafWeb je firma zabývající se vývojem webových stránek a aplikací.",
        };
        context.AboutUs.AddRange(aboutUsData);

        var videoCategoriesData = new[]
        {
            new VideoCategory
            {
                Id = VideoCategoryType.Wedding,
                Name = "Svatby",
                ShortDescription = "Svatby",
                LongDescription = "Svatby",
                Videos = new()
                {
                    new Video
                    {
                        Title = "Svatební video",
                        Description = "Svatební video",
                        VideoUrl = "https://www.youtube.com/embed/9bZkp7q19f0",
                        Thumbnail = "https://i.ytimg.com/vi/9bZkp7q19f0/hqdefault.jpg",
                        Published = new DateTime(2012, 7, 15)
                    },
                    new Video
                    {
                        Title = "Svatební video 2",
                        Description = "Svatební video 2",
                        VideoUrl = "https://www.youtube.com/embed/9bZkp7q19f0",
                        Thumbnail = "https://i.ytimg.com/vi/9bZkp7q19f0/hqdefault.jpg",
                        Published = new DateTime(2012, 7, 15)
                    }
                },
            },
            new VideoCategory
            {
                Id = VideoCategoryType.Prom,
                Name = "Maturitní plesy",
                ShortDescription = "Natáčení maturitních plesů",
                LongDescription = "Natáčení maturitních plesů je naše specializace.",
                Videos = new()
                {
                    new Video
                    {
                        Title = "Maturitní ples",
                        Description = "Maturitní ples",
                        VideoUrl = "https://www.youtube.com/embed/9bZkp7q19f0",
                        Thumbnail = "https://i.ytimg.com/vi/9bZkp7q19f0/hqdefault.jpg",
                        Published = new DateTime(2012, 7, 15)
                    },
                    new Video
                    {
                        Title = "Maturitní ples 2",
                        Description = "Maturitní ples 2",
                        VideoUrl = "https://www.youtube.com/embed/9bZkp7q19f0",
                        Thumbnail = "https://i.ytimg.com/vi/9bZkp7q19f0/hqdefault.jpg",
                        Published = new DateTime(2012, 7, 15)
                    }
                },
            }
        };
        context.VideoCategories.AddRange(videoCategoriesData);

        var formEntries = new[]
        {
            new FormEntry
            {
                Name = "Petra Nováková",
                Email = "petra@novakova.cz",
                Message = "Dobrý den, chtěla bych se zeptat, zda byste měli volno na 15. 8. 2021. Děkuji.",
                VideoCategory = VideoCategoryType.Wedding,
                Date = new DateOnly(2021, 8, 15),
                Place = "Praha",
            },
            new FormEntry
            {
                Name = "Petr Novák",
                Email = "petricek_novacek@seznam.cz",
                Message = "Dobrý den, chtěl bych natočit ples na naší škole. Máte volno 15. 2. 2021? Děkuji.",
                VideoCategory = VideoCategoryType.Prom,
                Date = new DateOnly(2021, 2, 15),
                Place = "Brno",
            }
        };
        context.FormEntries.AddRange(formEntries);

        await context.SaveChangesAsync();
    }
}
