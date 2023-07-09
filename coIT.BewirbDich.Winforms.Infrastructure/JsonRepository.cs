using System.Text;
using System.Text.Json;

namespace coIT.BewirbDich.Winforms.Infrastructure;

/// <summary>
/// Bietet Methoden zum Verwalten von serialisierten Datenbest�nden.
/// </summary>
/// <typeparam name="T">Die Klasse (Typ), die den Eintr�gen im Datenbestand entspricht.</typeparam>
public class JsonRepository<T> : IRepository<T> where T : class
{
    private readonly string _file;
    private List<T> _entries;

    /// <summary>
    /// Erstellt eine neue Instanz dieser Klasse und l�dt den in der angegebenen Datei befindlichen Datenbestand.
    /// </summary>
    /// <param name="file">Der Pfad zu der Datei, die den Datenbestand vom Typ <see cref="T"/> enth�lt.</param>
    public JsonRepository(string file)
    {
        _file = file;
        Load();
    }

    /// <summary>
    /// Deserialisiert und l�dt alle Eintr�ge aus der <see cref="_file"/> Datei.
    /// Wenn die Datei nicht vorhanden ist, wird diese ohne Eintr�ge neu erstellt.
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
    /// Sucht einen Eintrag im Datenbestand, welches dem angegebenen Pr�dikat entspricht.
    /// </summary>
    /// <param name="predicate">Das Pr�dikat.</param>
    /// <returns>Der gefundene Eintrag, oder null.</returns>
    public T? Find(Func<T, bool> predicate)
    {
        return _entries.SingleOrDefault(predicate);
    }

    /// <summary>
    /// Gibt eine Iterationsliste aller Eintr�ge zur�ck.
    /// </summary>
    /// <returns>Alle Eintr�ge, oder eine leere Liste.</returns>
    public IEnumerable<T> ToList()
    {
        return _entries;
    }

    /// <summary>
    /// F�gt einen neuen Eintrag zum Datenbestand hinzu.
    /// </summary>
    /// <param name="entry">Eine Instanz vom Typ <see cref="T"/>, die als Eintrag hinzugef�gt werden soll.</param>
    public void Add(T entry)
    {
        _entries.Add(entry);
    }

    /// <summary>
    /// Serialisiert und Speichert alle Eintr�ge in eine Datei.
    /// </summary>
    public void Save()
    {
        var json = JsonSerializer.Serialize(_entries);
        File.WriteAllText(_file, json, new UTF8Encoding());
    }
}