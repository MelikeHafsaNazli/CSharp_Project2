namespace ToDo
{
    public static class Board
    {
        private static List<Card> ToDo;
        private static List<Card> InProgress;
        private static List<Card> Done;
        private static Dictionary<int, string> boardMembers = new Dictionary<int, string>()
        {
            { 124124, "Hakan" },
            { 345345, "Yeşim" },
            { 574574, "Polat" }
        };

        static Board()
        {
            ToDo = new List<Card>();
            InProgress = new List<Card>();
            Done = new List<Card>();
        }

        public static void Listele()
        {
            Console.WriteLine("TODO Line\n ************************");
            if (ToDo.Count == 0)
            {
                Console.WriteLine("~BOŞ~");
            }
            else
            {
                foreach (Card c in ToDo)
                {
                    Console.WriteLine(
                        $"Başlık      :{c.baslik}\nİçerik      :{c.icerik}\nAtanan Kişi :{c.atananKisi}\nBüyüklük    :{c.buyukluk}\n"
                    );
                    if (ToDo.IndexOf(c) != ToDo.Count - 1)
                        Console.WriteLine("-");
                }
            }

            Console.WriteLine("IN PROGRESS Line\n ************************");
            if (InProgress.Count == 0)
            {
                Console.WriteLine("~BOŞ~");
            }
            else
            {
                foreach (Card c in InProgress)
                {
                    Console.WriteLine(
                        $"Başlık      :{c.baslik}\nİçerik      :{c.icerik}\nAtanan Kişi :{c.atananKisi}\nBüyüklük    :{c.buyukluk}\n"
                    );
                    if (ToDo.IndexOf(c) != ToDo.Count - 1)
                        Console.WriteLine("-");
                }
            }

            Console.WriteLine("DONE Line\n ************************");
            if (Done.Count == 0)
            {
                Console.WriteLine("~BOŞ~");
            }
            else
            {
                foreach (Card c in Done)
                {
                    Console.WriteLine(
                        $"Başlık      :{c.baslik}\nİçerik      :{c.icerik}\nAtanan Kişi :{c.atananKisi}\nBüyüklük    :{c.buyukluk}\n"
                    );
                    if (ToDo.IndexOf(c) != ToDo.Count - 1)
                        Console.WriteLine("-");
                }
            }
        }

        public static void Ekle()
        {
            Console.WriteLine("Başlık Giriniz                                  : ");
            string? baslik = Console.ReadLine();
            Console.WriteLine("İçerik Giriniz                                  :");
            string? icerik = Console.ReadLine();
            Console.WriteLine("Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5)  :");
            size buyukluk = (size)Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Kişi Seçiniz                                    :");
            int atananKisi = Convert.ToInt32(Console.ReadLine());
            if (!boardMembers.ContainsKey(atananKisi) || baslik == null || icerik == null)
            {
                Console.WriteLine("Hatalı girişler yaptınız!");
                return;
            }
            ToDo.Add(new Card(baslik, icerik, buyukluk, boardMembers[atananKisi]));
        }

        public static void Sil()
        {
            Console.WriteLine(
                "Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.\nLütfen kart başlığını yazınız:"
            );
            string? baslik = Console.ReadLine();
            if (baslik == null)
            {
                Console.WriteLine("Hatalı girişler yaptınız!");
                return;
            }
            else if (ToDo.Find(c => c.baslik == baslik) != null)
            {
                ToDo.Remove(ToDo.Find(c => c.baslik == baslik));
            }
            else if (InProgress.Find(c => c.baslik == baslik) != null)
            {
                InProgress.Remove(InProgress.Find(c => c.baslik == baslik));
            }
            else if (Done.Find(c => c.baslik == baslik) != null)
            {
                Done.Remove(Done.Find(c => c.baslik == baslik));
            }
            else
            {
                Console.WriteLine(
                    "Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.\n* Silmeyi sonlandırmak için : (1)\n* Yeniden denemek için : (2)"
                );
                int option;
                if (int.TryParse(Console.ReadLine(), out option))
                {
                    if (option == 1)
                    {
                        return;
                    }
                    else if (option == 2)
                    {
                        Sil();
                    }
                }
            }
        }

        public static void Tasi()
        {
            Console.WriteLine(
                "Öncelikle taşımak istediğiniz kartı seçmeniz gerekiyor.\nLütfen kart başlığını yazınız:"
            );
            string? baslik = Console.ReadLine();
            Card c;
            string line = "";
            if (baslik == null)
            {
                Console.WriteLine("Hatalı girişler yaptınız!");
                return;
            }
            else if (ToDo.Find(c => c.baslik == baslik) != null)
            {
                c = ToDo.Find(c => c.baslik == baslik);
                ToDo.Remove(ToDo.Find(c => c.baslik == baslik));
                line = "ToDo";
            }
            else if (InProgress.Find(c => c.baslik == baslik) != null)
            {
                c = InProgress.Find(c => c.baslik == baslik);
                InProgress.Remove(InProgress.Find(c => c.baslik == baslik));
                line = "InProgress";
            }
            else if (Done.Find(c => c.baslik == baslik) != null)
            {
                c = Done.Find(c => c.baslik == baslik);
                Done.Remove(Done.Find(c => c.baslik == baslik));
                line = "Done";
            }
            else
            {
                Console.WriteLine(
                    "Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.\n* İşlemi sonlandırmak için : (1)\n* Yeniden denemek için : (2)"
                );
                int option2;
                if (int.TryParse(Console.ReadLine(), out option2))
                {
                    if (option2 == 1)
                    {
                        return;
                    }
                    else if (option2 == 2)
                    {
                        Tasi();
                    }
                }
                return;
            }
            Console.WriteLine($"Bulunan Kart Bilgileri:\n**************************************\n");
            Console.WriteLine(
                $"Başlık      :{c.baslik}\nİçerik      :{c.icerik}\nAtanan Kişi :{c.atananKisi}\nBüyüklük    :{c.buyukluk}\nLine        :{line}\n"
            );
            Console.WriteLine(
                "Lütfen taşımak istediğiniz Line'ı seçiniz: \n(1) TODO\n(2) IN PROGRESS\n(3) DONE"
            );
            int option;
            if (int.TryParse(Console.ReadLine(), out option))
            {
                if (option == 1)
                {
                    ToDo.Add(c);
                }
                else if (option == 2)
                {
                    InProgress.Add(c);
                }
                else if (option == 3)
                {
                    Done.Add(c);
                }
                else
                {
                    Console.WriteLine("Hatalı bir seçim yaptınız!");
                    switch (line)
                    {
                        case "ToDo":
                            ToDo.Add(c);
                            break;
                        case "InProgress":
                            InProgress.Add(c);
                            break;
                        case "Done":
                            Done.Add(c);
                            break;
                    }
                }
            }
        }
    }
}
