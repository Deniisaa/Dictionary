using System.Windows;

public class Admin
{
    public string Name { get; set; }
    public string Password { get; set; }

    // Constructor
    public Admin(string name, string password)
    {
        Name = name;
        Password = password;
    }

    // Function to validate username and password
    public bool ValidateCredentials(string enteredName, string enteredPassword)
    {
        if (Name == enteredName && Password == enteredPassword)
        {
            MessageBox.Show("Login successful!");
            return true;
        }
        else
        {
            MessageBox.Show("Invalid username or password. Please try again.");
            return false;
        }
    }
}
