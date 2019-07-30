using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{

    public class ProvinceInfo
    {
        private int iD;
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string simple;
        public string Simple
        {
            get { return simple; }
            set { simple = value; }
        }

        private string pinyin;
        public string Pinyin
        {
            get { return pinyin; }
            set { pinyin = value; }
        }
    }
}
