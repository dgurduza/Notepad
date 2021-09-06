using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Peergrade6
{
    class Information
    {
        public string Path{ get; set; }
        public RichTextBox TextBox { get; set; }
        public TabPage MyPage { get; set; }
        public int Num { get; set; }
        /// <summary>
        /// Конструктор для сбора информации.
        /// </summary>
        /// <param name="_name">Путь</param>
        /// <param name="_textBox">Рабочая среда</param>
        /// <param name="_page">Вкладка</param>
        /// <param name="_num">Номер</param>
        public Information(string _name,RichTextBox _textBox,TabPage _page,int _num) 
        {
            Path = _name;
            TextBox = _textBox;
            TextBox.Name = _num.ToString();
            MyPage = _page;
            Num = _num;
        }
    }
}
