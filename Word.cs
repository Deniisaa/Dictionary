// Word.cs

public class Word
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string ImagePath { get; set; } // Calea către imagine

    public Word(string name, string description, string category, string imagePath)
    {
        Name = name;
        Description = description;
        Category = category;
        ImagePath = imagePath;
    }
}
