using System.Text;
using System.Text.Json;

namespace coIT.BewirbDich.Winforms.Infrastructure;

/// <summary>
/// Bietet Methoden zum Verwalten von serialisierten Datenbeständen.
/// </summary>
/// <typeparam name="T">Die Klasse (Typ), die den Einträgen im Datenbestand entspricht.</typeparam>
public class JsonRepository<T> : IRepository<T> where T : class
{
    private readonly string _file;
    private List<T> _entries;

    /// <summary>
    /// Erstellt eine neue Instanz dieser Klasse und lädt den in der angegebenen Datei befindlichen Datenbestand.
    /// </summary>
    /// <param name="file">Der Pfad zu der Datei, die den Datenbestand vom Typ <see cref="T"/> enthält.</param>
    public JsonRepository(string file)
    {
        _file = file;
        Load();
    }

    /// <summary>
    /// Deserialisiert und lädt alle Einträge aus der <see cref="_file"/> Datei.
    /// Wenn die Datei nicht vorhanden ist, wird diese ohne Einträge neu erstellt.
    /// </summary>
    private void Load()
    {
        if (!File.Exists(_file))
        {
            var empty = Enumerable.Empty<T>();
            File.WriteAllText(_file, JsonSerializer.Serialize(empty), Encoding.UTF8);
        }

        var json = File.ReadAllText(_file, Encoding.UTF8);
        _entries = JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
    }

    /// <summary>
    /// Sucht einen Eintrag im Datenbestand, welches dem angegebenen Prädikat entspricht.
    /// </summary>
    /// <param name="predicate">Das Prädikat.</param>
    /// <returns>Der gefundene Eintrag, oder null.</returns>
    public T? Find(Func<T, bool> predicate)
    {
        return _entries.SingleOrDefault(predicate);
    }

    /// <summary>
    /// Gibt eine Iterationsliste aller Einträge zurück.
    /// </summary>
    /// <returns>Alle Einträge, oder eine leere Liste.</returns>
    public IEnumerable<T> ToList()
    {
        return _entries;
    }

    /// <summary>
    /// Fügt einen neuen Eintrag zum Datenbestand hinzu.
    /// </summary>
    /// <param name="entry">Eine Instanz vom Typ <see cref="T"/>, die als Eintrag hinzugefügt werden soll.</param>
    public void Add(T entry)
    {
        _entries.Add(entry);
    }

    /// <summary>
    /// Serialisiert und Speichert alle Einträge in eine Datei.
    /// </summary>
    public void Save()
    {
        var json = JsonSerializer.Serialize(_entries);
        File.WriteAllText(_file, json, new UTF8Encoding());
    }
}