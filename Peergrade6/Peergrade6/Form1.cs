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
    public partial class Notepad : Form
    {
        // Счетчик файлов.
        private int Count = 0;
        // Список созданных и открытых файлов.
        List<Information> Pages = new List<Information>();
        StreamReader MyStrReader;
        StreamWriter MyStrWriter;
        /// <summary>
        /// Создание формы.
        /// </summary>
        public Notepad()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Метод, вызывающий открытие файла.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open();
        }
        /// <summary>
        /// Метод, вызывающий создание файла.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewPage();
        }
        /// <summary>
        /// Метод, вызывающий сохранение файла.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }
        /// <summary>
        /// Метод, вызывающий закрытие приложения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Создание вкладки и рабочего пространства.
        /// </summary>
        private void CreateNewPage()
        {
            try
            {
                string name = $"File{++Count}";
                Information createNewFile = new Information(name, new RichTextBox(), new TabPage(name), Count - 1);
                // Создание объекта класса Information, для сбора информации об рабочей среде.
                createNewFile.TextBox.Dock = DockStyle.Fill;
                createNewFile.TextBox.ContextMenuStrip = ContextMenu;
                // Установка настроек для Rich Text Box.
                createNewFile.MyPage.Controls.Add(createNewFile.TextBox);
                WorkSpace.Controls.Add(createNewFile.MyPage);
                Pages.Add(createNewFile);
                GetColorOfForm();
                // Установка цветовой палитры для каждой из создаваемых форм.
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        /// <summary>
        /// Загрузка формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Notepad_Load(object sender, EventArgs e)
        {
            Menu.BackColor = Color.White;
            CreateNewPage();
            // Создание рабочей среды.
        }
        /// <summary>
        /// Метод для сохранения файла.
        /// </summary>
        private void Save()
        {
            try
            {
                SaveDialog.FileName = "";
                SaveDialog.Filter = "Text File(*.txt)|*.txt|Rich Text File(*.rtf)|*.rtf";
                // Фильтр форматов для исключения ошибок.
                if (SaveDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    Pages[WorkSpace.SelectedIndex].Path = SaveDialog.FileName;
                    // Обновление информации о файле.
                    MyStrWriter = new StreamWriter(Pages[WorkSpace.SelectedIndex].Path);
                    string format = SaveDialog.FileName.Substring(SaveDialog.FileName.Length - 3);
                    Pages[WorkSpace.SelectedIndex].MyPage.Text = GetNameOfFile(SaveDialog.FileName);
                    // Название созданного файла теперь выведено в названии вкладки.
                    if (format == "txt")
                    {
                        MyStrWriter.Write(Pages[WorkSpace.SelectedIndex].TextBox.Text);
                        // Запись файла формата txt.
                        MyStrWriter.Close();
                    }
                    else if (format == "rtf")
                    {
                        MyStrWriter.Write(Pages[WorkSpace.SelectedIndex].TextBox.Rtf);
                        // Запись файла формата rtf.
                        MyStrWriter.Close();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Не удалось сохранить файл!");
            }
        }
        /// <summary>
        /// Получение имени файла из его пути.
        /// </summary>
        /// <param name="pathOfFile">Путь файла.</param>
        /// <returns>Имя файла.</returns>
        private string GetNameOfFile(string pathOfFile)
        {
            int lastIndex = pathOfFile.LastIndexOf('\\') + 1;
            string nameOfFile = pathOfFile.Substring(pathOfFile.Length - (pathOfFile.Length - lastIndex));
            // Получение имени файла из его пути.
            return nameOfFile;
        }
        /// <summary>
        /// Метод проверки наличия открытого файла в приложении.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>True или False в зависимости от наличия.</returns>
        private bool GetPages(string fileName)
        {
            for (int i = 0; i < Pages.Count; i++)
            {
                if (fileName == Pages[i].MyPage.Text)
                // Проверка того, открыт файл в приложении или нет.
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Метод для открытия файла.
        /// </summary>
        public void Open()
        {
            try
            {
                OpenDialog.FileName = "";
                OpenDialog.Filter = "Text File(*.txt)|*.txt|Rich Text File(*.rtf)|*.rtf";
                // Фильтр открываемых файлов.
                if (OpenDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    MyStrReader = new StreamReader(OpenDialog.FileName);
                    if (GetPages(OpenDialog.SafeFileName))
                    // Проверка файла.
                    {
                        CreateNewPage();
                        Pages[Pages.Count - 1].Path = OpenDialog.FileName;
                        Pages[Pages.Count - 1].MyPage.Text = OpenDialog.SafeFileName;
                        string format = OpenDialog.FileName.Substring(OpenDialog.FileName.Length - 3);
                        // Получение формата файла для последующего выбора работы.
                        if (format == "txt")
                        {
                            Pages[Pages.Count - 1].TextBox.Text = MyStrReader.ReadToEnd();
                            // Запись текста в рабочую среду.
                            MyStrReader.Close();
                        }
                        else if (format == "rtf")
                        {
                            Pages[Pages.Count - 1].TextBox.Rtf = MyStrReader.ReadToEnd();
                            MyStrReader.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Файл уже открыт в приложении!");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Не удалось открыть файл!");
            }
        }
        /// <summary>
        /// Выделение всего текста.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectAllTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Pages[WorkSpace.SelectedIndex].TextBox.Text.Length > 0)
            {
                Pages[WorkSpace.SelectedIndex].TextBox.SelectAll();
            }
        }
        /// <summary>
        /// Удаление выделенного текста.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CutTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Pages[WorkSpace.SelectedIndex].TextBox.Text.Length > 0)
            {
                Pages[WorkSpace.SelectedIndex].TextBox.Cut();
            }
        }
        /// <summary>
        /// Копирование выделенного текста.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Pages[WorkSpace.SelectedIndex].TextBox.Text.Length > 0)
            {
                Pages[WorkSpace.SelectedIndex].TextBox.Copy();
            }
        }
        /// <summary>
        /// Вставка текста.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InsertTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pages[WorkSpace.SelectedIndex].TextBox.Paste();
        }
        /// <summary>
        /// Изменение формата текста.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog.ShowDialog();
            Pages[WorkSpace.SelectedIndex].TextBox.SelectionFont = FontDialog.Font;
            // Установка шрифта для выбранного текста.
        }
        /// <summary>
        /// Изменение цветового оформления приложения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorOfForm.ShowDialog();
            Menu.BackColor = ColorOfForm.Color;
            GetColorOfForm();
            // Установка цвета для меню и рабочей среды.
        }
        /// <summary>
        ///  Установка выбранного цвета.
        /// </summary>
        private void GetColorOfForm()
        {
            for (int i = 0; i < Pages.Count; i++)
            {
                Pages[i].MyPage.BackColor = Menu.BackColor;
                Pages[i].TextBox.BackColor = Menu.BackColor;
            }
        }
        /// <summary>
        /// Создание нового окна.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateInNewWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Notepad newNotepad = new Notepad();
            newNotepad.ShowDialog();
            // Создание новой формы.
        }
        /// <summary>
        /// Сохранение всех файлов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAllFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAll();
        }
        /// <summary>
        /// Метод для сохранения файлов.
        /// </summary>
        private void SaveAll()
        {
            try
            {
                for (int i = 0; i < Pages.Count; i++)
                {
                    string path = Pages[i].Path.Substring(Pages[i].Path.Length - 3);
                    if (path != "txt" && path != "rtf")
                    // Проверка на то, создан файл уже или нет.
                    {
                        SaveDialog.FileName = "";
                        SaveDialog.Filter = "Text File(*.txt)|*.txt|Rich Text File(*.rtf)|*.rtf";
                        if (SaveDialog.ShowDialog() == DialogResult.Cancel)
                        {
                            return;
                        }
                        else
                        {
                            Pages[i].Path = SaveDialog.FileName;
                            // Получение пути файла.
                            MyStrWriter = new StreamWriter(Pages[i].Path);
                            string pathForSave = SaveDialog.FileName.Substring(SaveDialog.FileName.Length - 3);
                            Pages[i].MyPage.Text = GetNameOfFile(SaveDialog.FileName);
                            if (pathForSave == "txt")
                            {
                                MyStrWriter.Write(Pages[i].TextBox.Text);
                                MyStrWriter.Close();
                            }
                            else if (pathForSave == "rtf")
                            {
                                MyStrWriter.Write(Pages[i].TextBox.Rtf);
                                MyStrWriter.Close();
                            }
                        }
                    }
                    else
                    {
                        if (GetChanges(Pages[i]))
                        // Проверка на наличие изменений.
                        {
                            MyStrWriter = new StreamWriter(Pages[i].Path);
                            string formatOfFile = Pages[i].Path.Substring(Pages[i].Path.Length - 3);
                            Pages[i].MyPage.Text = GetNameOfFile(Pages[i].Path);
                            if (formatOfFile == "txt")
                            {
                                MyStrWriter.Write(Pages[i].TextBox.Text);
                                // Перезапись содержимого файла.
                                MyStrWriter.Close();
                            }
                            else if (formatOfFile == "rtf")
                            {
                                MyStrWriter.Write(Pages[i].TextBox.Rtf);
                                MyStrWriter.Close();
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Не удалось сохранить файл!");
            }
        }
        /// <summary>
        /// Получение инфомации изменен ли текст файла или нет.
        /// </summary>
        /// <param name="information"></param>
        /// <returns>True или False в зависимости от наличия изменений.</returns>
        private bool GetChanges(Information information)
        {
            try
            {
                MyStrReader = new StreamReader(information.Path);
                string text = MyStrReader.ReadToEnd();
                MyStrReader.Close();
                string format = information.Path.Substring(information.Path.Length - 3);
                if (format == "txt")
                {
                    if (information.TextBox.Text == text)
                    // Проверка на изменении в тексте файла.
                    {
                        return false;
                    }
                }
                else
                {
                    if (information.TextBox.Rtf == text)
                    {
                        return false;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Не удалось проверить содержимое файла!");
            }
            return true;
        }
        private void InformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("                                        ПРИВЕТ!" + Environment.NewLine + "Эта информация поможет тебе в работе с приложением."
                + Environment.NewLine + "1) В пунктах Открытия и Сохранения файлов, есть фильтр на два формата *rtf и *txt. Поэтому, когда будешь сохранять файл внимательно следи какой файл сохраняешь" +
                ",потому что если были внесены изменения в формат текста, а сохранил ты в *txt, то форматирование не сохраниться. Будь внимателен!" + Environment.NewLine
                + "2)При сохранении всех файлов сразу, файлы созданные в приложении будут вызывать окно Сохранения." + Environment.NewLine +
                "3)Если ты внес изменения в форматирование текста существующего файла и хотел бы изменить формат файла советую пользоваться пунктом Сохранить, потому что он позволяет изменить формат." +
                "При сохранении всех файлов сразу изменение формата существующего файла невозможно." + Environment.NewLine +
                "4)Открытие файла, который уже открыт в приложении невозможно."
                , "Справка:");
        }
    }
}
