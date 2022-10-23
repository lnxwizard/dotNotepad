using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace dotNotePad
{
    public partial class MainForm : Form
    {
        string path;

        // Main
        public MainForm()
        {
            InitializeComponent();

            RegistryKey key = Registry.CurrentUser;
            key = key.OpenSubKey(Application.ProductName);
            if (key == null)
            {
                return;
            }

            richTextBox1.Text = Convert.ToString(key.GetValue("R"));

            // Language Registry
            // File
            fileToolStripMenuItem.Text = Convert.ToString(key.GetValue("fileToolStripMenuItem"));
            newToolStripMenuItem.Text = Convert.ToString(key.GetValue("newToolStripMenuItem"));
            newWindowToolStripMenuItem.Text = Convert.ToString(key.GetValue("newWindowToolStripMenuItem"));
            openToolStripMenuItem.Text = Convert.ToString(key.GetValue("openToolStripMenuItem"));
            saveToolStripMenuItem.Text = Convert.ToString(key.GetValue("saveToolStripMenuItem"));
            saveAsToolStripMenuItem.Text = Convert.ToString(key.GetValue("saveAsToolStripMenuItem"));
            printToolStripMenuItem.Text = Convert.ToString(key.GetValue("printToolStripMenuItem"));
            pageSetupToolStripMenuItem.Text = Convert.ToString(key.GetValue("pageSetupToolStripMenuItem"));
            exitToolStripMenuItem.Text = Convert.ToString(key.GetValue("exitToolStripMenuItem"));

            // Edit
            editToolStripMenuItem.Text = Convert.ToString(key.GetValue("editToolStripMenuItem"));
            undoToolStripMenuItem.Text = Convert.ToString(key.GetValue("undoToolStripMenuItem"));
            redoToolStripMenuItem.Text = Convert.ToString(key.GetValue("redoToolStripMenuItem"));
            cutToolStripMenuItem.Text = Convert.ToString(key.GetValue("cutToolStripMenuItem"));
            copyToolStripMenuItem.Text = Convert.ToString(key.GetValue("copyToolStripMenuItem"));
            pasteToolStripMenuItem.Text = Convert.ToString(key.GetValue("pasteToolStripMenuItem"));
            deleteToolStripMenuItem.Text = Convert.ToString(key.GetValue("deleteToolStripMenuItem"));
            deleteAllToolStripMenuItem.Text = Convert.ToString(key.GetValue("deleteAllToolStripMenuItem"));
            selectAllToolStripMenuItem.Text = Convert.ToString(key.GetValue("selectAllToolStripMenuItem"));
            zoomInToolStripMenuItem.Text = Convert.ToString(key.GetValue("zoomInToolStripMenuItem"));
            zoomOutToolStripMenuItem.Text = Convert.ToString(key.GetValue("zoomOutToolStripMenuItem"));
            dateToolStripMenuItem.Text = Convert.ToString(key.GetValue("dateToolStripMenuItem"));

            //Format
            formatToolStripMenuItem.Text = Convert.ToString(key.GetValue("formatToolStripMenuItem"));
            fontToolStripMenuItem.Text = Convert.ToString(key.GetValue("fontToolStripMenuItem"));
            colorToolStripMenuItem.Text = Convert.ToString(key.GetValue("colorToolStripMenuItem"));
            wordWrapToolStripMenuItem.Text = Convert.ToString(key.GetValue("wordWrapToolStripMenuItem"));

            // Search
            searchToolStripMenuItem.Text = Convert.ToString(key.GetValue("searchToolStripMenuItem"));
            jumpToTopToolStripMenuItem.Text = Convert.ToString(key.GetValue("jumpToTopToolStripMenuItem"));
            jumpToBottomToolStripMenuItem.Text = Convert.ToString(key.GetValue("jumpToBottomToolStripMenuItem"));
            findToolStripMenuItem.Text = Convert.ToString(key.GetValue("findToolStripMenuItem"));
            findAndReplaceToolStripMenuItem.Text = Convert.ToString(key.GetValue("findAndReplaceToolStripMenuItem"));

            // Settings
            settingsToolStripMenuItem.Text = Convert.ToString(key.GetValue("settingsToolStripMenuItem"));
            languageToolStripMenuItem.Text = Convert.ToString(key.GetValue("languageToolStripMenuItem"));
            englishToolStripMenuItem.Text = Convert.ToString(key.GetValue("englishToolStripMenuItem"));
            turkishToolStripMenuItem.Text = Convert.ToString(key.GetValue("turkishToolStripMenuItem"));
            germanToolStripMenuItem.Text = Convert.ToString(key.GetValue("germanToolStripMenuItem"));
            frenchToolStripMenuItem.Text = Convert.ToString(key.GetValue("frenchToolStripMenuItem"));
            russianToolStripMenuItem.Text = Convert.ToString(key.GetValue("russianToolStripMenuItem"));
            chineseToolStripMenuItem.Text = Convert.ToString(key.GetValue("chineseToolStripMenuItem"));
            themeToolStripMenuItem.Text = Convert.ToString(key.GetValue("themeToolStripMenuItem"));
            darkToolStripMenuItem.Text = Convert.ToString(key.GetValue("darkToolStripMenuItem"));
            lightToolStripMenuItem.Text = Convert.ToString(key.GetValue("lightToolStripMenuItem"));

            // Help
            helpToolStripMenuItem.Text = Convert.ToString(key.GetValue("helpToolStripMenuItem"));
            aboutToolStripMenuItem.Text = Convert.ToString(key.GetValue("aboutToolStripMenuItem"));

            // Tool Strip
            toolStripLabel1.Text = Convert.ToString(key.GetValue("searchToolStripLabel"));
            toolStripLabel2.Text = Convert.ToString(key.GetValue("findToolStripLabel"));
            toolStripLabel3.Text = Convert.ToString(key.GetValue("replaceToolStripLabel"));

            // Tool Strip Status
            toolStripStatusLabel2.Text = Convert.ToString(key.GetValue("toolStripStatusLabel2"));
            toolStripStatusLabel3.Text = Convert.ToString(key.GetValue("toolStripStatusLabel3"));
            toolStripStatusLabel4.Text = Convert.ToString(key.GetValue("toolStripStatusLabel4"));
            toolStripStatusLabel5.Text = Convert.ToString(key.GetValue("toolStripStatusLabel5"));

            // Theme Registry
            // Light

            // Dark
        }

        // Main Form Load Event
        private void main_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel4.Text = "Font Color: " + richTextBox1.ForeColor;
            toolStripStatusLabel5.Text = "Font Family: " + richTextBox1.Font.FontFamily.Name;
        }

        // Main Form Closing Event
        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            RegistryKey key = Registry.CurrentUser;
            key = key.CreateSubKey(Application.ProductName);
  
            key.SetValue("R", richTextBox1.Text);

            // Theme Registry
            // Light
            key.SetValue("textBackColor", richTextBox1.BackColor);    

            // Dark
            
            // Language Registry
            // File
            key.SetValue("fileToolStripMenuItem", fileToolStripMenuItem.Text);
            key.SetValue("newToolStripMenuItem", newToolStripMenuItem.Text);
            key.SetValue("newWindowToolStripMenuItem", newWindowToolStripMenuItem.Text);
            key.SetValue("openToolStripMenuItem", openToolStripMenuItem.Text);
            key.SetValue("saveToolStripMenuItem", saveToolStripMenuItem.Text);
            key.SetValue("saveAsToolStripMenuItem", saveAsToolStripMenuItem.Text);
            key.SetValue("printToolStripMenuItem", printToolStripMenuItem.Text);
            key.SetValue("pageSetupToolStripMenuItem", pageSetupToolStripMenuItem.Text);
            key.SetValue("exitToolStripMenuItem", exitToolStripMenuItem.Text);

            // Edit
            key.SetValue("editToolStripMenuItem", editToolStripMenuItem.Text);
            key.SetValue("undoToolStripMenuItem", undoToolStripMenuItem.Text);
            key.SetValue("redoToolStripMenuItem", redoToolStripMenuItem.Text);
            key.SetValue("cutToolStripMenuItem", cutToolStripMenuItem.Text);
            key.SetValue("copyToolStripMenuItem", copyToolStripMenuItem.Text);
            key.SetValue("pasteToolStripMenuItem", pasteToolStripMenuItem.Text);
            key.SetValue("deleteToolStripMenuItem", deleteToolStripMenuItem.Text);
            key.SetValue("deleteAllToolStripMenuItem", deleteAllToolStripMenuItem.Text);
            key.SetValue("selectAllToolStripMenuItem", selectAllToolStripMenuItem.Text);
            key.SetValue("zoomInToolStripMenuItem", zoomInToolStripMenuItem.Text);
            key.SetValue("zoomOutToolStripMenuItem", zoomOutToolStripMenuItem.Text);
            key.SetValue("dateToolStripMenuItem", dateToolStripMenuItem.Text);

            // Format
            key.SetValue("formatToolStripMenuItem", formatToolStripMenuItem.Text);
            key.SetValue("fontToolStripMenuItem", fontToolStripMenuItem.Text);
            key.SetValue("colorToolStripMenuItem", colorToolStripMenuItem.Text);
            key.SetValue("wordWrapToolStripMenuItem", wordWrapToolStripMenuItem.Text);

            // Search
            key.SetValue("searchToolStripMenuItem", searchToolStripMenuItem.Text);
            key.SetValue("jumpToTopToolStripMenuItem", jumpToTopToolStripMenuItem.Text);
            key.SetValue("jumpToBottomToolStripMenuItem", jumpToBottomToolStripMenuItem.Text);
            key.SetValue("findToolStripMenuItem", findToolStripMenuItem.Text);
            key.SetValue("findAndReplaceToolStripMenuItem", findAndReplaceToolStripMenuItem.Text);

            // Settings
            key.SetValue("settingsToolStripMenuItem", settingsToolStripMenuItem.Text);
            key.SetValue("languageToolStripMenuItem", languageToolStripMenuItem.Text);
            key.SetValue("englishToolStripMenuItem", englishToolStripMenuItem.Text);
            key.SetValue("turkishToolStripMenuItem", turkishToolStripMenuItem.Text);
            key.SetValue("germanToolStripMenuItem", germanToolStripMenuItem.Text);
            key.SetValue("frenchToolStripMenuItem", frenchToolStripMenuItem.Text);
            key.SetValue("russianToolStripMenuItem", russianToolStripMenuItem.Text);
            key.SetValue("chineseToolStripMenuItem", chineseToolStripMenuItem.Text);
            key.SetValue("themeToolStripMenuItem", themeToolStripMenuItem.Text);
            key.SetValue("darkToolStripMenuItem", darkToolStripMenuItem.Text);
            key.SetValue("lightToolStripMenuItem", lightToolStripMenuItem.Text);

            // Help
            key.SetValue("helpToolStripMenuItem", helpToolStripMenuItem.Text);
            key.SetValue("aboutToolStripMenuItem", aboutToolStripMenuItem.Text);

            // Tool Strip
            key.SetValue("searchToolStripLabel", toolStripLabel1.Text);
            key.SetValue("findToolStripLabel", toolStripLabel2.Text);
            key.SetValue("replaceToolStripLabel", toolStripLabel3.Text);

            // Tool Strip Status
            key.SetValue("toolStripStatusLabel2", toolStripStatusLabel2);
            key.SetValue("toolStripStatusLabel3", toolStripStatusLabel3);
            key.SetValue("toolStripStatusLabel4", toolStripStatusLabel4);
            key.SetValue("toolStripStatusLabel5", toolStripStatusLabel5);
        }

        // Main Form Closed
        private void main_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        public int line = 0;
        public int column = 0;

        // Menu Strip
        // File - New
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            path = string.Empty;
            richTextBox1.Clear();
        }

        // File - New Window
        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm mn = new MainForm();
            mn.Show();
        }

        // File - Open
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter="Text Documents|*.txt", ValidateNames=true, Multiselect = false})
            {
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamReader sr = new StreamReader(ofd.FileName))
                        {
                            path = ofd.FileName;
                            Task<string> text = sr.ReadToEndAsync();
                            richTextBox1.Text = text.Result;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // File - Save
        private async void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(path))
            {
                using(SaveFileDialog sfd = new SaveFileDialog() { Filter = "Text Documents|*.txt", ValidateNames = true })
                {
                    if(sfd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            path = sfd.FileName;
                            using (StreamWriter sw = new StreamWriter(sfd.FileName))
                            {
                                await sw.WriteAsync(richTextBox1.Text);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

            else
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        await sw.WriteAsync(richTextBox1.Text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // File - Save As
        private async void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Text Documents|*.txt", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(sfd.FileName))
                        {
                            await sw.WriteAsync(richTextBox1.Text);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // File - Exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Edit - Undo
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(richTextBox1.CanUndo == true)
            {
                richTextBox1.Undo();
            }
        }

        // Edit - Redo
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(richTextBox1.CanRedo == true)
            {
                richTextBox1.Redo();
            }
        }

        // Edit - Cut
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(richTextBox1.SelectedText != "")
            {
                richTextBox1.Cut();
            }
        }

        // Edit - Copy
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        // Edit - Paste
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                richTextBox1.Paste();
            }
        }

        // Edit - Delete
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        // Edit - Delete All
        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }      

        // Edit - Select All
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }     

        // Edit - Zoom In
        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        // Edit - Date/Time
        private void dateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            richTextBox1.Text = dt.ToString();
        }

        // File - Print
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = printDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {

            }
        }

        // File - Page Setup
        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
        }

        // Format
        // Format - Font
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = fontDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog1.Font;
            }
        }

        // Format - Color
        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog fc = new ColorDialog();
            if (fc.ShowDialog() == DialogResult.OK)
                richTextBox1.ForeColor = fc.Color;
        }

        // Format - WordWrap
        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wordWrapToolStripMenuItem.Checked)
            {
                richTextBox1.WordWrap = true;
            }

            else
            {
                richTextBox1.WordWrap = false;
            }
        }

        // Search
        // Search - Jump to Top
        private void jumpToTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = 0;
            richTextBox1.ScrollToCaret();
        }

        // Search - Jump to Bottom
        private void jumpToBottomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }

        // Search - Find
        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Focus();
        }

        // Search - Find And Replace
        private void findAndReplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripTextBox2.Focus();
        }

        // Settings - Language - English
        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // File
            fileToolStripMenuItem.Text = "&File";
            newToolStripMenuItem.Text = "&New";
            newWindowToolStripMenuItem.Text = "&New Window";
            openToolStripMenuItem.Text = "&Open";
            saveToolStripMenuItem.Text = "&Save";
            saveAsToolStripMenuItem.Text = "&Save As";
            printToolStripMenuItem.Text = "&Print";
            pageSetupToolStripMenuItem.Text = "&Page Setup";
            exitToolStripMenuItem.Text = "&Exit";

            // Edit
            editToolStripMenuItem.Text = "&Edit";
            undoToolStripMenuItem.Text = "&Undo";
            redoToolStripMenuItem.Text = "&Redo";
            cutToolStripMenuItem.Text = "&Cut";
            copyToolStripMenuItem.Text = "&Copy";
            pasteToolStripMenuItem.Text = "&Paste";
            deleteToolStripMenuItem.Text = "&Delete";
            deleteAllToolStripMenuItem.Text = "&Delete All";
            selectAllToolStripMenuItem.Text = "&Select All";
            zoomInToolStripMenuItem.Text = "&Zoom In";
            zoomOutToolStripMenuItem.Text = "&Zoom Out";
            dateToolStripMenuItem.Text = "&Date/Time";

            // Format
            formatToolStripMenuItem.Text = "&Format";
            fontToolStripMenuItem.Text = "&Font";
            colorToolStripMenuItem.Text = "&Color";
            wordWrapToolStripMenuItem.Text = "&Word Wrap";

            // Search
            searchToolStripMenuItem.Text = "&Search";
            jumpToTopToolStripMenuItem.Text = "&Jump to Top";
            jumpToBottomToolStripMenuItem.Text = "&Jump to Bottom";
            findToolStripMenuItem.Text = "&Find";
            findAndReplaceToolStripMenuItem.Text = "&Find And Replace";

            // Settings
            settingsToolStripMenuItem.Text = "&Settings";
            languageToolStripMenuItem.Text = "&Language";
            englishToolStripMenuItem.Text = "&English";
            turkishToolStripMenuItem.Text = "&Turkish";
            germanToolStripMenuItem.Text = "&German";
            frenchToolStripMenuItem.Text = "&French";
            russianToolStripMenuItem.Text = "&Russian";
            chineseToolStripMenuItem.Text = "&Chinese";
            themeToolStripMenuItem.Text = "&Theme";
            darkToolStripMenuItem.Text = "&Dark";
            lightToolStripMenuItem.Text = "&Light";

            // Help
            helpToolStripMenuItem.Text = "&Help";
            aboutToolStripMenuItem.Text = "&About";

            // Tool Strip
            toolStripLabel1.Text = "Search";
            toolStripLabel2.Text = "Find";
            toolStripLabel3.Text = "Replace";

            // Tool Strip Status
            toolStripStatusLabel2.Text = "Text File";
            toolStripStatusLabel3.Text = "UTF-8";
            toolStripStatusLabel4.Text = "Font Color: " + richTextBox1.ForeColor;
            toolStripStatusLabel5.Text = "Font Family: " + richTextBox1.Font.FontFamily.Name;

            // Tool Tips
            // File
            fileToolStripMenuItem.ToolTipText = "File";
            newToolStripMenuItem.ToolTipText = "Create a New Text File (Ctrl+N)";
            newWindowToolStripMenuItem.ToolTipText = "Create a New Window (Ctrl+Shift+N)";
            openToolStripMenuItem.ToolTipText = "Open a File From This PC (Ctrl+O)";
            saveToolStripMenuItem.ToolTipText = "Save File (Ctrl+S)";
            saveAsToolStripMenuItem.ToolTipText = "Save File As (Ctrl+Alt+S)";
            pageSetupToolStripMenuItem.ToolTipText = "View File Pre-View (Ctrl+Alt+P)";
            printToolStripMenuItem.ToolTipText = "Print This File (Ctrl+P)";
            exitToolStripMenuItem.ToolTipText = "Exit From .Notepad (Alt+F4)";

            // Edit
            editToolStripMenuItem.ToolTipText = "Edit";
            undoToolStripMenuItem.ToolTipText = "Undo (Ctrl+Z)";
            redoToolStripMenuItem.ToolTipText = "Redo (Ctrl+Y)";
            cutToolStripMenuItem.ToolTipText = "Cut Selected Text (Ctrl+X)";
            copyToolStripMenuItem.ToolTipText = "Copy Selected Text (Ctrl+C)";
            pasteToolStripMenuItem.ToolTipText = "Paste Copied Text (Ctrl+V)";
            deleteToolStripMenuItem.ToolTipText = "Delete Selected Text (Ctrl+D)";
            deleteAllToolStripMenuItem.ToolTipText = "Delete All Text (Ctrl+Alt+D)";
            selectAllToolStripMenuItem.ToolTipText = "Select All Text (Ctrl+A)";
            zoomInToolStripMenuItem.ToolTipText = "Zoom In (Ctrl+Mouse Scroll Up)";
            zoomOutToolStripMenuItem.ToolTipText = "Zoom Out (Ctrl+Mouse Scroll Down)";
            dateToolStripMenuItem.ToolTipText = "Paste Date and Time From System";

            // Format
            formatToolStripMenuItem.ToolTipText = "Format";
            fontToolStripMenuItem.ToolTipText = "Change Fonts Size and Style";
            colorToolStripMenuItem.ToolTipText = "Change Fonts Color";
            wordWrapToolStripMenuItem.ToolTipText = "Open or Close Word Wrap";

            // Search
            searchToolStripMenuItem.ToolTipText = "Search";
            jumpToTopToolStripMenuItem.ToolTipText = "Jump to Top of Text";
            jumpToBottomToolStripMenuItem.ToolTipText = "Jump to Bottom of Text";
            findToolStripMenuItem.ToolTipText = "Find Words";
            findAndReplaceToolStripMenuItem.ToolTipText = "Find and Replace a Word";

            // Settings
            settingsToolStripMenuItem.ToolTipText = "Settings";
            languageToolStripMenuItem.ToolTipText = "Change Language of .Notepad";
            englishToolStripMenuItem.ToolTipText = "Change Language to English";
            turkishToolStripMenuItem.ToolTipText = "Change Language to Turkish";
            germanToolStripMenuItem.ToolTipText = "Change Language to German";
            frenchToolStripMenuItem.ToolTipText = "Change Language to French";
            russianToolStripMenuItem.ToolTipText = "Change Language to Russian";
            chineseToolStripMenuItem.ToolTipText = "Change Language to Chinese";
            themeToolStripMenuItem.ToolTipText = "Change Theme of .Notepad";
            lightToolStripMenuItem.ToolTipText = "Change Theme to Light";
            darkToolStripMenuItem.ToolTipText = "Change Theme to Dark";

            //Help
            helpToolStripMenuItem.ToolTipText = "Help";
            aboutToolStripMenuItem.ToolTipText = "View About of .Notepad";

            // ?
            toolStripMenuItem1.ToolTipText = "???";

            // Menu Strip
            newToolStripButton.ToolTipText = "Create a New Text File";
            openToolStripButton.ToolTipText = "Open a Text File";
            saveToolStripButton.ToolTipText = "Save File";
            printToolStripButton.ToolTipText = "Print File From a Printer";
            exitToolStripButton.ToolTipText = "Exit From .Notepad";
            cutToolStripButton.ToolTipText = "Cut Selected Text";
            copyToolStripButton.ToolTipText = "Copy Selected Text";
            pasteToolStripButton.ToolTipText = "Paste Copied Text";
            toolStripButton2.ToolTipText = "Undo";
            toolStripButton3.ToolTipText = "Redo";
            helpToolStripButton.ToolTipText = "Help";
            toolStripTextBox1.ToolTipText = "Search for Word";
            toolStripTextBox2.ToolTipText = "Find a Word";
            toolStripTextBox3.ToolTipText = "Replace Finded Word";
        }

        // Settings - Language - Turkish
        private void turkishToolStripMenuItem_Click(object sender, EventArgs e)
        {                    
            // File
            fileToolStripMenuItem.Text = "&Dosya";
            newToolStripMenuItem.Text = "&Yeni";
            newWindowToolStripMenuItem.Text = "&Yeni Pencere";
            openToolStripMenuItem.Text = "&Aç";
            saveToolStripMenuItem.Text = "&Kaydet";
            saveAsToolStripMenuItem.Text = "&Farklı Kaydet";
            printToolStripMenuItem.Text = "&Yazdır";
            pageSetupToolStripMenuItem.Text = "&Sayfa Kurulumu";
            exitToolStripMenuItem.Text = "&Çık";

            // Edit
            editToolStripMenuItem.Text = "&Düzenle";
            undoToolStripMenuItem.Text = "&Geri Al";
            redoToolStripMenuItem.Text = "&İleri Al";
            cutToolStripMenuItem.Text = "&Kes";
            copyToolStripMenuItem.Text = "&Kopyala";
            pasteToolStripMenuItem.Text = "&Yapıştır";
            deleteToolStripMenuItem.Text = "&Sil";
            deleteAllToolStripMenuItem.Text = "&Hepsini Sil";
            selectAllToolStripMenuItem.Text = "&Hepsini Seç";
            zoomInToolStripMenuItem.Text = "&İçeri Yakınlaştır";
            zoomOutToolStripMenuItem.Text = "&Dışarı Yakınlaştır";
            dateToolStripMenuItem.Text = "&Tarih/Zaman";

            // Format
            formatToolStripMenuItem.Text = "&Biçim";
            fontToolStripMenuItem.Text = "&Yazı Tipi";
            colorToolStripMenuItem.Text = "&Renk";
            wordWrapToolStripMenuItem.Text = "&Kelime Kaydırma";

            // Search
            searchToolStripMenuItem.Text = "&Ara";
            jumpToTopToolStripMenuItem.Text = "&En Üste Zıpla";
            jumpToBottomToolStripMenuItem.Text = "&En Alta Zıpla";
            findToolStripMenuItem.Text = "&Bul";
            findAndReplaceToolStripMenuItem.Text = "&Bul ve Yerleştir";

            // Settings
            settingsToolStripMenuItem.Text = "&Ayarlar";
            languageToolStripMenuItem.Text = "&Dil";
            englishToolStripMenuItem.Text = "&İngilizce";
            turkishToolStripMenuItem.Text = "&Türkçe";
            germanToolStripMenuItem.Text = "&Almanca";
            frenchToolStripMenuItem.Text = "&Fransızca";
            russianToolStripMenuItem.Text = "&Rusça";
            chineseToolStripMenuItem.Text = "&Çince";
            themeToolStripMenuItem.Text = "&Tema";
            darkToolStripMenuItem.Text = "&Koyu";
            lightToolStripMenuItem.Text = "&Açık";

            // Help
            helpToolStripMenuItem.Text = "&Yardım";
            aboutToolStripMenuItem.Text = "&Hakkında";

            // Tool Strip
            toolStripLabel1.Text = "Ara";
            toolStripLabel2.Text = "Bul";
            toolStripLabel3.Text = "Yerleştir";

            // Tool Strip Status
            toolStripStatusLabel2.Text = "Metin Dosyası";
            toolStripStatusLabel3.Text = "UTF-8";
            toolStripStatusLabel4.Text = "Yazı Rengi: " + richTextBox1.ForeColor;
            toolStripStatusLabel5.Text = "Yazı Tipi Ailesi: " + richTextBox1.Font.FontFamily.Name;

            // Tool Tips
            // File
            fileToolStripMenuItem.ToolTipText = "Dosya";
            newToolStripMenuItem.ToolTipText = "Yeni Dosya Oluştur (Ctrl+N)";
            newWindowToolStripMenuItem.ToolTipText = "Yeni Pencere Oluştur (Ctrl+Shift+N)";
            openToolStripMenuItem.ToolTipText = "Bu Bilgisayardan Başka Bir Dosya Aç (Ctrl+O)";
            saveToolStripMenuItem.ToolTipText = "Dosyayı Kaydet (Ctrl+S)";
            saveAsToolStripMenuItem.ToolTipText = "Dosyayı Farklı Kaydet (Ctrl+Alt+S)";
            pageSetupToolStripMenuItem.ToolTipText = "Sayfa Önizlemesini Görüntüle (Ctrl+Alt+P)";
            printToolStripMenuItem.ToolTipText = "Dosyayı Bir Yazıcıdan Yazdır (Ctrl+P)";
            exitToolStripMenuItem.ToolTipText = ".Notepad'den Çık (Alt+F4)";

            // Edit
            editToolStripMenuItem.ToolTipText = "Düzenle";
            undoToolStripMenuItem.ToolTipText = "Yapılan Eylemi Geri Al (Ctrl+Z)";
            redoToolStripMenuItem.ToolTipText = "Yapılan Eylemi İleri Al (Ctrl+Y)";
            cutToolStripMenuItem.ToolTipText = "Seçili Metni Kes (Ctrl+X)";
            copyToolStripMenuItem.ToolTipText = "Seçili Metni Kopyala (Ctrl+C)";
            pasteToolStripMenuItem.ToolTipText = "Kopyalanmış Metni Yapıştır (Ctrl+V)";
            deleteToolStripMenuItem.ToolTipText = "Seçili Metni Sil (Ctrl+D)";
            deleteAllToolStripMenuItem.ToolTipText = "Tüm Metni Sil (Ctrl+Alt+D)";
            selectAllToolStripMenuItem.ToolTipText = "Tümünü Seç (Ctrl+A)";
            zoomInToolStripMenuItem.ToolTipText = "İçeri Yakınlaştır (Ctrl+Fare Orta Tuşu İleri)";
            zoomOutToolStripMenuItem.ToolTipText = "Dışarı Yakınlaştır (Ctrl+Fare Orta Tuşu Geri)";
            dateToolStripMenuItem.ToolTipText = "Sistemin Tarih ve Zamanını Yapıştır";

            // Format
            formatToolStripMenuItem.ToolTipText = "Biçim";
            fontToolStripMenuItem.ToolTipText = "Metnin Yazı Tipini ve Boyutunu Değiştir";
            colorToolStripMenuItem.ToolTipText = "Metnin Rengini Değiştir";
            wordWrapToolStripMenuItem.ToolTipText = "Kelime Kaydırma Özelliğini Aç veya Kapat";

            // Search
            searchToolStripMenuItem.ToolTipText = "Ara";
            jumpToTopToolStripMenuItem.ToolTipText = "Metnin En Üstüne Zıpla";
            jumpToBottomToolStripMenuItem.ToolTipText = "Metnin En Altına Zıpla";
            findToolStripMenuItem.ToolTipText = "Kelime Bul";
            findAndReplaceToolStripMenuItem.ToolTipText = "Kelime Bul ve Yerleştir";

            // Settings
            settingsToolStripMenuItem.ToolTipText = "Ayarlar";
            languageToolStripMenuItem.ToolTipText = ".Notepad'in Dilini Değiştir";
            englishToolStripMenuItem.ToolTipText = "Dili İngilizce Olarak Ayarla";
            turkishToolStripMenuItem.ToolTipText = "Dili Türkçe Olarak Ayarla";
            germanToolStripMenuItem.ToolTipText = "Dili Almanca Olarak Ayarla";
            frenchToolStripMenuItem.ToolTipText = "Dili Fransızca Olarak Ayarla";
            russianToolStripMenuItem.ToolTipText = "Dili Rusça Olarak Ayarla";
            chineseToolStripMenuItem.ToolTipText = "Dili Çince Olarak Ayarla";
            themeToolStripMenuItem.ToolTipText = ".Notepad'in Temasını Değiştir";
            lightToolStripMenuItem.ToolTipText = "Temayı Açık Olarak Ayarla";
            darkToolStripMenuItem.ToolTipText = "Temayı Koyu Olarak Ayarla";

            //Help
            helpToolStripMenuItem.ToolTipText = "Yardım";
            aboutToolStripMenuItem.ToolTipText = ".Notepad Hakkındakileri Görüntüle";

            // ?
            toolStripMenuItem1.ToolTipText = "???";

            // Menu Strip
            newToolStripButton.ToolTipText = "Yeni Metin Belgesi Oluştur";
            openToolStripButton.ToolTipText = "Bu Bilgisayardan Başka Bir Metin Dosyası Aç";
            saveToolStripButton.ToolTipText = "Dosyayı Kaydet";
            printToolStripButton.ToolTipText = "Dosyayı Bir Yazıcıdan Yazdır";
            exitToolStripButton.ToolTipText = ".Notepad'den Çık";
            cutToolStripButton.ToolTipText = "Seçili Metni Kes";
            copyToolStripButton.ToolTipText = "Seçili Metni Kopyala";
            pasteToolStripButton.ToolTipText = "Kopyalanmış Metni Yapıştır";
            toolStripButton2.ToolTipText = "Geri Al";
            toolStripButton3.ToolTipText = "İleri Al";
            helpToolStripButton.ToolTipText = "Yardım";
            toolStripTextBox1.ToolTipText = "Bir Kelime Arayın";
            toolStripTextBox2.ToolTipText = "Bir Kelime Bulun";
            toolStripTextBox3.ToolTipText = "Bulduğunuz Metnin Yerine Bir Kelime Yerleştirin";
        }

        // Settings - Theme - Dark
        private void darkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.FromArgb(30, 30, 30);
            richTextBox1.ForeColor = Color.White;

            menuStrip1.BackColor = Color.FromArgb(37, 37, 38);
            menuStrip1.ForeColor = Color.White;
            
            newToolStripMenuItem.BackColor = Color.FromArgb(37, 37, 38);
            newToolStripMenuItem.ForeColor = Color.White;

            newWindowToolStripMenuItem.BackColor = Color.FromArgb(37, 37, 38);
            newWindowToolStripMenuItem.ForeColor = Color.White;

            openToolStripMenuItem.BackColor = Color.FromArgb(37, 37, 38);
            openToolStripMenuItem.ForeColor = Color.White;

            saveToolStripMenuItem.BackColor = Color.FromArgb(37, 37, 38);
            saveToolStripMenuItem.ForeColor = Color.White;
          
            saveAsToolStripMenuItem.BackColor = Color.FromArgb(37, 37, 38);
            saveAsToolStripMenuItem.ForeColor = Color.White;

            toolStrip1.BackColor = Color.FromArgb(37, 37, 38);

            toolStripSeparator1.BackColor = Color.FromArgb(37, 37, 38);
            toolStripSeparator2.BackColor = Color.FromArgb(37, 37, 38);
            toolStripSeparator3.BackColor = Color.FromArgb(37, 37, 38);
            toolStripSeparator4.BackColor = Color.FromArgb(37, 37, 38);
            toolStripSeparator5.BackColor = Color.FromArgb(37, 37, 38);
            toolStripSeparator6.BackColor = Color.FromArgb(37, 37, 38);
        }

        // Settings - Theme - Light
        private void lightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.White;
            richTextBox1.ForeColor = Color.Black;

            menuStrip1.BackColor = Color.White;
            menuStrip1.ForeColor = Color.Black;

            toolStrip1.BackColor = Color.White;
            toolStrip1.ForeColor = Color.Black;

            statusStrip1.BackColor = Color.White;
            statusStrip1.ForeColor = Color.Black;

            toolStripTextBox1.BackColor = Color.FromName("Menu");
            toolStripTextBox2.BackColor = Color.FromName("Menu");
            toolStripTextBox3.BackColor = Color.FromName("Menu");
        }

        // Help - About
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (formAbout frm = new formAbout())
            {
                frm.ShowDialog();
            }
        }     

        // ???????????????????????????????????????????????????????????????????
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
        }

        // Tool Strip - New
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            path = string.Empty;
            richTextBox1.Clear();
        }

        // Tool Strip - Open
        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Text Documents|*.txt", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamReader sr = new StreamReader(ofd.FileName))
                        {
                            path = ofd.FileName;
                            Task<string> text = sr.ReadToEndAsync();
                            richTextBox1.Text = text.Result;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Tool Strip - Save
        private async void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(path))
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Text Documents|*.txt", ValidateNames = true })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            path = sfd.FileName;
                            using (StreamWriter sw = new StreamWriter(sfd.FileName))
                            {
                                await sw.WriteAsync(richTextBox1.Text);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

            else
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        await sw.WriteAsync(richTextBox1.Text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Tool Strip - Print
        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = printDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {

            }
        }

        // Tool Strip - Cut
        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != "")
            {
                richTextBox1.Cut();
            }
        }

        // Tool Strip - Copy
        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        // Tool Strip - Paste
        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                richTextBox1.Paste();
            }
        }

        // Tool Strip - Undo Button
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanUndo == true)
            {
                richTextBox1.Undo();
            }
        }

        // Tool Strip - Redo Button
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanRedo == true)
            {
                richTextBox1.Redo();
            }
        }

        // Tool Strip - Help
        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            using (formAbout frm = new formAbout())
            {
                frm.ShowDialog();
            }
        }

        // Tool Strip - Exit
        private void exitToolStripButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            line = 1 + richTextBox1.GetLineFromCharIndex(richTextBox1.GetFirstCharIndexOfCurrentLine());
            column = 1 + richTextBox1.SelectionStart - richTextBox1.GetFirstCharIndexOfCurrentLine();
            toolStripStatusLabel1.Text = "Line: " + line.ToString() + " | Column: " + column.ToString();
        }  

        // Tool Strip - Search Text Box
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            string keywords = toolStripTextBox1.Text;
            MatchCollection keywordMatches = Regex.Matches(richTextBox1.Text, keywords);

            int originalIndex = richTextBox1.SelectionStart;
            int originalLenght = richTextBox1.SelectionLength;

            toolStripTextBox1.Focus();

            richTextBox1.SelectionStart = 0;
            richTextBox1.SelectionLength = richTextBox1.Text.Length;
            richTextBox1.SelectionBackColor = Color.White;

            foreach (Match m in keywordMatches)
            {
                richTextBox1.SelectionStart = m.Index;
                richTextBox1.SelectionLength = m.Length;
                richTextBox1.SelectionColor = Color.Black;
                richTextBox1.SelectionBackColor = Color.DodgerBlue;
            }

            richTextBox1.SelectionStart = originalIndex;
            richTextBox1.SelectionLength = originalLenght;
            richTextBox1.SelectionBackColor = Color.White;
        }

        // Find and Replace Button
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox2.Text != null && !string.IsNullOrWhiteSpace(toolStripTextBox2.Text) && toolStripTextBox3.Text != null && !string.IsNullOrWhiteSpace(toolStripTextBox3.Text))
            {
                richTextBox1.Text = richTextBox1.Text.Replace(toolStripTextBox2.Text, toolStripTextBox3.Text);
                toolStripTextBox2.Text = "";
                toolStripTextBox3.Text = "";
            }
        }

        // Text Area
        // Text Area - Back Color
        private void backColorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.BackColor = cd.Color;
            }
        }

        // Text Area - Fore Color
        private void foreColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = cd.Color;
            }
        }

        // Menu Strip
        // Menu Strip - Back Color
        private void backColorToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                menuStrip1.BackColor = cd.Color;
            }
        }

        // Menu Strip - Fore Color
        private void foreColorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                menuStrip1.ForeColor = cd.Color;
            }
        }


        // Tool Strip
        // Tool Strip - Back Color
        private void backColorToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                toolStrip1.BackColor = cd.Color;
            }
        }

        // Tool Strip - Fore Color
        private void foreColorToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                toolStrip1.ForeColor = cd.Color;
            }
        }


        // Status Strip
        // Status Strip - Back Color
        private void backColorToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                statusStrip1.BackColor = cd.Color;
            }
        }

        // Status Strip - Fore Color
        private void foreColorToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                statusStrip1.ForeColor = cd.Color;
            }
        }

        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;
        }

        private void main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
                TopMost = false;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        
    }
}