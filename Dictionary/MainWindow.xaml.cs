using System;
using System.Windows;
using System.IO;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Linq;

namespace DictionaryApp
{
    public partial class MainWindow : Window
    {
        public DictionaryManager dictionaryManager;
        public List<Word> gameWords;
        public int currentWordIndex = 0;
        public int correctGuesses = 0;
        public TextBox guessTextBox;
        public TextBlock entertainmentWordNameTextBlock;
        public TextBlock entertainmentCategoryTextBlock;
        public TextBlock entertainmentDescriptionTextBlock;
        public Image entertainmentWordImage;
        Random random = new Random();


        public MainWindow()
        {
            InitializeComponent();
            dictionaryManager = new DictionaryManager();
            LoadUserAccounts();
            LoadDictionary();
            guessTextBox = GuessTextBox;
            entertainmentWordNameTextBlock = EntertainmentWordNameTextBlock;
            entertainmentCategoryTextBlock = EntertainmentCategoryTextBlock;
            entertainmentDescriptionTextBlock = EntertainmentDescriptionTextBlock;
            entertainmentWordImage = EntertainmentWordImage;
        }





        private void LoadUserAccounts()
        {
            try
            {
                string filePath = @"C:\Users\Acasa\source\repos\Dictionary\Dictionary\admins.txt";
                dictionaryManager.LoadAdminsFromFile(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user accounts: " + ex.Message);
            }
        }





        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            if (dictionaryManager.ValidateUserCredentials(username, password))
            {
                MessageBox.Show("Login successful!");

                // Hide the login interface
                LoginInterface.Visibility = Visibility.Collapsed;

                // Show the administrative controls interface
                AdminControls.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }



        private void LoadDictionary()
        {
            try
            {
                string filePath = @"C:\Users\Acasa\source\repos\Dictionary\Dictionary\words.txt";
                dictionaryManager.LoadDictionaryFromFile(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dictionary: " + ex.Message);
            }
        }

        private void AddWordButton_Click(object sender, RoutedEventArgs e)
        {
            // Show the Word details panel
            WordDetailsPanel.Visibility = Visibility.Visible;

            // Show the text blocks and text boxes along with their labels
            txtNewWordName.Visibility = Visibility.Visible;
            txtNewWordNameLabel.Visibility = Visibility.Visible;
            txtNewWordDescription.Visibility = Visibility.Visible;
            txtNewWordDescriptionLabel.Visibility = Visibility.Visible;
            CategoryList.Visibility = Visibility.Visible;
            CategoryListLabel.Visibility = Visibility.Visible;
            btnSaveWord.Visibility = Visibility.Visible;

            // Add predefined categories to the ComboBox
            PopulateCategories();
        }

        private void btnSaveWord_Click(object sender, RoutedEventArgs e)
        {
            // Get user inputs
            string name = txtNewWordName.Text;
            string description = txtNewWordDescription.Text;

            // Check if name, description, and category are provided
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description) || CategoryList.SelectedItem == null)
            {
                MessageBox.Show("Please provide name, description, and select a category.");
                return;
            }

            // Get selected category
            string category = CategoryList.SelectedItem.ToString();

            // Prompt for image path (optional)
            string imagePath = PromptUser("Enter the image path (if available):");

            // Create a new Word object
            Word newWord = new Word(name, description, category, imagePath);

            // Add the word to the dictionary
            dictionaryManager.AddWord(newWord);

            // Notify the user
            MessageBox.Show("Word added successfully!");

            // Clear text boxes and hide controls
            txtNewWordName.Text = "";
            txtNewWordDescription.Text = "";
            CategoryList.SelectedIndex = -1;
            txtNewWordName.Visibility = Visibility.Collapsed;
            txtNewWordDescription.Visibility = Visibility.Collapsed;
            CategoryList.Visibility = Visibility.Collapsed;
            btnSaveWord.Visibility = Visibility.Collapsed;
        }





        //private void SaveWordToFile(Word word)
        //{
        //    try
        //    {
        //        // Append the word details to the text file
        //        using (StreamWriter sw = File.AppendText("words.txt"))
        //        {
        //            sw.WriteLine($"{word.Name}|{word.Description}|{word.Category}|{word.ImagePath}");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error saving word to file: " + ex.Message);
        //    }
        //}




        private void PopulateCategories()
        {
            // Clear existing items
            CategoryList.Items.Clear();

            // Add predefined categories
            CategoryList.Items.Add("Animal");
            CategoryList.Items.Add("Planet");
            CategoryList.Items.Add("Fruit");
            CategoryList.Items.Add("Literature");
            CategoryList.Items.Add("Programming Languages");
            // Add more categories as needed
        }


        private void SelectCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear existing items
            SelectCategoryComboBox.Items.Clear();

            // Add predefined categories
            SelectCategoryComboBox.Items.Add("Animal");
            SelectCategoryComboBox.Items.Add("Planet");
            SelectCategoryComboBox.Items.Add("Fruit");
            SelectCategoryComboBox.Items.Add("Literature");
            SelectCategoryComboBox.Items.Add("Programming Languages");
            // Add more categories as needed

            // Make the ComboBox visible
            SelectCategoryComboBox.Visibility = Visibility.Visible;
        }

        private void SelectCategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Retrieve the selected category
            string selectedCategory = SelectCategoryComboBox.SelectedItem as string;

            // Perform search or other actions based on the selected category
            // You can call a method to perform the search or update the UI accordingly
        }





        private void RemoveWordButton_Click(object sender, RoutedEventArgs e)
        {
            // Prompt the user to enter the word to be removed
            string wordName = PromptUser("Enter the word to remove:");

            // Remove the word from the dictionary
            dictionaryManager.RemoveWord(wordName);

            // Notify the user
            MessageBox.Show("Word removed successfully!");
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Show the login interface
            LoginInterface.Visibility = Visibility.Visible;

            // Hide the administrative controls interface
            AdminControls.Visibility = Visibility.Collapsed;
        }


        // Helper method to prompt the user for input
        private string PromptUser(string message)
        {
            return Microsoft.VisualBasic.Interaction.InputBox(message, "Input", "");
        }


        private void EditWordButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if a word is selected
            if (WordDetailsPanel.Visibility == Visibility.Visible)
            {
                // Get the selected word from the UI
                string selectedWordName = WordNameTextBlock.Text;

                // Find the word in the dictionary
                Word selectedWord = dictionaryManager.FindWord(selectedWordName);

                if (selectedWord != null)
                {
                    // Show the Word details panel
                    WordDetailsPanel.Visibility = Visibility.Visible;

                    // Show the text boxes along with their labels
                    txtNewWordNameLabel.Visibility = Visibility.Visible;
                    txtNewWordName.Visibility = Visibility.Visible;
                    txtNewWordName.Text = selectedWord.Name;

                    txtNewWordDescriptionLabel.Visibility = Visibility.Visible;
                    txtNewWordDescription.Visibility = Visibility.Visible;
                    txtNewWordDescription.Text = selectedWord.Description;

                    CategoryListLabel.Visibility = Visibility.Visible;
                    CategoryList.Visibility = Visibility.Visible;
                    CategoryList.SelectedIndex = CategoryList.Items.IndexOf(selectedWord.Category);

                    btnSaveWord.Visibility = Visibility.Visible;
                    btnSaveWord.Content = "Update";

                    // Set the focus to the Word Name text box
                    txtNewWordName.Focus();
                }
                else
                {
                    MessageBox.Show("Selected word not found in the dictionary.");
                }
            }
            else
            {
                MessageBox.Show("Please select a word to edit.");
            }
        }



        //...........................................................................................

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchWord = txtSearch.Text;
            Word foundWord = dictionaryManager.FindWord(searchWord);

            if (foundWord != null)
            {
                // Show word details grid
                WordDetailsGrid.Visibility = Visibility.Visible;

                // Update text blocks with word details
                WordNameTextBlock.Text = foundWord.Name;
                CategoryTextBlock.Text = foundWord.Category;
                DescriptionTextBlock.Text = foundWord.Description;

                // Set image source
                if (!string.IsNullOrEmpty(foundWord.ImagePath))
                {
                    WordImage.Source = new BitmapImage(new Uri(foundWord.ImagePath));
                }
                else
                {
                    // Clear image if no image path is provided
                    WordImage.Source = null;
                }
            }
            else
            {
                MessageBox.Show("Word not found in the dictionary.");
            }
        }





        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            List<string> suggestions = new List<string>();

            // Check if searchText is not empty
            if (!string.IsNullOrEmpty(searchText))
            {
                // If a category is selected, filter words based on both category and search text
                if (SelectCategoryComboBox.SelectedItem != null)
                {
                    string selectedCategory = SelectCategoryComboBox.SelectedItem.ToString();

                    // Filter words that start with the entered text and belong to the selected category
                    foreach (var word in dictionaryManager.GetWordsStartingWithLetter(searchText[0]))
                    {
                        var foundWord = dictionaryManager.FindWord(word);
                        if (foundWord != null && word.ToLower().StartsWith(searchText) && foundWord.Category == selectedCategory)
                        {
                            suggestions.Add(word);
                        }
                    }
                }
                // If no category is selected, filter words based only on the search text
                else
                {
                    foreach (var word in dictionaryManager.GetDictionaryWords())
                    {
                        if (word.ToLower().StartsWith(searchText))
                        {
                            suggestions.Add(word);
                        }
                    }
                }
            }

            // Update the ListBox with suggestions
            lstWordSuggestions.ItemsSource = suggestions;
            lstWordSuggestions.Visibility = suggestions.Count > 0 ? Visibility.Visible : Visibility.Collapsed;
        }



        private void lstWordSuggestions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // When a suggestion is selected, update the search TextBox with the selected word
            if (lstWordSuggestions.SelectedItem != null)
            {
                txtSearch.Text = lstWordSuggestions.SelectedItem.ToString();
                lstWordSuggestions.Visibility = Visibility.Collapsed;
            }
        }



        //Divertisment modul..........................................

        public void EntertainmentModule()
        {
            // Select 5 random words from the dictionary
            List<Word> dictionaryWords = dictionaryManager.GetAllWords();
            Random random = new Random();
            gameWords = dictionaryWords.OrderBy(x => random.Next()).Take(5).ToList();

            // Show the first word
            DisplayCurrentWord();
        }

        private void DisplayCurrentWord()
        {
            Random random = new Random(); // Instantiate the Random object

            if (currentWordIndex < gameWords.Count)
            {
                Word currentWord = gameWords[currentWordIndex];

                // Display word details
                WordNameTextBlock.Text = currentWord.Name;
                CategoryTextBlock.Text = currentWord.Category;

                if (currentWordIndex == 4)
                {
                    // Change the "Next" button to "Finish" for the last word
                    NextButton.Content = "Finish";
                }
                else
                {
                    NextButton.Content = "Next";
                }

                if (currentWord.ImagePath != null && random.Next(2) == 0)
                {
                    // Display word image
                    WordImage.Source = new BitmapImage(new Uri(currentWord.ImagePath));
                    DescriptionTextBlock.Visibility = Visibility.Collapsed;
                    WordImage.Visibility = Visibility.Visible;
                }
                else
                {
                    // Display word description
                    DescriptionTextBlock.Text = currentWord.Description;
                    DescriptionTextBlock.Visibility = Visibility.Visible;
                    WordImage.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                // Game over, show results
                MessageBox.Show($"Game Over! You guessed {correctGuesses} out of 5 words correctly.");
                // Reset game state
                currentWordIndex = 0;
                correctGuesses = 0;
            }
        }


        public void NextButton_Click(object sender, RoutedEventArgs e)
        {
            // Check user input against the correct word
            if (currentWordIndex < gameWords.Count)
            {
                Word currentWord = gameWords[currentWordIndex];
                string userInput = GuessTextBox.Text.Trim();

                if (string.Equals(userInput, currentWord.Name, StringComparison.OrdinalIgnoreCase))
                {
                    correctGuesses++;
                }
            }

            // Move to the next word
            currentWordIndex++;
            DisplayCurrentWord();
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            // Move to the previous word if not at the beginning
            if (currentWordIndex > 0)
            {
                currentWordIndex--;
                DisplayCurrentWord();
            }
        }
    }


}
