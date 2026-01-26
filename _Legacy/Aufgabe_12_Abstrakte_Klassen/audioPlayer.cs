using System;
using System.Collections.Generic;
using System.Linq; // Nötig für einfache Zufallssortierung

public abstract class AudioFile
{
    public string Dateiname { get; set; }
    public string Speicherort { get; set; }

    public AudioFile(string dateiname, string speicherort)
    {
        Dateiname = dateiname;
        Speicherort = speicherort;
    }

    public abstract void Play();
}

public class MP3File : AudioFile
{
    public MP3File(string name, string ort) : base(name, ort) { }
    public override void Play() => Console.WriteLine($"Spiele MP3: {Dateiname} (Ort: {Speicherort})");
}

public class WAVFile : AudioFile
{
    public WAVFile(string name, string ort) : base(name, ort) { }
    public override void Play() => Console.WriteLine($"Spiele WAV: {Dateiname} (High Quality)");
}

public class FLACFile : AudioFile
{
    public FLACFile(string name, string ort) : base(name, ort) { }
    public override void Play() => Console.WriteLine($"Spiele FLAC: {Dateiname} (Lossless)");
}

public class AudioPlayer
{
    private List<AudioFile> _playlist = new List<AudioFile>();

    public void AddFile(AudioFile file)
    {
        _playlist.Add(file);
    }

    public void RemoveFile(int index)
    {
        if (index >= 0 && index < _playlist.Count)
        {
            _playlist.RemoveAt(index);
        }
    }

    // Spielt ein einzelnes File anhand der ID (Index)
    public void Play(int index)
    {
        if (index >= 0 && index < _playlist.Count)
        {
            _playlist[index].Play();
        }
    }

    /// <summary>
    /// Spielt alle Dateien ab. Optional in zufälliger Reihenfolge.
    /// </summary>
    /// <param name="zufall">Wenn true, wird die Playlist gemischt.</param>
    public void PlayAll(bool zufall = false)
    {
        List<AudioFile> abspielListe;

        if (zufall)
        {
            Random rnd = new Random();
            // Erstellt eine temporäre, gemischte Kopie der Liste (Fisher-Yates oder LINQ OrderBy)
            abspielListe = _playlist.OrderBy(x => rnd.Next()).ToList();
            Console.WriteLine("--- Zufallswiedergabe gestartet ---");
        }
        else
        {
            abspielListe = _playlist;
            Console.WriteLine("--- Normale Wiedergabe gestartet ---");
        }

        foreach (var file in abspielListe)
        {
            file.Play();
        }
    }
}