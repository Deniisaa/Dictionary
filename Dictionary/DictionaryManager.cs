using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Linq;
public class DictionaryManager
{
    private List<Word> dictionary;
    private List<Admin> admins;
    public DictionaryManager()
    {
        dictionary = new List<Word>();
        admins = new List<Admin>();
        LoadAdminsFromFile("admins.txt");
    }


    public void LoadAdminsFromFile(string filePath)
    {
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 2)
                {
                    string username = parts[0];
                    string password = parts[1];
                    admins.Add(new Admin(username, password));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading admins: " + ex.Message);
        }
    }



    public bool ValidateUserCredentials(string username, string password)
    {
        foreach (var admin in admins)
        {
            if (admin.ValidateCredentials(username, password))
            {
                // Add debugging statement
                Console.WriteLine($"Login attempt successful for user: {username}");
                return true;
            }
        }
        // Add debugging statement
        Console.WriteLine($"Login attempt failed for user: {username}");
        return false;
    }
    public void LoadDictionaryFromFile(string filePath)
    {
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 4)
                {
                    string name = parts[0];
                    string description = parts[1];
                    string category = parts[2];
                    string imagePath = parts[3];
                    dictionary.Add(new Word(name, description, category, imagePath));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading dictionary: " + ex.Message);
        }
    }


    public void AddWord(Word word)
    {
        dictionary.Add(word);
        SaveWordToFile(word);
    }

    public void RemoveWord(string wordName)
    {
        Word wordToRemove = dictionary.Find(w => w.Name == wordName);
        if (wordToRemove != null)
        {
            dictionary.Remove(wordToRemove);
        }
    }
    public Word FindWord(string wordName)
    {
        return dictionary.Find(w => w.Name.Equals(wordName, StringComparison.OrdinalIgnoreCase));
    }
    public List<Word> GetAllWords()
    {
        return dictionary;
    }

    public void SaveWordToFile(Word word)
    {
        try
        {
            using (StreamWriter sw = File.AppendText("words.txt"))
            {
                sw.WriteLine($"{word.Name}|{word.Description}|{word.Category}|{word.ImagePath}");
            }
            MessageBox.Show("Word saved successfully!");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error saving word to file: " + ex.Message);
        }
    }

    public List<string> GetWordsStartingWithLetter(char letter)
    {
        // Create a list to store words starting with the specified letter
        List<string> wordsStartingWithLetter = new List<string>();

        // Iterate through each word in the dictionary
        foreach (Word word in dictionary)
        {
            // Check if the word starts with the specified letter
            if (word.Name.StartsWith(letter.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                // Add the word to the list
                wordsStartingWithLetter.Add(word.Name);
            }
        }

        // Return the list of words starting with the specified letter
        return wordsStartingWithLetter;
    }

    public List<string> GetDictionaryWords()
    {
        // Extract the names of all words in the dictionary
        return dictionary.Select(word => word.Name).ToList();
    }



    // Add methods for editing words, etc.
}
