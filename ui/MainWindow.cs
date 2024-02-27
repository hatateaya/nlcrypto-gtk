/*
    Copyright(c) 2019-2021 MuHua<https://github.com/muhua-usnnrqffjcqv/>.

    This file is part of nlCryptoGtk.

    nlCryptoGtk is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    nlCryptoGtk is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with nlCryptoGtk.  If not, see <https://www.gnu.org/licenses/>.
*/

using Gtk;
using System;
using NlCrypto;

namespace NlCryptoGtk
{
    class MainWindow : Window
    {
        public TextView textView;
        public CheckButton isUseLongWord;
        public CheckButton isUseCrypt;
        public Entry passwordEntry;
        public MainWindow() : base(WindowType.Toplevel)
        {
            // Setup GUI
            WindowPosition = WindowPosition.Center;
            DefaultSize = new Gdk.Size(400, 250);
            
            // Simple Actions
            var menu = new GLib.Menu();
            menu.AppendItem(new GLib.MenuItem("About", "app.about"));
            menu.AppendItem(new GLib.MenuItem("Quit", "app.quit"));
            Program.App.AppMenu = menu;
            
            var aboutAction = new GLib.SimpleAction("about", null);
            aboutAction.Activated += AboutActivated;
            Program.App.AddAction(aboutAction);

            var quitAction = new GLib.SimpleAction("quit", null);
            quitAction.Activated += QuitActivated;
            Program.App.AddAction(quitAction);

            var headerBar = new HeaderBar();
            headerBar.ShowCloseButton = true;
            headerBar.Title = "NlCrypto Gtk";

            Titlebar = headerBar;
            
            // Box

            var paned = new Paned(Orientation.Horizontal);
            Child = paned;

            // ScrolledWindow
            
            var scrolledWindow = new ScrolledWindow();
            scrolledWindow.SetSizeRequest(500,100);
            paned.Add(scrolledWindow);
            
            // ButtonBox

            var buttonBox = new ButtonBox(Orientation.Vertical);
            
            buttonBox.MarginTop = 24;
            buttonBox.MarginBottom = 48;
            buttonBox.LayoutStyle = ButtonBoxStyle.Start;
            
            var buttonEncrypt = new Button();
            buttonEncrypt.Label = "Encrypt";
            buttonEncrypt.Margin = 10;
            buttonBox.Add(buttonEncrypt);
            
            var buttonDecrypt = new Button();
            buttonDecrypt.Margin = 10;
            buttonDecrypt.Label = "Decrypt";
            buttonBox.Add(buttonDecrypt);
            
            var buttonClear = new Button();
            buttonClear.Margin = 10;
            buttonClear.Label = "Clear";
            buttonBox.Add(buttonClear);
            
            isUseLongWord = new CheckButton();
            isUseLongWord.Label = "Using Long Word";
            isUseLongWord.Active = true;
            isUseLongWord.MarginLeft = 10;
            buttonBox.Add(isUseLongWord);
            
            isUseCrypt = new CheckButton();
            isUseCrypt.Label = "Using Crypt";
            isUseCrypt.Active = true;
            isUseCrypt.MarginLeft = 10;
            buttonBox.Add(isUseCrypt);
            
                                                                                    
            var labelPassword = new Label();                            
            labelPassword.Text = "Cryption Password:";
            labelPassword.Margin = 0;
            buttonBox.Add(labelPassword);                               
                                                                        
            passwordEntry = new Entry();                                
            passwordEntry.Margin = 10;                                  
            buttonBox.Add(passwordEntry);                               

            var label = new Label();
            label.Text = @"
NlCrypt GTK Version 
(Latin6) by MuHua.
Check About to 
see more.
Version: 2.6.0.1
";
            buttonBox.Add(label);
            
            paned.Add(buttonBox);
            
            // TextView

            textView = new TextView();
            textView.Editable = true;
            textView.Buffer.Text = "Please Input text";
            textView.WrapMode = WrapMode.WordChar;
            scrolledWindow.Add(textView);

            // Events
            
            buttonClear.Clicked += (sender, e) => ButtonClearClicked();
            buttonEncrypt.Clicked += (sender, e) => ButtonEncryptClicked();
            buttonDecrypt.Clicked += (sender, e) => ButtonDecryptClicked();
            Destroyed += (sender, e) => Application.Quit();
            
        }

        private void ButtonClearClicked()
        {
            textView.Buffer.Text = "";
        }

        private void ButtonEncryptClicked()
        {
            textView.Buffer.Text = Nlc.Encrypt(textView.Buffer.Text,passwordEntry.Text,isUseCrypt.Active,isUseLongWord.Active);
        }
        
        private void ButtonDecryptClicked()
        {
            textView.Buffer.Text = Nlc.Decrypt(textView.Buffer.Text,passwordEntry.Text,isUseCrypt.Active);
        }

        private static void AboutActivated(object sender, EventArgs e)
        {
            var dialog = new AboutDialog
            {
                TransientFor = Program.Win,
                ProgramName = "NlCrypto(Latin6) GTK Version",
                Version = "2.6.0.0",
                Comments = "A tool to obfuscate and encrypt text like natural language by MuHua(https://github.com/muHua-usnnrqffjcqv).",
                LogoIconName = "system-run-symbolic",
                License = @"This program comes with absolutely no warranty.
See the GNU General Public License, version 3 or later for details.",
                Website = "https://github.com/muHua-usnnrqffjcqv/NatureLanguageCrypto",
                WebsiteLabel = "Github Project"
            };
            dialog.Run();
            dialog.Hide();
        }

        private static void QuitActivated(object sender, EventArgs e)
        {
            Application.Quit();
        }
    }
}
