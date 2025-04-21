// See https://aka.ms/new-console-template for more information
using System.Text;
using System.Text.RegularExpressions;

// Console.WriteLine("Hello, World!");


static string GenerateRandomPassword(int length)
{
  string caracteres = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ1234567890#%$!@&()?¡*";
  StringBuilder res = new();
  Random rnd = new();

  // Añade al menos un número, una mayúscula, una minúscula y un carácter especial

  res.Append(caracteres[rnd.Next(50, 59)]); // Añade un número
  res.Append(caracteres[rnd.Next(25, 49)]); // Añade una mayúscula
  res.Append(caracteres[rnd.Next(0, 24)]); // Añade una minúscula
  res.Append(caracteres[rnd.Next(60, caracteres.Length)]); // Añade un carácter especial

  // Resta 4 del length porque ya hemos añadido 4 caracteres específicos
  length -= 4;

  bool lastWasSpecial = false;

  // Añade caracteres aleatorios hasta completar la longitud requerida
  while (0 < length--)
  {
    char newChar = caracteres[rnd.Next(caracteres.Length)];


    if (IsSpecialCharacter(newChar) && lastWasSpecial)
    {
      length++;
      continue;
    }

    res.Append(newChar);
    lastWasSpecial = IsSpecialCharacter(newChar);
  }

  /* Mezcla la cadena resultante para asegurar que los
  caracteres específicos no están en las primeras posiciones*/
  string password;
  do
  {
    password = ShuffleString(res.ToString());
  } while (ContainsConsecutiveSpecialCharacters(password)); // Asegúrate de que no haya caracteres especiales consecutivos

  return password;
}

static string ShuffleString(string input)
{
  Random rnd = new Random();
  char[] characters = input.ToCharArray();

  for (int i = characters.Length - 1; i > 0; i--)
  {
    int j = rnd.Next(i + 1);
    char temp = characters[i];
    characters[i] = characters[j];
    characters[j] = temp;
  }

  return new string(characters);
}

/// <summary>
/// Checks if the password contains consecutive special characters
/// </summary>
/// <param name="password">The password to check</param>
/// <returns>True if consecutive special characters are found, otherwise false</returns>
static bool ContainsConsecutiveSpecialCharacters(string password)
{
  bool previousWasSpecial = false;

  foreach (char c in password)
  {
    bool currentIsSpecial = IsSpecialCharacter(c);

    if (currentIsSpecial && previousWasSpecial)
      return true; // Found two consecutive special characters

    previousWasSpecial = currentIsSpecial;
  }

  return false; // No consecutive special characters found
}

static bool IsSpecialCharacter(char c)
{
  // Define los caracteres especiales que deseas permitir
  string specialChars = "#%$!@&()?¡*";
  return specialChars.Contains(c);
}


const int numeroIteraciones = 100;

for (int i = 0; i < numeroIteraciones; i++)
{
  Console.WriteLine("<li>" + GenerateRandomPassword(8) + "</li>");
}


