namespace TafWeb.DAL;

public static class Seed
{
    public static async Task SeedDatabaseAsync(this TafWebDbContext context, UserManager<TafUser> userManager)
    {
        if ((await context.AboutUs.ToListAsync()).Count > 0)
        {
            Console.WriteLine("Database already seeded.");
            return;
        }
        var tom = new TafUser
        {
            UserName = "tom",
            Email = "tommilostny@live.com",
            Name = "Bc. Tomáš Milostný",
            Description = "Student Fakulty informačních technologií VUT v Brně. Je zakládajícím členem skupiny a od počátku se podílí na většině filmech, které pod její hlavičkou vznikly. Vyvíjí a spravuje webové stránky, věnuje se práci s kamerou a pokročilému střihu.",
            FacebookUrl = "https://www.facebook.com/tommilostny",
            TwitterUrl = "https://twitter.com/TomMilostny95",
            InstagramUrl = "https://www.instagram.com/tommilostny.jpgs",
        };
        await userManager.CreateAsync(tom, "Password1!");
        var franki = new TafUser
        {
            UserName = "franki",
            Email = "fandapetru@gmail.com",
            Name = "Bc. František Petrů",
            Description = "Absolvent žurnalistiky na Masarykově univerzitě, který se videoprodukci věnuje už více než desetiletí. Mou prací je nejen ovládání hlavní kamery a střih, ale také pečlivá online prezentace a komunikace s klienty. S vášní se snažím vytvářet vizuální zážitky, které budou oslovovat publikum a budit emoce. Mám kameramanské zkušenosti z univerzitní televize, hokejového týmu či různých spolků. Jako píšící novinář jsem pracoval pro Deník N a iDnes.cz.",
            FacebookUrl = "https://www.facebook.com/fpetru104",
            TwitterUrl = "http://www.twitter.com/FrantisekPetru",
            InstagramUrl = "https://www.instagram.com/frantisek_petru",
            PhoneNumber = "+420739837790",
        };
        await userManager.CreateAsync(franki, "Password2!");
        var aboutUsData = new AboutUs
        {
            ShortDesctiption = "Jsme dvojice kameramanů, která už desetiletí spolupracuje na nejrůznějších videoprojektech. V posledních letech jde zejména o zakázkovou tvorbu ze svateb, plesů, ochotnických divadel, rodinných oslav a jiných společenských událostí. Natáčíme zejména na Vysočině, ale nejsou pro nás problém ani jiné lokality. Dokážeme z vašich důležitých momentů vykouzlit obrazově atraktivní materiály, které jen tak neskončí v zapomnění.\r\n\r\n",
            LongDescription = "Všechno točíme na dvě kamery, která každá dokáže zachytit jiný aspekt vašich momentů. Každou sekundu hotového videa ladíme ve dvojici. Od výběru záběrů, jejich střihu, zpomalení, barvení po opravy závěrečné verze. Nejsou nám cizí ani letecké záběry. Venkovní zakázky natáčíme s dronem pro lepší úvod do místa, kde se vaše událost odehrává.\nMáte zájem o video? Zadejte nezávaznou objednávku na webu nebo nám napište kamkoliv na naše sítě a řekněte nám svoji představu! Cena se odvíjí od konkrétních požadavků, které na nás budete mít.",
        };
        context.AboutUs.AddRange(aboutUsData);

        var videos = new[]
        {
            new Video
            {
                Title = "Svatební video 1",
                Description = "Svatební video 2",
                VideoUrl = "https://www.youtube.com/embed/9bZkp7q19f0",
                Published = new DateTime(2012, 7, 15),
                Category = VideoCategoryType.Wedding,
                Route = "svatebni-video-1",
            },
            new Video
            {
                Title = "Svatební video 2",
                Description = "Svatební video 2",
                VideoUrl = "https://www.youtube.com/embed/9bZkp7q19f0",
                Published = new DateTime(2012, 7, 16),
                Category = VideoCategoryType.Wedding,
                Route = "svatebni-video-2",
            },
            new Video
            {
                Title = "Maturitní ples",
                Description = "Maturitní ples",
                VideoUrl = "https://www.youtube.com/embed/9bZkp7q19f0",
                Published = new DateTime(2012, 7, 15),
                Category = VideoCategoryType.Prom,
                Route = "maturitni-ples",
            },
            new Video
            {
                Title = "Maturitní ples 2",
                Description = "Maturitní ples 2",
                VideoUrl = "https://www.youtube.com/embed/9bZkp7q19f0",
                Published = new DateTime(2012, 7, 15),
                Category = VideoCategoryType.Prom,
                Route = "maturitni-ples-2",
            },
            new Video
            {
                Title = "Něco jiného",
                Description = "Popisek něčeho jiného",
                VideoUrl = "https://www.youtube.com/embed/9bZkp7q19f0",
                Published = new DateTime(2013, 7, 15),
                Category = VideoCategoryType.Other,
                Route = "neco-jineho",
            }
        };
        context.Videos.AddRange(videos);

        var videoCategoriesData = new[]
        {
            new VideoCategory
            {
                Id = VideoCategoryType.Wedding,
                Name = "Svatební videa",
                ShortDescription = "Popisek svatebních videí na hlavní stráce...",
                LongDescription = "Popisek svatebních videí na stránce detailu kategorie...",
                IsVisible = true,
                Route = "svatby",
            },
            new VideoCategory
            {
                Id = VideoCategoryType.Prom,
                Name = "Maturitní plesy",
                ShortDescription = "Natáčení maturitních plesů",
                LongDescription = "Natáčení maturitních plesů je naše specializace.",
                IsVisible = true,
                Route = "plesy",
            },
            new VideoCategory
            {
                Id = VideoCategoryType.Other,
                Name = "Ostatní eventy",
                ShortDescription = "Popisek ostatních eventů na hlavní stránce.",
                LongDescription = "Popisek ostatních eventů na stránce detailu kategorie.",
                IsVisible = true,
                Route = "ostatni",
            },
            new VideoCategory
            {
                Id = VideoCategoryType.Theater,
                Name = "Ochotnická divadla",
                ShortDescription = "Popisek ochotnických divadel na hlavní stránce.",
                LongDescription = "Popisek ochotnických divadel na stránce detailu kategorie.",
                IsVisible = false,
                Route = "divadla",
            },
            new VideoCategory
            {
                Id = VideoCategoryType.Corporate,
                Name = "Firemní videa",
                IsVisible = false,
                Route = "firemni",
            },
            new VideoCategory
            {
                Id = VideoCategoryType.Music,
                Name = "Hudební videa",
                IsVisible = false,
                Route = "hudba",
            }
        };
        context.VideoCategories.AddRange(videoCategoriesData);

        var formEntries = new[]
        {
            new OrderFormEntry
            {
                Name = "Petra Nováková",
                Email = "petra@novakova.cz",
                Message = "Dobrý den, chtěla bych se zeptat, zda byste měli volno na 15. 8. 2021. Děkuji.",
                VideoCategory = VideoCategoryType.Wedding,
                Date = new DateOnly(2021, 8, 15),
                Place = "Praha",
            },
            new OrderFormEntry
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

        var clientFeedbacks = new[]
        {
            new ClientFeedback
            {
                Name = "Petr Novák",
                Text = "Děkujeme za skvělé video.",
            },
            new ClientFeedback
            {
                Name = "Petra Nováková",
                Text = "Děkujeme za skvělé video. Je to přesně to, co jsme chtěli.",
            },
        };
        context.ClientFeedbacks.AddRange(clientFeedbacks);

        await context.SaveChangesAsync();
    }
}
