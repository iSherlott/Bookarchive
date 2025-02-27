using System.Linq;

namespace Core.Entities
{
    
    public class BooksEntity 
    {
        public BooksEntity() { }
        public void AddBooks(string[] newBooks) 
        {
            this.Name = Name.Concat(newBooks).ToArray();
        }
        public void AddBooks(string newBook)
        {
            this.Name = Name.Append(newBook).ToArray();
        }
        public void RemoveBook(string bookToRemove, bool caseSensitive = false)
        {
            if (Name == null || Name.Length == 0 || string.IsNullOrWhiteSpace(bookToRemove)) return;

            Name = caseSensitive
                ? Name.Where(name => !name.Equals(bookToRemove)).ToArray() 
                : Name.Where(name => !name.Equals(bookToRemove, StringComparison.OrdinalIgnoreCase)).ToArray();
        }

        public string[] Name { get; set; }
        
    }

}