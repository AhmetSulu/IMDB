using IMDB;

class Program
{
    static void Main()
    {
        // Başlangıç ekranı mesajı
        Console.WriteLine("Lütfen bir film adı ve IMDB puanı giriniz.");

        // Film listesini oluşturur
        List<Movie> movies = new List<Movie>();

        bool continueAdding = true;
        while (continueAdding)
        {
            // Kullanıcıdan film bilgilerini alır
            Console.Write("Film Adı: ");
            string filmName = Console.ReadLine();

            Console.Write("IMDB Puanı: ");
            double imdbRating;
            while (!double.TryParse(Console.ReadLine(), out imdbRating))
            {
                Console.Write("Geçersiz puan. Lütfen tekrar girin: ");
            }

            // Yeni Movie nesnesini oluştur ve listeye ekler
            Movie newMovie = new Movie(imdbRating, filmName);
            movies.Add(newMovie);

            // Kullanıcıya yeni bir film eklemek isteyip istemediğini sorar
            string response;
            do
            {
                Console.Write("Başka bir film eklemek ister misiniz? (E/H): ");
                response = Console.ReadLine().ToUpper();
            } while (response != "E" && response != "H");

            continueAdding = response == "E";
        }

        // Tüm filmleri listeler
        Console.WriteLine("\nTüm Filmler:");
        foreach (var movie in movies)
        {
            Console.WriteLine(movie); // ToString otomatik olarak çağrılır
        }

        // IMDb puanı 4 ile 9 arasında olan filmleri listeler
        Console.WriteLine("\nIMDB Puanı 4 ile 9 Arasında Olan Filmler:");
        foreach (var movie in movies.Where(movie => movie.ImdbRating >= 4 && movie.ImdbRating <= 9))
        {
            Console.WriteLine(movie); // ToString otomatik olarak çağrılır
        }

        // İsmi 'A' ile başlayan filmleri listeler
        Console.WriteLine("\nİsmi 'A' ile Başlayan Filmler:");
        foreach (var movie in movies.Where(movie => movie.FilmName.StartsWith("A", StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine(movie); // ToString otomatik olarak çağrılır
        }
    }
}