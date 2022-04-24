using NotebookAPI.Model;

namespace NotebookAPI.Interfaces
{
  public interface INoteRepository
  {
    Task<IEnumerable<Note>> GetAllNotes();
    Task<Note> GetNote(string id);
    Task<IEnumerable<Note>> GetNote(string bodyText, DateTime updatedForm, long headerSizeLimit);
    Task AddNote(Note item);
    Task<bool> RemoveNote(string id);
    Task<bool> UpdateNote(string id, string body);
    Task<bool> UpdateNote(string id, Note item);
    Task<bool> UpdateNoteDocument(string id, string body);
    Task<bool> RemoveAllNotes();
    Task<string> CreateIndex();
  }
}