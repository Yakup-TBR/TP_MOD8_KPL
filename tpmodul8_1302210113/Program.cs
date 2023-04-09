// See https://aka.ms/new-console-template for more information

using System;
using System.IO;
using Newtonsoft.Json;
using tpmodul8_1302210113;

class Program
{
    static void Main()
    {
        string json = "{}";
        try
        {
            json = File.ReadAllText(@"C:\Users\Yakup Asmaidy\OneDrive\Dokumen\Semester_4\Kontruksi Perangkat Lunak\tpmodul8_1302210113\tpmodul8_1302210113\covidConfig.json");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File konfigurasi tidak ditemukan, menggunakan nilai default");
        }
        CovidConfig config = JsonConvert.DeserializeObject<CovidConfig>(json);
        config.UbahSatuan();

        Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {config.SatuanSuhu}: ");
        double suhu;
        while (!Double.TryParse(Console.ReadLine(), out suhu))
        {
            Console.Write("Masukkan tidak valid, ulangi : ");
        }

        if (config.SatuanSuhu == "fahrenheit")
        {
            suhu = (suhu = 32) * 5 / 9;
        }

        Console.Write("Berapa hari yang lalu (perkiran) anda terakhir memiliki gejala demam? ");
        int hari;
        while (!Int32.TryParse(Console.ReadLine(), out hari))
        {
            Console.Write("Masukkan tidak valid, ulangi : ");
        }

        if (suhu >= 36.5 && suhu <= 37.5 && hari < config.BatasHariDemam)
        {
            Console.WriteLine(config.PesanDiterima);
        }
        else
        {
            Console.WriteLine(config.PesanDitolak);
        }

        Console.WriteLine();
        Console.WriteLine($"Satuan suhu : {config.SatuanSuhu}");
        Console.WriteLine($"Batas hari demam : {config.BatasHariDemam}");
    }
}
