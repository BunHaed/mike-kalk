using System.IO;
using System;
using System.Numerics;
using System.Text;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    static void HistoryClear()
    {
        File.WriteAllText("D:\\Projects\\mike-kalk\\MyFile.txt", string.Empty);
        Console.WriteLine("History cleared");
    }

    


    static void HistoryShow()
    {
        string TextFromFile = File.ReadAllText(@"D:\Projects\mike-kalk\MyFile.txt", Encoding.UTF8);
        Console.WriteLine("your history");
        Console.WriteLine(TextFromFile);
    }



    private static void Main(string[] args)
    {
        float a;
        string nums;
        string filePath = "D:\\Projects\\mike-kalk\\MyFile.txt"; // path, where file will be created


        Console.Clear();
        Console.WriteLine("Vítejte v kalkulačce");
        Console.WriteLine(" ");
        Console.WriteLine("Spustit kalkulačku         [1]");
        Console.WriteLine("Smaž historii              [2]");
        Console.WriteLine("Vypiš historii             [3]");
        Console.WriteLine("Ukočit kalkulačku          [4]");
        Console.WriteLine("Zvolte akci: ");


        char odpoved = char.ToLower(Console.ReadKey().KeyChar);
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
                    if (b == "konec" || b == "Konec")
                    {
                        Console.WriteLine("Konec programu");
                        pokracovat = false;
                        return;
                    }



                    else if (b != "+" && b != "-" && b != "*" && b != "/")
                    {
                        Console.WriteLine("Invalid operator, try again please (+,-,*,/)");
                        continue;
                    }





                    Console.WriteLine("Zadejte číslo:");
                    float c;
                    while (!float.TryParse(Console.ReadLine(), out c))
                        Console.WriteLine("Neplatné číslo, zadejte prosím znovu:");

                    File.AppendAllText("D:\\Projects\\mike-kalk\\MyFile.txt", Convert.ToString(a));

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
                        // open the file with append mode, so it doesn't delete old text
                        using (FileStream fs = new FileStream(filePath, FileMode.Append))
                        {
                            // add some text to the end of the file and end 
                            //byte[] text = new System.Text.UTF8Encoding(true).GetBytes("TEST\n");
                            //fs.Write(text, 0, text.Length);
                            fs.Close();
                            File.AppendAllText("D:\\Projects\\mike-kalk\\MyFile.txt", b);
                            fs.Close();
                            File.AppendAllText("D:\\Projects\\mike-kalk\\MyFile.txt", Convert.ToString(c));
                            File.AppendAllText("D:\\Projects\\mike-kalk\\MyFile.txt", "=");
                            File.AppendAllText("D:\\Projects\\mike-kalk\\MyFile.txt", Convert.ToString(a));
                            File.AppendAllText("D:\\Projects\\mike-kalk\\MyFile.txt", "\n");
                        }

                        //Console.WriteLine("File updated successfully!");  -   only for testing purpose
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                    Console.WriteLine("Pokračovat v kalkulaci?(y/n)");
                    string YorN = Console.ReadLine();
                    if (YorN == "y" || YorN == "YES" || YorN == "Yes" || YorN == "yes" || YorN == "Y")
                    {
                        ;
                        Console.WriteLine("History cleared");
                        
                    }
                }
                break;
                //nikdy
                //lol
            case '2':
            case 'ě':
                Console.Clear();
                Console.WriteLine("History Cleared");
                Console.WriteLine("---------------------------------------------------------------------------------------------");
                HistoryClear();
                break;

            case '3':
            case 'š':
                Console.Clear();
                Console.WriteLine("Your history");
                Console.WriteLine("---------------------------------------------------------------------------------------------");
                HistoryShow();
                break;

            case '4':
            case 'č':
                Console.Clear();
                Console.WriteLine("\nTak díky, žes mě vypnul :))))))) kriple");
                System.Threading.Thread.Sleep(5000);
                Environment.Exit(0);
                break;
        {

                    Console.WriteLine("Mike");





                }
        }
    }
}