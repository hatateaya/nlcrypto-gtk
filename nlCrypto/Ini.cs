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

// nlCrypto遗留问题

using System.IO;

namespace NlCrypto
{
    public static class Ini
    {
        static public string ReadValue(string a,string b){
            IniFile iniFile = new IniFile();
            iniFile.Load(Path.GetTempPath()+"nlcryptocode.ini");
            return iniFile[a][b].GetString();
        }
    }

}
