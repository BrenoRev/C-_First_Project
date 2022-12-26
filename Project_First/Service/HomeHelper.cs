namespace Project_First.Service;

public class HomeHelper
{
    public string hashPassword(string password)
    {
        int passwordLength = password.Length;
        for(int index = 0; index < passwordLength; index++)
        {
            password = password.Replace(password[index], (char)(password[index] + 1));
        }

        return password;
    }
}