using IMDB;

class Program
{
    static void Main()
    {
        // Başlangıç ekranı mesajı
        Console.WriteLine("Lütfen bir film adı ve IMDB puanı giriniz.");

        // Film listesini oluşturur
        List<Movie> movies = new List<Movie>();

        // Kullanıcıdan film eklemesini sağlar
        AddMovies(movies);

        // Tüm filmleri listeler
        Console.WriteLine("\nTüm Filmler:");
        PrintMovies(movies);

        // IMDb puanı 4 ile 9 arasında olan filmleri listeler
        Console.WriteLine("\nIMDB Puanı 4 ile 9 Arasında Olan Filmler:");
        PrintMovies(FilterMoviesByRating(movies, 4, 9));

        // İsmi 'A' ile başlayan filmleri listeler
        Console.WriteLine("\nİsmi 'A' ile Başlayan Filmler:");
        PrintMovies(FilterMoviesByNameStart(movies, "A"));
    }

    // Kullanıcıdan film eklemesini sağlayan metod
    static void AddMovies(List<Movie> movies)
    {
        bool continueAdding = true;
        while (continueAdding)
        {
            // Kullanıcıdan film bilgilerini alır
            string filmName = GetFilmName();
            double imdbRating = GetImdbRating();

            // Yeni Movie nesnesini oluştur ve listeye ekler
            Movie newMovie = new Movie(imdbRating, filmName);
            movies.Add(newMovie);

            // Kullanıcıya yeni bir film eklemek isteyip istemediğini sorar
            continueAdding = GetContinueAddingResponse();
        }
    }

    // Film adını alır
    static string GetFilmName()
    {
        Console.Write("Film Adı: ");
        return Console.ReadLine();
    }

    // IMDb puanını alır ve geçerliliğini kontrol eder
    static double GetImdbRating()
    {
        double imdbRating;
        Console.Write("IMDB Puanı: ");
        while (!double.TryParse(Console.ReadLine(), out imdbRating))
        {
            Console.Write("Geçersiz puan. Lütfen tekrar girin: ");
        }
        return imdbRating;
    }

    // Kullanıcının devam edip etmeyeceğini alır
    static bool GetContinueAddingResponse()
    {
        string response;
        do
        {
            Console.Write("Başka bir film eklemek ister misiniz? (E/H): ");
            response = Console.ReadLine().ToUpper();
        } while (response != "E" && response != "H");

        return response == "E";
    }

    // Film listesini yazdırır
    static void PrintMovies(IEnumerable<Movie> movies)
    {
        foreach (var movie in movies)
        {
            Console.WriteLine($"Film Adı: {movie.FilmName}, IMDB Puanı: {movie.ImdbRating}");
        }
    }

    // IMDb puanı aralığına göre filtreler
    static IEnumerable<Movie> FilterMoviesByRating(IEnumerable<Movie> movies, double minRating, double maxRating)
    {
        return movies.Where(movie => movie.ImdbRating >= minRating && movie.ImdbRating <= maxRating);
    }

    // İsmi belirli bir harfle başlayan filmleri filtreler
    static IEnumerable<Movie> FilterMoviesByNameStart(IEnumerable<Movie> movies, string startLetter)
    {
        return movies.Where(movie => movie.FilmName.StartsWith(startLetter, StringComparison.OrdinalIgnoreCase));
    }
}