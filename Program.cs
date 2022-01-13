using System.Net;

namespace UsernameChecker
{
    class TikTok
    {
        public enum HttpStatusCode
        {
            Moved = 301,
            OK = 200,
        }
        // shared randomization thingy
        public static Random random = new Random();

        public static void Check()
        {
            if (File.Exists("./usernames/tiktok.txt")) { }
            else
            {
                File.Create("./usernames/tiktok.txt");
            }
            if (File.Exists("./usernames/tiktok_hits.txt")) { }
            else
            {
                File.Create("./usernames/tiktok_hits.txt");
            }
            Console.Title = "TikTok Username Checker | Made By dtz#1234 | github.com/ofDataa";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   Welcome To Tiktok Name Generator & Checker!");
            Console.WriteLine("   Made by dtz#1234!");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Reading File ./usernames/tiktok.txt");
            string fileName = "./usernames/tiktok.txt";
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    try
                    {
                        HttpWebRequest webRequest = (HttpWebRequest)WebRequest
                                           .Create("https://www.tiktok.com/@" + s);
                        webRequest.AllowAutoRedirect = false;
                        HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                        string status = response.StatusCode.ToString();
                        
                        if (status == "OK")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("   [UNAVAILABLE] ");
                            Console.Write("https://www.tiktok.com/@" + s + "\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("   [AVAILABLE OR BANNED] ");
                            Console.Write("https://www.tiktok.com/@" + s + "\n");
                            string text = s;
                            Console.ForegroundColor = ConsoleColor.White;
                            using (StreamWriter writer = new StreamWriter("tiktok_hits.txt", true)) //// true to append data to the file
                            {
                                writer.WriteLine(s);
                            }

                        }
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("   [AVAILABLE OR BANNED] ");
                        Console.Write("https://www.tiktok.com/@" + s + "\n");
                        string text = s;
                        Console.ForegroundColor = ConsoleColor.White;
                        File.WriteAllText("./usernames/tiktok_hits.txt", text);
                        using (StreamWriter writer = new StreamWriter("tiktok_hits.txt", true)) //// true to append data to the file
                        {
                            writer.WriteLine(s);
                        }
                    }
                }
            }
           
        }
    }
}
