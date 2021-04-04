using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public static class Log
    {
    /// <summary>
    /// Метод сохраненяет файл c именем nameFile и контентом fileContent
    /// </summary>
    /// <param name="nameFile">Имя файла</param>
    /// <param name="fileContent">Контент файла</param>
    public static void SaveLogFile(string nameFile, string fileContent)
        {
            using (StreamWriter streamWriter = File.CreateText(nameFile))
            {
                streamWriter.Write(fileContent);
            }
        }

    /// <summary>
    /// Метод открывыет файл с именем nameFile
    /// </summary>
    /// <param name="nameFile">Имя файла</param>
    /// <returns>Возвращает контент файла</returns>
    public static string OpenLogFile(string nameFile)
    {
        string fileContents;
        try
        {
            using (StreamReader streamReader = File.OpenText(nameFile))
            {
                fileContents = streamReader.ReadToEnd();
            }
        }
        catch (FileNotFoundException)
        {
            return "";
        }
        return fileContents;
    }

    }
