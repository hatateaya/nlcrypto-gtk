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
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace NlCrypto
{
    public static class Nlc
    {
        public static string Encrypt(string inText, string inPassword, bool usingCrypto, bool usingLongword)
        {
            if (string.IsNullOrEmpty(inText))
            {
                return "";
            }
            MD5 md5 = MD5.Create();
            string b64Text;
            if (usingCrypto == true)
            // 如果使用加密
            {
                byte[] encryptionBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(inPassword));
                string EncryptionStr = Convert.ToBase64String(encryptionBytes);
                // 密码进行MD5之后取前十六位用于AES加密
                b64Text = Aes.Encrypt(inText, EncryptionStr.Substring(0, 16));
                // 密码和文本进行AES-ECB加密再进行BASE64
            }
            else
            {
                // 如果不使用加密
                byte[] inArray = Encoding.Default.GetBytes(inText);
                b64Text = Convert.ToBase64String(inArray);
                // 直接BASE64输入框文本
            }
            // 加密后的文本进行nlb64混淆
            inText = Nlb.Encode(b64Text, usingLongword);
            return inText;
        }

        public static string Decrypt(string inText, string passwordText, bool usingCrypto)
        {
            if (string.IsNullOrEmpty(inText))
            {
                return "";
            }
            MD5 md5 = MD5.Create();
            // 去首尾空及换行
            string trimText = inText.Trim();
            trimText = trimText.Replace("\r", "");
            trimText = trimText.Replace("\n", "");
            // ioText.Text = nlBase64.nlbDecode(ioText.Text);
            if (usingCrypto == true)
            // 如果使用解密
            {
                byte[] encryptionBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(passwordText));
                string EncryptionStr = Convert.ToBase64String(encryptionBytes);
                // 密码进行MD5之后取前十六位用于AES解密
                inText = Aes.Decrypt(Nlb.Decode(trimText), EncryptionStr.Substring(0, 16)); ;
            }
            else
            {
                inText = Encoding.Default.GetString(Convert.FromBase64String(Nlb.Decode(trimText)));
                // 直接输出
            }
            return inText;
        }
    }
}
