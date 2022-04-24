using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NotebookAPI.Model;

namespace NotebookAPI.Data
{
  public class NoteContext
  {
    private readonly IMongoDatabase _database;

    public NoteContext(IOptions<Settings> settings)
    {
      var client = new MongoClient(settings.Value.ConnectionString);
      if (client != null)
      {
        _database = client.GetDatabase(settings.Value.Database);
      }
    }

    public IMongoCollection<Note> Notes
    {
      get
      {
        return _database.GetCollection<Note>("Note");
      }
    }
  }
}