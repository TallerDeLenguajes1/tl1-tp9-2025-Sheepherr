namespace EspacioLectorTagMP3;

public class ID3v1Tag 
{
    public string Titulo {get; set;}
    public string Artista {get; set;}
    public string Album {get; set;}
    public string Anio {get; set;}

    public override string ToString ()
    {
        return $"Titulo: {Titulo}\nArtista: {Artista}\nAño: {Anio}";
    }
}