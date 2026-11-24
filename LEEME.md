# Selection Sort paso a paso

Aplicación en C# con Windows Forms para una exposición de Estructura de Datos.

## Abrir el programa

1. Extrae TODO el ZIP en una carpeta. No lo ejecutes dentro del ZIP.
2. Abre `bin/SelectionSortDemo.exe` con doble clic en Windows.
3. Requiere .NET Framework 4.8 o 4.8.1, incluido en versiones recientes de Windows 10/11.

El ejecutable fue compilado con las referencias oficiales de .NET Framework 4.8. Se verificó el motor del algoritmo con pruebas automatizadas en Linux. La ventana gráfica todavía debe probarse en tu PC con Windows antes de exponer.

## Modificar en Visual Studio

1. Abre `SelectionSort_WinForms.sln`.
2. Si faltan componentes, instala la carga de trabajo «Desarrollo de escritorio de .NET» y el paquete de destino de .NET Framework 4.8.
3. Pulsa F5. No necesitas arrastrar controles ni crear un diseñador: `MainForm.cs` construye la ventana.

Si no usas Visual Studio, `COMPILAR.bat` intenta compilar con el compilador de .NET Framework instalado en Windows. El resultado se guarda en `bin`.

## Uso durante la exposición

1. Al abrir se carga el ejemplo de 10 números de la presentación: 29, 10, 14, 7, 25, 3, 18, 1, 12, 5.
   El ejemplo tiene 88 pasos y termina con 45 comparaciones y 7 intercambios.
   Los pasos del programa y las diapositivas 5 a 92 coinciden.
   Letras y Palabras también funcionan y conservan sus propios ejemplos.
2. `Siguiente` muestra UNA acción. `Anterior` vuelve a una copia del estado previo.
3. Lee la explicación debajo del arreglo. La línea de pseudocódigo se resalta.
4. `Automático` avanza con la pausa elegida, en milisegundos. Puedes pausarlo.
5. Para tus propios datos, escribe de 1 a 12 elementos y pulsa `Cargar / reiniciar`. Si editas el texto, el recorrido anterior se descarta para evitar confusiones.

Los números son enteros de 32 bits, admiten negativos y repetidos. Letras admite una letra por elemento. Palabras admite de 1 a 14 letras por elemento, sin espacios internos. Separa los elementos con comas o espacios. Texto usa comparación de español de México sin distinguir mayúsculas. Los ejemplos sin acentos dan el mismo resultado en ambos materiales.

## Colores y variables

- Verde (ORD): posición definitiva.
- Amarillo (MIN): mínimo provisional. Actualizar `min` no mueve el arreglo.
- Azul (J): elemento que se compara contra el mínimo.
- Rosa (CAMBIO): las dos posiciones después de un intercambio.
- Gris: zona pendiente.

`i`: primera posición pendiente. `j`: posición que recorre la zona pendiente. `min`: índice del menor encontrado hasta el momento. En el código los índices comienzan en cero. Las diapositivas también indican la posición humana, desde uno.

## Archivos principales

- `SelectionEngine.cs`: comparación, validación y registro de cada acción.
- `MainForm.cs`: controles, colores, navegación y temporizador.
- `Program.cs`: punto de entrada.
- `SelectionSort_WinForms.csproj` y `.sln`: proyecto para Visual Studio.

El motor de demostración calcula y guarda los estados antes de reproducirlos. Por eso el historial ocupa memoria adicional (hasta O(n³) en caracteres/referencias de instantáneas, para n elementos y O(n²) eventos). El algoritmo Selection Sort normal, sin guardar historial, usa O(1) de memoria auxiliar. El límite de 12 elementos mantiene la demostración legible y pequeña. Los 10 números se muestran en una fila. Si los datos son largos o la ventana es pequeña, usa la barra de desplazamiento horizontal.

## Núcleo del algoritmo (la versión normal)

```csharp
for (int i = 0; i < a.Length - 1; i++)
{
    int min = i;
    for (int j = i + 1; j < a.Length; j++)
        if (a[j] < a[min])
            min = j;
    if (min != i)
    {
        int temp = a[i];
        a[i] = a[min];
        a[min] = temp;
    }
}
```

Esta condición evita intercambios de una posición consigo misma. Con n elementos hay n(n−1)/2 comparaciones, entre 0 y n−1 intercambios reales y n−1 pasadas. El tiempo es Θ(n²) en mejor, promedio y peor caso. La versión por intercambios no es estable.

## Fuentes

- NIST, definición y propiedades: https://xlinux.nist.gov/dads/HTML/selectionSort.html
- Sedgewick y Wayne, explicación del algoritmo: https://algs4.cs.princeton.edu/21elementary/
- Microsoft, compilador de C#: https://learn.microsoft.com/dotnet/csharp/language-reference/compiler-options/
- Microsoft, .NET Framework en Windows: https://learn.microsoft.com/dotnet/framework/install/on-windows-and-server
