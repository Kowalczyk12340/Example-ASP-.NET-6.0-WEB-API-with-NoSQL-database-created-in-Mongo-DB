using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NotebookAPI.Model
{
  public class Note
  {
    [BsonId]
    public ObjectId InternalId { get; set; }

    public string Id { get; set; }
    public string Body { get; set; } = string.Empty;

    [BsonDateTimeOptions]
    public DateTime UpdatedOn { get; set; } = DateTime.Now;

    public NoteImage HeaderImage { get; set; }
    public int UserId { get; set; } = 0;
  }
}