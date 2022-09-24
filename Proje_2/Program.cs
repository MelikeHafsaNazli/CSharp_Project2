using System.Collections.Generic;
using ToDo;

class Program
{
    public static void main()
    {
        int islem = 0;
        while (islem != -1)
        {
            IslemMenu();
            bool islemAlindi = int.TryParse(Console.ReadLine(), out islem);
            if (islemAlindi)
            {
                switch (islem)
                {
                    case 1:
                        Board.Listele();
                        break;
                    case 2:
                        Board.Ekle();
                        break;
                    case 3:
                        Board.Sil();
                        break;
                    case 4:
                        Board.Tasi();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Lütfen verilen seçeneklerden bir sayı değeri giriniz.");
            }
        }
    }

    void IslemMenu()
    {
        Console.WriteLine(
            "Lütfen yapmak istediğiniz işlemi seçiniz :) \n*******************************************\n(1) Board Listelemek\n(2) Board'a Kart Eklemek\n(3) Board'dan Kart Silmek\n(4) Kart Taşımak"
        );
    }
}
