using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StudentApp;

public class Student
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public uint Mark { get; set; }
}