# Random Key Validator

Herramienta de línea de comandos que genera claves aleatorias y detecta al instante si el usuario introduce un carácter de control, facilitando la validación segura de entradas en consola.

## Descripción

Random Key Validator es una solución .NET que consta de dos herramientas complementarias:

1. **Random Password Generator**: Genera contraseñas aleatorias seguras con diferentes tipos de caracteres.
2. **Control Character Detector**: Detecta si una cadena contiene caracteres de control que podrían representar riesgos de seguridad.

## Características

- Generación de contraseñas seguras con una mezcla garantizada de:
  - Letras mayúsculas y minúsculas
  - Números
  - Caracteres especiales
- Algoritmo que previene caracteres especiales consecutivos
- Detección de caracteres de control en entradas de usuario
- Decodificación de secuencias HTML para una validación más segura

## Requisitos

- .NET 9.0 o superior

## Instalación

Clone este repositorio y compile la solución:

```bash
git clone https://github.com/MateoSolano65/random_key_validator.git
cd random_key_validator
dotnet build
```

## Uso

### Generador de contraseñas

```bash
dotnet run --project ramdompassword.csproj
```

### Detector de caracteres de control

```bash
dotnet run --project IsControlCharacter/IsControlCharacter.csproj
```

Luego, introduzca la cadena que desea validar cuando se le solicite.

## Proyectos

### ramdompassword

Genera múltiples contraseñas aleatorias seguras con reglas predefinidas para asegurar su fortaleza.

### IsControlCharacter

Permite verificar si una cadena contiene caracteres de control que podrían utilizarse en ataques como inyecciones.

## Licencia

Este proyecto está licenciado bajo la [Licencia MIT](LICENSE).
