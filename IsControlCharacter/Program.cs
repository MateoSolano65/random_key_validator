// Verificar si es caracter de control o no depende el codigo que ingrese el usuario
using System.Text.RegularExpressions;

static bool IsControlCharacter(string password)
{
  // Primero, convertimos las secuencias HTML (como &#6;) en caracteres reales
  string decodedPassword = DecodeHtmlEntities(password);

  // Recorremos cada carácter de la contraseña decodificada
  foreach (char c in decodedPassword)
  {
    // Verifica si el carácter es un carácter de control
    if (char.IsControl(c))
    {
      return true; // Si se encuentra un carácter de control, retorna true
    }
  }
  return false; // Si no se encuentra ningún carácter de control, retorna false
}

// Función para decodificar las secuencias HTML (como &#6;)
static string DecodeHtmlEntities(string input)
{
  // Usamos una expresión regular para encontrar las secuencias &#; y convertirlas
  return Regex.Replace(input, @"&#(\d+);?", match => ((char)int.Parse(match.Groups[1].Value)).ToString());
}


// Pedirle al usuario que ingrese la contraseña
Console.WriteLine("Ingrese la contraseña: ");
string password = Console.ReadLine() ?? "";

// Verificar si la contraseña contiene caracteres de control
if (IsControlCharacter(password))
{
  Console.WriteLine("La contraseña contiene caracteres de control.");
}
else
{
  Console.WriteLine("La contraseña no contiene caracteres de control.");
}
