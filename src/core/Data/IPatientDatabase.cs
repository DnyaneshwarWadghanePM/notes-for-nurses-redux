namespace Edward.Wilde.Note.For.Nurses.Core.Data
{
    using Edward.Wilde.Note.For.Nurses.Core.Model;
    using Edward.Wilde.Note.For.Nurses.Core.Xamarin.Data;

    using SQLite;

    /// <summary>
    /// Patient database, responsible for retrieving and updating all entities in the application which
    /// are persisted in the <see cref="SQLiteConnection"/> database.
    /// </summary>
    public interface IPatientDatabase : IXamarinDatabase
    {
        /// <summary>
        /// Gets the Patient
        /// </summary>
        Patient GetPatient(int id);
    }
}