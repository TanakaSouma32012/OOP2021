using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1 {
    class Program {
        static void Main(string[] args) {
            var songs0 = new Song[] {
                new Song("","",0)
            };
            PrintSongs(songs0);
        }
        private static void PrintSongs(Song[] songs) {
            foreach (var song in songs) {
                Console.WriteLine("{0},{1},{2:m\\:ss}",song.Title,song.ArtistName,TimeSpan.FromSeconds( song.Length));
            }
        }
    }
}
