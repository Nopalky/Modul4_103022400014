// See https://aka.ms/new-console-template for more information

public class KodePaket {

    public enum namaPaket { Basic, Standar, Premium, Unlimited, Gaming, Streaming, Family, Business, Student, Teacher};

    public static string getKodePaket(string namapaket)
    {
        string[] kodePaket = { "P201", "P202", "P203", "P204", "P205", "P206", "P207", "P208", "P209", "P210"};

        return kodePaket[(int)Enum.Parse(typeof(namaPaket), namapaket)];
    }
}

public class main { 
    public static void Main(string[] args)
    {
        Console.WriteLine("====================== Program Kode Paket ======================");
        Console.WriteLine("Masukkan nama paket (Basic, Standar, Premium, Unlimited, Gaming, Streaming, Family, Business, Student, Teacher): ");
        string namapaket = Console.ReadLine();
        string kodePaket = KodePaket.getKodePaket(namapaket);
        Console.WriteLine($"Kode paket untuk {namapaket} adalah: {kodePaket}");
    }
}