using System;
using System.Collections.Generic;
using System.Globalization;

namespace SelectionSortDemo
{
    // Cada Step guarda una copia del arreglo para poder avanzar y retroceder.
    public sealed class Step
    {
        public string[] Values;
        public string Kind;
        public int I, J, Min, Sorted, Comparisons, Swaps, Line;
        public string Title, Message;
    }

    public static class SelectionEngine
    {
        public const string NumberExample = "29, 10, 14, 7, 25, 3, 18, 1, 12, 5";
        public static readonly CompareInfo Spanish = CultureInfo.GetCultureInfo("es-MX").CompareInfo;

        public static string[] Parse(string input, int mode)
        {
            // Las comas y los espacios separan elementos. Los números son enteros.
            string[] values = input.Split(new char[] { ',', ';', ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            if (values.Length < 1 || values.Length > 12)
                throw new ArgumentException("Escribe de 1 a 12 elementos separados por comas o espacios.");
            for (int i = 0; i < values.Length; i++)
            {
                if (mode == 0)
                {
                    int number;
                    if (!int.TryParse(values[i], NumberStyles.Integer, CultureInfo.InvariantCulture, out number))
                        throw new ArgumentException("En modo Números solo se admiten enteros de 32 bits. Ejemplo: 29, 10, 14, 7.");
                    values[i] = number.ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    if (mode == 1 && values[i].Length != 1)
                        throw new ArgumentException("En modo Letras escribe una sola letra por elemento. Ejemplo: C, A, B.");
                    for (int k = 0; k < values[i].Length; k++)
                        if (!char.IsLetter(values[i][k]))
                            throw new ArgumentException("Letras y palabras solo admiten caracteres alfabéticos. Las palabras no llevan espacios internos.");
                    if (values[i].Length > 14)
                        throw new ArgumentException("Usa palabras de hasta 14 letras para que se vean completas.");
                }
            }
            return values;
        }

        public static int Compare(string a, string b, int mode)
        {
            if (mode == 0) return int.Parse(a, CultureInfo.InvariantCulture).CompareTo(int.Parse(b, CultureInfo.InvariantCulture));
            // Orden de diccionario en español, sin distinguir mayúsculas.
            // Si dos claves son iguales, conservamos el mínimo ya encontrado.
            return Spanish.Compare(a, b, CompareOptions.IgnoreCase);
        }

        public static List<Step> Build(string[] input, int mode)
        {
            if (input == null || input.Length == 0) throw new ArgumentException("El arreglo debe contener elementos.");
            string[] a = (string[])input.Clone();
            List<Step> steps = new List<Step>();
            int comparisons = 0, swaps = 0;
            Add(steps, a, "Initial", -1, -1, -1, 0, 0, 0, 0,
                "Estado inicial", mode == 0 ? "Voy a ordenar de menor a mayor. Todos los elementos empiezan en la zona pendiente."
                    : mode == 1 ? "Ordeno las letras alfabéticamente, sin distinguir mayúsculas y minúsculas."
                    : "Ordeno las palabras como en un diccionario en español, sin distinguir mayúsculas y minúsculas.");
            for (int i = 0; i < a.Length - 1; i++)
            {
                int min = i;
                Add(steps, a, "Select", i, -1, min, i, comparisons, swaps, 1,
                    "Comienza la pasada " + (i + 1), "Busco desde el índice " + i + " (posición " + (i + 1) + "). Tomo " + a[min] + " como mínimo provisional.");
                for (int j = i + 1; j < a.Length; j++)
                {
                    bool smaller = Compare(a[j], a[min], mode) < 0;
                    comparisons++;
                    Add(steps, a, "Compare", i, j, min, i, comparisons, swaps, 3,
                        "Comparación " + comparisons,
                        "Comparo " + a[j] + " con el mínimo " + a[min] + ". " +
                        (smaller ? a[j] + " es menor. En el siguiente paso actualizo el mínimo." : "No es menor. Conservo " + a[min] + " como mínimo."));
                    if (smaller)
                    {
                        min = j;
                        Add(steps, a, "NewMinimum", i, j, min, i, comparisons, swaps, 4,
                            "Nuevo mínimo provisional", "El mínimo ahora es " + a[min] + ". Solo cambia el índice min. Los elementos todavía no se mueven.");
                    }
                }
                if (min != i)
                {
                    string old = a[i], chosen = a[min];
                    string temp = a[i]; a[i] = a[min]; a[min] = temp;
                    swaps++;
                    Add(steps, a, "Swap", i, min, min, i, comparisons, swaps, 6,
                        "Intercambio " + swaps, "Intercambio " + old + " y " + chosen + ". " + chosen + " queda en el índice " + i + " (posición " + (i + 1) + ").");
                }
                else
                    Add(steps, a, "NoSwap", i, -1, min, i, comparisons, swaps, 5,
                        "Sin intercambio", a[i] + " ya está al inicio de la zona pendiente. No hace falta intercambiar.");
                Add(steps, a, "Fix", i, -1, -1, i + 1, comparisons, swaps, 7,
                    "Índice " + i + " definitivo (posición " + (i + 1) + ")", a[i] + " ya está en el índice " + i + " (posición " + (i + 1) + "). En las siguientes pasadas reviso lo que queda a la derecha.");
            }
            Add(steps, a, "Done", -1, -1, -1, a.Length, comparisons, swaps, 8,
                "Ordenamiento terminado", "El último elemento queda en su lugar automáticamente. Terminé con " + comparisons + " comparaciones y " + swaps + " intercambios.");
            return steps;
        }

        private static void Add(List<Step> steps, string[] a, string kind, int i, int j, int min,
            int sorted, int comparisons, int swaps, int line, string title, string message)
        {
            steps.Add(new Step { Values = (string[])a.Clone(), Kind = kind, I = i, J = j, Min = min,
                Sorted = sorted, Comparisons = comparisons, Swaps = swaps, Line = line, Title = title, Message = message });
        }
    }
}
