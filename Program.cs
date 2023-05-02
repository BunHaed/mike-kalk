using System.IO;
using System;
using System.Numerics;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Data;

internal class Program
{

    //Smaže historii kalkulací ze složky
    static void HistoryClear()
    {
        File.WriteAllText("D:\\Projects\\mike-kalk\\MyFile.txt", string.Empty);
    }

    

    //Zobrazí historii kalkulací ze složky
    static void HistoryShow()
    {
        string TextFromFile = File.ReadAllText(@"D:\Projects\mike-kalk\MyFile.txt", Encoding.UTF8);
        Console.WriteLine(TextFromFile);
    }



    private static void Main(string[] args)
    {
        float a;
        string nums;
        string filePath = "D:\\Projects\\mike-kalk\\MyFile.txt"; // path, where file will be created





    while (true)
        {
            
            //menu konzole
            Console.Clear();
            Console.WriteLine("Vítejte v kalkulačce");
            Console.WriteLine(" ");
            Console.WriteLine("Spustit kalkulačku         [1]");
            Console.WriteLine("Smaž historii              [2]");
            Console.WriteLine("Vypiš historii             [3]");
            Console.WriteLine("Ukočit kalkulačku          [4]");
            Console.WriteLine("Zvolte akci: ");


            char odpoved = char.ToLower(Console.ReadKey().KeyChar); //ošetření vstupu od uživatele
        switch (odpoved)
        {
            case '1':
            case '+':
                Console.Clear();
                Console.WriteLine("KALKULACE");
                Console.WriteLine("---------------------------------------------------------------------------------------------");
                Console.WriteLine("Zadejte číslo:");
                while (!float.TryParse(Console.ReadLine(), out a))
                    Console.WriteLine("Neplatné číslo, zadejte prosím znovu:");
                bool pokracovat = true;
                while (pokracovat)
                { 
                    Console.WriteLine("Zadejte operátor:");
                    string b = Console.ReadLine();

                    if (b != "+" && b != "-" && b != "*" && b != "/")
                    {
                        Console.WriteLine("Invalid operator, try again please (+,-,*,/)");
                        continue;
                    }





                    Console.WriteLine("Zadejte číslo:");
                    float c;
                    while (!float.TryParse(Console.ReadLine(), out c))
                        Console.WriteLine("Neplatné číslo, zadejte prosím znovu:");
                    if (b == "/" && c == 0)
                        {
                            Console.WriteLine("Invalid calulation");
                            Console.ReadLine();
                            break;
                        }

                    File.AppendAllText("D:\\Projects\\mike-kalk\\MyFile.txt", Convert.ToString(a)); //otevře složku(nebo vytvoří, pokud není) a vloží do ní proměnnou a

                    if (b == "+")
                    {
                        a = a + c;
                        Console.WriteLine("Výsledek je: {0}", a);
                    }
                    else if (b == "-")
                    {
                        a = a - c;
                        Console.WriteLine("Výsledek je: {0}", a);
                    }
                    else if (b == "")
                    {
                        a = a * c;
                        Console.WriteLine("Výsledek je: {0}", a);
                    }
                    else if (b == "/")
                    {
                        a = a / c;
                        Console.WriteLine("Výsledek je: {0}", a);
                    }



                    try
                    {
                        // otevře složku pro úpravy bez smazání starých dat
                        using (FileStream fs = new FileStream(filePath, FileMode.Append))
                        {
                            fs.Close();
                            File.AppendAllText("D:\\Projects\\mike-kalk\\MyFile.txt", b);
                            fs.Close();
                            File.AppendAllText("D:\\Projects\\mike-kalk\\MyFile.txt", Convert.ToString(c));
                            File.AppendAllText("D:\\Projects\\mike-kalk\\MyFile.txt", "=");
                            File.AppendAllText("D:\\Projects\\mike-kalk\\MyFile.txt", Convert.ToString(a));
                            File.AppendAllText("D:\\Projects\\mike-kalk\\MyFile.txt", "\n");
                        }

                        //Console.WriteLine("File updated successfully!");  -   pouze pro test
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                    Console.WriteLine("Pokračovat v kalkulaci?(y/n)");
                    string YorN = Console.ReadLine();
                    if (YorN == "y" || YorN == "YES" || YorN == "Yes" || YorN == "yes" || YorN == "Y")
                    {
                        continue;
                    }

                    else
                        break;    
                    }
                break;

                
                
            case '2':
            case 'ě':
                Console.Clear();
                Console.WriteLine("History Cleared");
                Console.WriteLine("---------------------------------------------------------------------------------------------");
                HistoryClear();
                Console.ReadLine();
                break;

            case '3':
            case 'š':
                Console.Clear();
                Console.WriteLine("Your history");
                Console.WriteLine("---------------------------------------------------------------------------------------------");
                HistoryShow();
                Console.ReadLine();
                break;

            case '4':
            case 'č':
                Console.Clear();
                Console.WriteLine("\nTak díky, žes mě vypnul :))))))) kriple");
                Console.ReadLine();
                Environment.Exit(0);
                break;
        {

                    }

            }
        }
    }
}