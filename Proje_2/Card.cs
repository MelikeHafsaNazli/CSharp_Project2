using (System) { }

namespace ToDo
{
    public enum size
    {
        XS = 1,
        S,
        M,
        L,
        XL
    };

    public class Card
    {
        public string baslik;
        public string icerik;
        public string atananKisi;
        public size buyukluk;

        public Card(string baslik, string icerik, size buyukluk, string atananKisi)
        {
            this.baslik = baslik;
            this.icerik = icerik;
            this.buyukluk = buyukluk;
            this.atananKisi = atananKisi;
        }
    }
}
