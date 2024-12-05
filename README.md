# Arquitectura Hexagonal Genérica en .NET 8

Este proyecto implementa una arquitectura hexagonal genérica utilizando .NET 8. El objetivo principal de esta arquitectura es proporcionar una base reutilizable y flexible para que otros desarrolladores puedan adaptarla a sus necesidades específicas. La organización está dividida en capas claras que separan las responsabilidades de manera profesional y escalable.

---

## Estructura del Proyecto

### 1. **Capa de Domain**
La capa de **Domain** es el corazón de la arquitectura, donde se define la lógica de negocio y las reglas que rigen el sistema. Esta capa es totalmente independiente de las tecnologías externas y contiene:

- **Entidades:** Representan los objetos principales del dominio.
- **Modelos:** Definen la estructura de los datos del dominio que son utilizados por las entidades y otros componentes.
- **Interfaces:** Definen contratos que deben ser implementados por las capas externas (como repositorios o servicios).
- **Agregados:** Se utiliza para agrupar lógicas relacionadas dentro del dominio, si es necesario.
- **DTOs:** Objetos de transferencia de datos para manejar la información que viaja entre las capas.
- **Mappers:** Utilizados para transformar datos entre entidades, modelos y DTOs.
- **Handler de Errores:** Una clase genérica para gestionar errores de forma centralizada, asegurando que las respuestas sean consistentes y claras.

### 2. **Capa de Application**
La capa de **Application** actúa como intermediaria entre el dominio y la infraestructura. Aquí es donde se implementa la lógica de negocio definida en la capa de dominio. Incluye:

- **Casos de Uso:** Los casos de uso se implementan para ejecutar tareas específicas del negocio, como operaciones CRUD.
- **Servicios de Aplicación:** Para coordinar la interacción entre los casos de uso y las dependencias externas.

Esta capa también aplica los principios de inyección de dependencias para desacoplar la lógica de negocio de las implementaciones concretas.

### 3. **Capa de Infrastructure**
La capa de **Infrastructure** maneja todas las configuraciones y la interacción con los recursos externos. Contiene:

- **Repositorios:** Implementaciones concretas para interactuar con la base de datos.
- **Configuraciones:** Configuración de la base de datos, ORM (Entity Framework Core), mapeos y dependencias.
- **Controladores de la API:** Aunque están en la misma capa, los controladores se encuentran separados dentro de un submódulo para mantener la organización.

---

## Características Principales

1. **Reutilización y Flexibilidad:** Diseño genérico que permite implementar nuevos dominios y casos de uso con facilidad.
2. **Separación de Responsabilidades:** Cada capa tiene un rol definido, reduciendo el acoplamiento entre componentes.
3. **Soporte para Operaciones CRUD:** Ejemplo implementado para un cliente, que incluye controladores, casos de uso y repositorios para realizar operaciones básicas.
4. **Manejo de Errores Centralizado:** Mejora la experiencia de desarrollo y el manejo de excepciones.
5. **Mapeos Consistentes:** Los mappers garantizan que los datos fluyan correctamente entre DTOs, entidades y modelos.

---

## Uso del Proyecto

1. **Clonar el Repositorio**

   ```bash
   git clone https://github.com/JesusJs/Arquitectura-Hexagonal-Generica-Net-8.git
   ```

2. **Configurar el Archivo `HexagonalAppContext`**
   Asegúrate de configurar la cadena de conexión a la base de datos en el archivo `HexagonalAppContext`:

   ```json
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
      optionsBuilder.UseSqlServer(@"Server=LOCALHOST;Initial Catalog=GenericDB; Integrated Security=true;Trust Server Certificate=true");
   }
   ```

3. **Ejecutar Migraciones**
   Aplica las migraciones para configurar la base de datos:

   ```bash
   dotnet ef database update
   ```

4. **Ejecutar la Aplicación**
   Ejecuta el proyecto y accede a los endpoints generados.

   ```bash
   dotnet run
   ```

---

## Futuras Extensiones
El diseño genérico permite agregar nuevas funcionalidades sin comprometer la arquitectura. Algunas ideas incluyen:

- Soporte para múltiples dominios.
- Ampliación de los controladores para incluir autenticación y autorización.
- Integración con servicios externos como colas de mensajes o APIs de terceros.
- Configurar la arquitectura que se adapte a tus necesidades.
![image](https://github.com/user-attachments/assets/b279b492-a080-4e4d-b8f8-ef70eda11a19)

