namespace coIT.BewirbDich.Winforms.Infrastructure;

/// <summary>
/// Bietet Methoden zum Verwalten von Datenbeständen.
/// </summary>
/// <typeparam name="T">Die Klasse (Typ), die den Einträgen im Datenbestand entspricht.</typeparam>
public interface IRepository<T> where T : class
{
    /// <summary>
    /// Sucht einen Eintrag im Datenbestand, welches dem angegebenen Prädikat entspricht.
    /// </summary>
    /// <param name="predicate">Das Prädikat.</param>
    /// <returns>Der gefundene Eintrag, oder null.</returns>
    T? Find(Func<T, bool> predicate);
    
    /// <summary>
    /// Gibt eine Iterationsliste aller Einträge zurück.
    /// </summary>
    /// <returns>Alle Einträge, oder eine leere Liste.</returns>
    IEnumerable<T> ToList();
    
    /// <summary>
    /// Fügt einen neuen Eintrag zum Datenbestand hinzu.
    /// </summary>
    /// <param name="entry">Eine Instanz vom Typ <see cref="T"/>, die als Eintrag hinzugefügt werden soll.</param>
    void Add(T entry);
    
    /// <summary>
    /// Speichert alle Einträge des Datenbestands.
    /// </summary>
    void Save();
}