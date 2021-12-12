/*
    Copyright(c) 2019-2021 Muhua<https://github.com/muhua-usnnrqffjcqv/>.

    This file is part of nlcryptoGtk.

    nlcryptoGtk is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    nlcryptoGtk is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with nlcryptoGtk.  If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using Gtk;

namespace NlCryptoGtk
{
    static class Program
    {
        public static Application App;
        public static Window Win;

        [STAThread]
        public static void Main(string[] args)
        {
            Application.Init();

            App = new Application("com.github.muhua.nlCryptoGtk", GLib.ApplicationFlags.None);
            App.Register(GLib.Cancellable.Current);

            Win = new MainWindow();
            App.AddWindow(Win);

            Win.ShowAll();
            Application.Run();
        }
    }
}
