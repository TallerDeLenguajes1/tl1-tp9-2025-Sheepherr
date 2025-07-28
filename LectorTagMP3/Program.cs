// See https://aka.ms/new-console-template for more information
using System;
using System.Text;
using EspacioLectorTagMP3;

Console.WriteLine("Ingrese la ruta del archivo MP3: ");
string ruta = Console.ReadLine();

if (!File.Exists(ruta)) // verifica que el archivo exista
{
    System.Console.WriteLine("El archivo no existe");

}

using (FileStream fs = new FileStream(ruta, FileMode.Open, FileAccess.Read))
{
    fs.Seek(-128,SeekOrigin.End); // seek posiciona el lector 128 bytes antes del final
    byte[] buffer = new byte[128];
    fs.Read(buffer, 0, buffer.Length);

    string header = Encoding.GetEncoding("latin1").GetString(buffer, 0, 3); //GetString: convierte bytes a texto usado codificacion latin1
    if (header != "TAG")
    {
        System.Console.WriteLine("El archivo no contiene una etiqueta ID3V1 valida.");
    }
    string titulo  = Encoding.GetEncoding("latin1").GetString(buffer, 3, 30).TrimEnd('\0');
    string artista = Encoding.GetEncoding("latin1").GetString(buffer, 33, 30).TrimEnd('\0');
    string album   = Encoding.GetEncoding("latin1").GetString(buffer, 63, 30).TrimEnd('\0');
    string anio    = Encoding.GetEncoding("latin1").GetString(buffer, 93, 4).TrimEnd('\0');
    
    ID3v1Tag tag = new ID3v1Tag{
        Titulo = titulo,
        Artista = artista,
        Album = album,
        Anio = anio
    };

    System.Console.WriteLine("\nInformacion leida del MP3:");
    System.Console.WriteLine(tag);
}