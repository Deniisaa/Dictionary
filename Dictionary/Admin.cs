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
        // Remove message boxes
        return Name == enteredName && Password == enteredPassword;
    }
}
