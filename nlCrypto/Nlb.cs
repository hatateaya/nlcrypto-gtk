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

// Version: nlb64b2-gtk

namespace NlCrypto
{
    public static class Nlb
    {
        static public string Encode(string inText, bool longWordUsing)
        {
            // 定义使用的StringBuilder
            StringBuilder stringBuilder = new StringBuilder();
            // iniFile初始化
            // b64的文本转到数组
            char[] b64textChar = inText.ToCharArray();
            // 用tempString做中继是为了小写字母双写方便
            Random rd = new Random();
            string tempString;
            // 随机数使用
            if (longWordUsing == true)
            // 如果使用长+短文本
            {
                for (int cycleNum = 0; cycleNum != inText.Length; cycleNum++)
                // 循环替换
                {
                    if (b64textChar[cycleNum] == '=')
                    // 由于辣鸡INI不支持文件名带= 所以要替换成'
                    {
                        tempString = "\'";
                    }
                    else
                    // 如果字符不是=
                    {
                        if (char.IsLower(b64textChar[cycleNum]))
                        // 由于辣鸡INI自动大小写兼容 所以小写字母要双写
                        {
                            tempString = b64textChar[cycleNum].ToString() + b64textChar[cycleNum].ToString();
                        }
                        else
                        // 莫得事就直接赋值力
                        {
                            tempString = b64textChar[cycleNum].ToString();
                        }
                    }
                    if (rd.Next(1, 4) == 1)
                    // 如果随机到了长文本(四分之一概率)
                    {
                        // 使用加密表A在字符串最后加上混淆文本
                        stringBuilder.Append(Ini.ReadValue("enCodeB", tempString) + " ");
                    }
                    else
                    // 如果随机到了短文本(四分之三概率)
                    {
                        stringBuilder.Append(Ini.ReadValue("enCodeA", tempString) + " ");
                    }
                }
            }
            else
            // 如果使用短文本
            {
                for (int cycleNum = 0; cycleNum != inText.Length; cycleNum++)
                {
                    if (b64textChar[cycleNum] == '=')
                    // 由于辣鸡INI不支持文件名带= 所以要替换成'
                    {
                        tempString = "\'";
                    }
                    else
                    // 如果字符不是=
                    {
                        if (char.IsLower(b64textChar[cycleNum]))
                        // 由于辣鸡INI自动大小写兼容 所以小写字母要双写
                        {
                            tempString = b64textChar[cycleNum].ToString() + b64textChar[cycleNum].ToString();
                        }
                        else
                        // 莫得事就直接赋值力
                        {
                            tempString = b64textChar[cycleNum].ToString();
                        }
                    }
                    // 使用加密表A在字符串最后加上混淆文本
                    stringBuilder.Append(Ini.ReadValue("enCodeA", tempString) + " ");
                }
            }
            return stringBuilder.ToString();
        }
        static public string Decode(string inText)
        // inText为输入文本
        {
            // 定义使用的StringBuilder
            StringBuilder stringBuilder = new StringBuilder();
            // 混淆的文本按词转到数组
            string[] b64textString = inText.Split(' ');
            for (int cycleNum = 0; cycleNum != b64textString.Length; cycleNum++)
            // 按照INI对应循环替换
            {
                string tempString = Ini.ReadValue("deCode", b64textString[cycleNum].ToString());
                // 按照INI进行逐词替换
                if (tempString == "\'")
                {
                    stringBuilder.Append("=");
                }
                else
                {
                    stringBuilder.Append(tempString);
                }
            }
            return stringBuilder.ToString();
            // 返回解密结果
        }
    }
}
