using System;
using System.IO;

string path;

do
{
    System.Console.WriteLine("Ingrese el path del directorio que desea analizar: ");
    path = Console.ReadLine();
    if (!Directory.Exists(path))
    {
        System.Console.WriteLine("El directorio no existe. Por favor intrese una ruta valida.\n");
    }
} while (!Directory.Exists(path));

System.Console.WriteLine("\nDirectorio valido ingresado: " + path);

System.Console.WriteLine("\n=== Carpetas dentro del directorio ===");
string[] subcarpetas = Directory.GetDirectories(path); // directory.getdirectories devuelve un array con todas las subscarpetas

foreach (string carpeta in subcarpetas)
{
    System.Console.WriteLine(Path.GetFileName(carpeta)); // esto obtiene solo el nombre de la carpeta sin el path completo
}

System.Console.WriteLine("\n=== Archivos dentro del directorio ===");
string[] archivos = Directory.GetFiles(path); // devuelve un array con todos los archivos en ese directorio

foreach (string archivo in archivos)
{
    FileInfo info = new FileInfo(archivo); // permite obtener informacion detallada de un archivo (nombre, tamaño, fecha, etc)
    double tamanioKB = Math.Round(info.Length / 1020.0, 2); // info.length entrega el tamaño del archivo en bytes
    System.Console.WriteLine($"{info.Name} - {tamanioKB} KB"); // info.Name entrega el nombre del archivo con su extencion
}

string pathCsv = Path.Combine(path, "reporte_archivos.csv"); // path.combine: une rutas de forma segura

using (StreamWriter writer = new StreamWriter(pathCsv)) // streamwriter permite escribir texto de un archivo
{
    writer.WriteLine("Nombre del archivo, Tamaño (KB), Fecha de Ultima Modificacion");

    foreach (string archivo in archivos)
    {
        FileInfo info = new FileInfo(archivo);
        double tamanioKB = Math.Round(info.Length / 1020.0, 2);
        string fecha = info.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
        writer.WriteLine($"{info.Name},{tamanioKB},{fecha}");
    }
}
System.Console.WriteLine($"\nEl archivo CSV fue generado correctamente en: {pathCsv}");