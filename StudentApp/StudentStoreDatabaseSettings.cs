namespace StudentApp;

public class StudentStoreDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string StudentsCollectionName { get; set; } = null!;
}