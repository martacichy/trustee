namespace BackendLibrary.DataAccess
{
    /// <summary>
    /// Klasa przetrzymująca dane połączenia z bazą danych.
    /// Dziedziczą po niej wszystkie klasy z folderu DataAccess.
    /// </summary>
    public class SqlConnector
    {
        // Dane logowania do bazy z WebApp/appsettings.json
        public static readonly string connectionString =
            "server=localhost;user id=team06;password=progzesp123;database=database06";
    }
}