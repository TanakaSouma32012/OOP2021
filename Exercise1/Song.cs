using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1 {
    class Song {
        public string Title { get; set; }     //曲のタイトル
        public string ArtistName { get; set; }  //アーティストの名前
        public int Length { get; set; }         //演奏時間、単位は秒

        public Song(string title, string artistNmae, int length) {
            Title = Title;
            ArtistName = artistNmae;
            Length = length;
        }
    }
}

