
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
    partial class Notepad
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            DialogResult boxResult = MessageBox.Show("Хотите выйти, не сохранив изменения?", "Выход из приложения:", MessageBoxButtons.YesNoCancel);
            if (boxResult == DialogResult.Yes)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
            else if (boxResult == DialogResult.No)
            {
                SaveAll();
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }

        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.File = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.Separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CreateFile = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateInNewWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.Separator2 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAllFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.Separator3 = new System.Windows.Forms.ToolStripSeparator();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.CutText = new System.Windows.Forms.ToolStripMenuItem();
            this.Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.InsertText = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectAllText = new System.Windows.Forms.ToolStripMenuItem();
            this.Format = new System.Windows.Forms.ToolStripMenuItem();
            this.Customization = new System.Windows.Forms.ToolStripMenuItem();
            this.InfoAboutNotepad = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.OpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.WorkSpace = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.FontDialog = new System.Windows.Forms.FontDialog();
            this.ColorOfForm = new System.Windows.Forms.ColorDialog();
            this.ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextCut = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextFormat = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu.SuspendLayout();
            this.ContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File,
            this.Edit,
            this.Format,
            this.Customization,
            this.InfoAboutNotepad});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(749, 33);
            this.Menu.TabIndex = 0;
            this.Menu.Text = "Menu";
            // 
            // File
            // 
            this.File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFile,
            this.Separator1,
            this.CreateFile,
            this.CreateInNewWindow,
            this.Separator2,
            this.SaveFile,
            this.SaveAllFiles,
            this.Separator3,
            this.Exit});
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(54, 29);
            this.File.Text = "&File";
            // 
            // OpenFile
            // 
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenFile.Size = new System.Drawing.Size(417, 34);
            this.OpenFile.Text = "Open";
            this.OpenFile.Click += new System.EventHandler(this.OpenFileToolStripMenuItem_Click);
            // 
            // Separator1
            // 
            this.Separator1.Name = "Separator1";
            this.Separator1.Size = new System.Drawing.Size(414, 6);
            // 
            // CreateFile
            // 
            this.CreateFile.Name = "CreateFile";
            this.CreateFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.CreateFile.Size = new System.Drawing.Size(417, 34);
            this.CreateFile.Text = "Create";
            this.CreateFile.Click += new System.EventHandler(this.CreateFileToolStripMenuItem_Click);
            // 
            // CreateInNewWindow
            // 
            this.CreateInNewWindow.Name = "CreateInNewWindow";
            this.CreateInNewWindow.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.CreateInNewWindow.Size = new System.Drawing.Size(417, 34);
            this.CreateInNewWindow.Text = "Сreate In New Window";
            this.CreateInNewWindow.Click += new System.EventHandler(this.CreateInNewWindowToolStripMenuItem_Click);
            // 
            // Separator2
            // 
            this.Separator2.Name = "Separator2";
            this.Separator2.Size = new System.Drawing.Size(414, 6);
            // 
            // SaveFile
            // 
            this.SaveFile.Name = "SaveFile";
            this.SaveFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveFile.Size = new System.Drawing.Size(417, 34);
            this.SaveFile.Text = "Save";
            this.SaveFile.Click += new System.EventHandler(this.SaveFileToolStripMenuItem_Click);
            // 
            // SaveAllFiles
            // 
            this.SaveAllFiles.Name = "SaveAllFiles";
            this.SaveAllFiles.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.SaveAllFiles.Size = new System.Drawing.Size(417, 34);
            this.SaveAllFiles.Text = "Save all";
            this.SaveAllFiles.Click += new System.EventHandler(this.SaveAllFilesToolStripMenuItem_Click);
            // 
            // Separator3
            // 
            this.Separator3.Name = "Separator3";
            this.Separator3.Size = new System.Drawing.Size(414, 6);
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            this.Exit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.Exit.Size = new System.Drawing.Size(417, 34);
            this.Exit.Text = "Exit";
            this.Exit.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // Edit
            // 
            this.Edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CutText,
            this.Copy,
            this.InsertText,
            this.SelectAllText});
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(58, 29);
            this.Edit.Text = "&Edit";
            // 
            // CutText
            // 
            this.CutText.Name = "CutText";
            this.CutText.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.CutText.Size = new System.Drawing.Size(245, 34);
            this.CutText.Text = "Cut";
            this.CutText.Click += new System.EventHandler(this.CutTextToolStripMenuItem_Click);
            // 
            // Copy
            // 
            this.Copy.Name = "Copy";
            this.Copy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.Copy.Size = new System.Drawing.Size(245, 34);
            this.Copy.Text = "Copy";
            this.Copy.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // InsertText
            // 
            this.InsertText.Name = "InsertText";
            this.InsertText.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.InsertText.Size = new System.Drawing.Size(245, 34);
            this.InsertText.Text = "Paste";
            this.InsertText.Click += new System.EventHandler(this.InsertTextToolStripMenuItem_Click);
            // 
            // SelectAllText
            // 
            this.SelectAllText.Name = "SelectAllText";
            this.SelectAllText.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.SelectAllText.Size = new System.Drawing.Size(245, 34);
            this.SelectAllText.Text = "Select all";
            this.SelectAllText.Click += new System.EventHandler(this.SelectAllTextToolStripMenuItem_Click);
            // 
            // Format
            // 
            this.Format.Name = "Format";
            this.Format.Size = new System.Drawing.Size(85, 29);
            this.Format.Text = "&Format";
            this.Format.Click += new System.EventHandler(this.FormatToolStripMenuItem_Click);
            // 
            // Customization
            // 
            this.Customization.Name = "Customization";
            this.Customization.Size = new System.Drawing.Size(142, 29);
            this.Customization.Text = "&Customization";
            this.Customization.Click += new System.EventHandler(this.CustomizationToolStripMenuItem_Click);
            // 
            // InfoAboutNotepad
            // 
            this.InfoAboutNotepad.Name = "InfoAboutNotepad";
            this.InfoAboutNotepad.Size = new System.Drawing.Size(122, 29);
            this.InfoAboutNotepad.Text = "&Information";
            this.InfoAboutNotepad.Click += new System.EventHandler(this.InformationToolStripMenuItem_Click);
            // 
            // OpenDialog
            // 
            this.OpenDialog.FileName = "MyFile";
            // 
            // WorkSpace
            // 
            this.WorkSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkSpace.Location = new System.Drawing.Point(0, 33);
            this.WorkSpace.Name = "WorkSpace";
            this.WorkSpace.SelectedIndex = 0;
            this.WorkSpace.Size = new System.Drawing.Size(749, 422);
            this.WorkSpace.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(741, 417);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Example";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(100, 200);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            // 
            // ContextMenu
            // 
            this.ContextMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextCut,
            this.ContextCopy,
            this.ContextPaste,
            this.ContextSelectAll,
            this.ContextSeparator1,
            this.ContextFormat});
            this.ContextMenu.Name = "ContextMenu";
            this.ContextMenu.Size = new System.Drawing.Size(156, 170);
            // 
            // ContextCut
            // 
            this.ContextCut.Name = "ContextCut";
            this.ContextCut.Size = new System.Drawing.Size(155, 32);
            this.ContextCut.Text = "Cut";
            this.ContextCut.Click += new System.EventHandler(this.CutTextToolStripMenuItem_Click);
            // 
            // ContextCopy
            // 
            this.ContextCopy.Name = "ContextCopy";
            this.ContextCopy.Size = new System.Drawing.Size(155, 32);
            this.ContextCopy.Text = "Copy";
            this.ContextCopy.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // ContextPaste
            // 
            this.ContextPaste.Name = "ContextPaste";
            this.ContextPaste.Size = new System.Drawing.Size(155, 32);
            this.ContextPaste.Text = "Paste";
            this.ContextPaste.Click += new System.EventHandler(this.InsertTextToolStripMenuItem_Click);
            // 
            // ContextSelectAll
            // 
            this.ContextSelectAll.Name = "ContextSelectAll";
            this.ContextSelectAll.Size = new System.Drawing.Size(155, 32);
            this.ContextSelectAll.Text = "Select All";
            this.ContextSelectAll.Click += new System.EventHandler(this.SelectAllTextToolStripMenuItem_Click);
            // 
            // ContextSeparator1
            // 
            this.ContextSeparator1.Name = "ContextSeparator1";
            this.ContextSeparator1.Size = new System.Drawing.Size(152, 6);
            // 
            // ContextFormat
            // 
            this.ContextFormat.Name = "ContextFormat";
            this.ContextFormat.Size = new System.Drawing.Size(155, 32);
            this.ContextFormat.Text = "Format";
            this.ContextFormat.Click += new System.EventHandler(this.FormatToolStripMenuItem_Click);
            // 
            // Notepad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 455);
            this.Controls.Add(this.WorkSpace);
            this.Controls.Add(this.Menu);
            this.MainMenuStrip = this.Menu;
            this.Name = "Notepad";
            this.Text = "Notepad+";
            this.Load += new System.EventHandler(this.Notepad_Load);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem File;
        private System.Windows.Forms.ToolStripMenuItem OpenFile;
        private System.Windows.Forms.ToolStripMenuItem CreateFile;
        private System.Windows.Forms.ToolStripMenuItem SaveFile;
        private System.Windows.Forms.ToolStripMenuItem SaveAllFiles;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.ToolStripMenuItem Edit;
        private System.Windows.Forms.ToolStripMenuItem SelectAllText;
        private System.Windows.Forms.ToolStripMenuItem Copy;
        private System.Windows.Forms.ToolStripMenuItem CutText;
        private System.Windows.Forms.ToolStripMenuItem InsertText;
        private System.Windows.Forms.ToolStripMenuItem Format;
        private System.Windows.Forms.ToolStripMenuItem Customization;
        private System.Windows.Forms.SaveFileDialog SaveDialog;
        private System.Windows.Forms.OpenFileDialog OpenDialog;
        private System.Windows.Forms.TabControl WorkSpace;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FontDialog FontDialog;
        private System.Windows.Forms.ColorDialog ColorOfForm;
        private System.Windows.Forms.ContextMenuStrip ContextMenu;
        private System.Windows.Forms.ToolStripMenuItem ContextCut;
        private System.Windows.Forms.ToolStripMenuItem ContextCopy;
        private System.Windows.Forms.ToolStripMenuItem ContextPaste;
        private System.Windows.Forms.ToolStripMenuItem ContextSelectAll;
        private System.Windows.Forms.ToolStripMenuItem ContextFormat;
        private System.Windows.Forms.ToolStripSeparator Separator1;
        private System.Windows.Forms.ToolStripSeparator Separator2;
        private System.Windows.Forms.ToolStripMenuItem CreateInNewWindow;
        private System.Windows.Forms.ToolStripSeparator Separator3;
        private System.Windows.Forms.ToolStripSeparator ContextSeparator1;
        private System.Windows.Forms.ToolStripMenuItem InfoAboutNotepad;
    }
}

