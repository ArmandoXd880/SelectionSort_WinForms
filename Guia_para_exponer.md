# Guía para exponer Selection Sort con 10 números

La presentación conserva el diseño e incluye 97 diapositivas. El ejemplo ocupa 88 pasos: cada comparación, cambio de mínimo, intercambio y confirmación tiene su propia diapositiva y un texto breve para decir. El programa reproduce esos mismos 88 pasos.

## Mapa de la exposición

| Diapositivas | Contenido |
| --- | --- |
| 1-4 | Portada, teoría y origen, variables y pseudocódigo |
| 5-92 | Un solo ejemplo con 10 números, completo |
| 93 | Complejidad |
| 94 | Mejor y peor caso para 10 elementos |
| 95 | Usos y limitaciones |
| 96 | Demostración del programa |
| 97 | Fuentes |

**Entrada:** 29, 10, 14, 7, 25, 3, 18, 1, 12, 5.

**Salida:** 1, 3, 5, 7, 10, 12, 14, 18, 25, 29.

**Conteos:** 9 pasadas, 45 comparaciones y 7 intercambios reales. Actualizar min solo cambia un índice: todavía no mueve los números. El último elemento queda en su lugar automáticamente.

## Demostración

1. Extrae todo el ZIP y abre `bin/SelectionSortDemo.exe` en Windows.
2. El programa inicia con los 10 números de las diapositivas.
3. Pulsa Siguiente para avanzar una acción. Anterior regresa al estado previo. Automático permite reproducir y pausar.
4. El paso 1 del programa corresponde a la diapositiva 5. La equivalencia es: diapositiva = paso del programa + 4.
5. El programa también ordena Letras y Palabras. Puedes introducir entre 1 y 12 elementos y pulsar Cargar / reiniciar. Esas opciones no tienen ejemplos desarrollados en esta presentación.

## Cuatro ideas para recordar

- i indica el primer índice pendiente.
- j recorre lo pendiente y compara contra el mínimo provisional.
- min guarda el índice del menor encontrado, no su valor.
- La parte verde ya está en su lugar y no vuelve a participar en la búsqueda.

## Texto de apoyo de cada paso

### Diapositiva 5 / paso 1: Estado inicial

Voy a ordenar de menor a mayor. Todos los elementos empiezan en la zona pendiente.

Arreglo: 29, 10, 14, 7, 25, 3, 18, 1, 12, 5. Comparaciones: 0. Intercambios: 0.

### Diapositiva 6 / paso 2: Comienza la pasada 1

Busco desde el índice 0 (posición 1). Tomo 29 como mínimo provisional.

Arreglo: 29, 10, 14, 7, 25, 3, 18, 1, 12, 5. Comparaciones: 0. Intercambios: 0.

### Diapositiva 7 / paso 3: Comparación 1

Comparo 10 con el mínimo 29. 10 es menor. En el siguiente paso actualizo el mínimo.

Arreglo: 29, 10, 14, 7, 25, 3, 18, 1, 12, 5. Comparaciones: 1. Intercambios: 0.

### Diapositiva 8 / paso 4: Nuevo mínimo provisional

El mínimo ahora es 10. Solo cambia el índice min. Los elementos todavía no se mueven.

Arreglo: 29, 10, 14, 7, 25, 3, 18, 1, 12, 5. Comparaciones: 1. Intercambios: 0.

### Diapositiva 9 / paso 5: Comparación 2

Comparo 14 con el mínimo 10. No es menor. Conservo 10 como mínimo.

Arreglo: 29, 10, 14, 7, 25, 3, 18, 1, 12, 5. Comparaciones: 2. Intercambios: 0.

### Diapositiva 10 / paso 6: Comparación 3

Comparo 7 con el mínimo 10. 7 es menor. En el siguiente paso actualizo el mínimo.

Arreglo: 29, 10, 14, 7, 25, 3, 18, 1, 12, 5. Comparaciones: 3. Intercambios: 0.

### Diapositiva 11 / paso 7: Nuevo mínimo provisional

El mínimo ahora es 7. Solo cambia el índice min. Los elementos todavía no se mueven.

Arreglo: 29, 10, 14, 7, 25, 3, 18, 1, 12, 5. Comparaciones: 3. Intercambios: 0.

### Diapositiva 12 / paso 8: Comparación 4

Comparo 25 con el mínimo 7. No es menor. Conservo 7 como mínimo.

Arreglo: 29, 10, 14, 7, 25, 3, 18, 1, 12, 5. Comparaciones: 4. Intercambios: 0.

### Diapositiva 13 / paso 9: Comparación 5

Comparo 3 con el mínimo 7. 3 es menor. En el siguiente paso actualizo el mínimo.

Arreglo: 29, 10, 14, 7, 25, 3, 18, 1, 12, 5. Comparaciones: 5. Intercambios: 0.

### Diapositiva 14 / paso 10: Nuevo mínimo provisional

El mínimo ahora es 3. Solo cambia el índice min. Los elementos todavía no se mueven.

Arreglo: 29, 10, 14, 7, 25, 3, 18, 1, 12, 5. Comparaciones: 5. Intercambios: 0.

### Diapositiva 15 / paso 11: Comparación 6

Comparo 18 con el mínimo 3. No es menor. Conservo 3 como mínimo.

Arreglo: 29, 10, 14, 7, 25, 3, 18, 1, 12, 5. Comparaciones: 6. Intercambios: 0.

### Diapositiva 16 / paso 12: Comparación 7

Comparo 1 con el mínimo 3. 1 es menor. En el siguiente paso actualizo el mínimo.

Arreglo: 29, 10, 14, 7, 25, 3, 18, 1, 12, 5. Comparaciones: 7. Intercambios: 0.

### Diapositiva 17 / paso 13: Nuevo mínimo provisional

El mínimo ahora es 1. Solo cambia el índice min. Los elementos todavía no se mueven.

Arreglo: 29, 10, 14, 7, 25, 3, 18, 1, 12, 5. Comparaciones: 7. Intercambios: 0.

### Diapositiva 18 / paso 14: Comparación 8

Comparo 12 con el mínimo 1. No es menor. Conservo 1 como mínimo.

Arreglo: 29, 10, 14, 7, 25, 3, 18, 1, 12, 5. Comparaciones: 8. Intercambios: 0.

### Diapositiva 19 / paso 15: Comparación 9

Comparo 5 con el mínimo 1. No es menor. Conservo 1 como mínimo.

Arreglo: 29, 10, 14, 7, 25, 3, 18, 1, 12, 5. Comparaciones: 9. Intercambios: 0.

### Diapositiva 20 / paso 16: Intercambio 1

Intercambio 29 y 1. 1 queda en el índice 0 (posición 1).

Arreglo: 1, 10, 14, 7, 25, 3, 18, 29, 12, 5. Comparaciones: 9. Intercambios: 1.

### Diapositiva 21 / paso 17: Índice 0 definitivo (posición 1)

1 ya está en el índice 0 (posición 1). En las siguientes pasadas reviso lo que queda a la derecha.

Arreglo: 1, 10, 14, 7, 25, 3, 18, 29, 12, 5. Comparaciones: 9. Intercambios: 1.

### Diapositiva 22 / paso 18: Comienza la pasada 2

Busco desde el índice 1 (posición 2). Tomo 10 como mínimo provisional.

Arreglo: 1, 10, 14, 7, 25, 3, 18, 29, 12, 5. Comparaciones: 9. Intercambios: 1.

### Diapositiva 23 / paso 19: Comparación 10

Comparo 14 con el mínimo 10. No es menor. Conservo 10 como mínimo.

Arreglo: 1, 10, 14, 7, 25, 3, 18, 29, 12, 5. Comparaciones: 10. Intercambios: 1.

### Diapositiva 24 / paso 20: Comparación 11

Comparo 7 con el mínimo 10. 7 es menor. En el siguiente paso actualizo el mínimo.

Arreglo: 1, 10, 14, 7, 25, 3, 18, 29, 12, 5. Comparaciones: 11. Intercambios: 1.

### Diapositiva 25 / paso 21: Nuevo mínimo provisional

El mínimo ahora es 7. Solo cambia el índice min. Los elementos todavía no se mueven.

Arreglo: 1, 10, 14, 7, 25, 3, 18, 29, 12, 5. Comparaciones: 11. Intercambios: 1.

### Diapositiva 26 / paso 22: Comparación 12

Comparo 25 con el mínimo 7. No es menor. Conservo 7 como mínimo.

Arreglo: 1, 10, 14, 7, 25, 3, 18, 29, 12, 5. Comparaciones: 12. Intercambios: 1.

### Diapositiva 27 / paso 23: Comparación 13

Comparo 3 con el mínimo 7. 3 es menor. En el siguiente paso actualizo el mínimo.

Arreglo: 1, 10, 14, 7, 25, 3, 18, 29, 12, 5. Comparaciones: 13. Intercambios: 1.

### Diapositiva 28 / paso 24: Nuevo mínimo provisional

El mínimo ahora es 3. Solo cambia el índice min. Los elementos todavía no se mueven.

Arreglo: 1, 10, 14, 7, 25, 3, 18, 29, 12, 5. Comparaciones: 13. Intercambios: 1.

### Diapositiva 29 / paso 25: Comparación 14

Comparo 18 con el mínimo 3. No es menor. Conservo 3 como mínimo.

Arreglo: 1, 10, 14, 7, 25, 3, 18, 29, 12, 5. Comparaciones: 14. Intercambios: 1.

### Diapositiva 30 / paso 26: Comparación 15

Comparo 29 con el mínimo 3. No es menor. Conservo 3 como mínimo.

Arreglo: 1, 10, 14, 7, 25, 3, 18, 29, 12, 5. Comparaciones: 15. Intercambios: 1.

### Diapositiva 31 / paso 27: Comparación 16

Comparo 12 con el mínimo 3. No es menor. Conservo 3 como mínimo.

Arreglo: 1, 10, 14, 7, 25, 3, 18, 29, 12, 5. Comparaciones: 16. Intercambios: 1.

### Diapositiva 32 / paso 28: Comparación 17

Comparo 5 con el mínimo 3. No es menor. Conservo 3 como mínimo.

Arreglo: 1, 10, 14, 7, 25, 3, 18, 29, 12, 5. Comparaciones: 17. Intercambios: 1.

### Diapositiva 33 / paso 29: Intercambio 2

Intercambio 10 y 3. 3 queda en el índice 1 (posición 2).

Arreglo: 1, 3, 14, 7, 25, 10, 18, 29, 12, 5. Comparaciones: 17. Intercambios: 2.

### Diapositiva 34 / paso 30: Índice 1 definitivo (posición 2)

3 ya está en el índice 1 (posición 2). En las siguientes pasadas reviso lo que queda a la derecha.

Arreglo: 1, 3, 14, 7, 25, 10, 18, 29, 12, 5. Comparaciones: 17. Intercambios: 2.

### Diapositiva 35 / paso 31: Comienza la pasada 3

Busco desde el índice 2 (posición 3). Tomo 14 como mínimo provisional.

Arreglo: 1, 3, 14, 7, 25, 10, 18, 29, 12, 5. Comparaciones: 17. Intercambios: 2.

### Diapositiva 36 / paso 32: Comparación 18

Comparo 7 con el mínimo 14. 7 es menor. En el siguiente paso actualizo el mínimo.

Arreglo: 1, 3, 14, 7, 25, 10, 18, 29, 12, 5. Comparaciones: 18. Intercambios: 2.

### Diapositiva 37 / paso 33: Nuevo mínimo provisional

El mínimo ahora es 7. Solo cambia el índice min. Los elementos todavía no se mueven.

Arreglo: 1, 3, 14, 7, 25, 10, 18, 29, 12, 5. Comparaciones: 18. Intercambios: 2.

### Diapositiva 38 / paso 34: Comparación 19

Comparo 25 con el mínimo 7. No es menor. Conservo 7 como mínimo.

Arreglo: 1, 3, 14, 7, 25, 10, 18, 29, 12, 5. Comparaciones: 19. Intercambios: 2.

### Diapositiva 39 / paso 35: Comparación 20

Comparo 10 con el mínimo 7. No es menor. Conservo 7 como mínimo.

Arreglo: 1, 3, 14, 7, 25, 10, 18, 29, 12, 5. Comparaciones: 20. Intercambios: 2.

### Diapositiva 40 / paso 36: Comparación 21

Comparo 18 con el mínimo 7. No es menor. Conservo 7 como mínimo.

Arreglo: 1, 3, 14, 7, 25, 10, 18, 29, 12, 5. Comparaciones: 21. Intercambios: 2.

### Diapositiva 41 / paso 37: Comparación 22

Comparo 29 con el mínimo 7. No es menor. Conservo 7 como mínimo.

Arreglo: 1, 3, 14, 7, 25, 10, 18, 29, 12, 5. Comparaciones: 22. Intercambios: 2.

### Diapositiva 42 / paso 38: Comparación 23

Comparo 12 con el mínimo 7. No es menor. Conservo 7 como mínimo.

Arreglo: 1, 3, 14, 7, 25, 10, 18, 29, 12, 5. Comparaciones: 23. Intercambios: 2.

### Diapositiva 43 / paso 39: Comparación 24

Comparo 5 con el mínimo 7. 5 es menor. En el siguiente paso actualizo el mínimo.

Arreglo: 1, 3, 14, 7, 25, 10, 18, 29, 12, 5. Comparaciones: 24. Intercambios: 2.

### Diapositiva 44 / paso 40: Nuevo mínimo provisional

El mínimo ahora es 5. Solo cambia el índice min. Los elementos todavía no se mueven.

Arreglo: 1, 3, 14, 7, 25, 10, 18, 29, 12, 5. Comparaciones: 24. Intercambios: 2.

### Diapositiva 45 / paso 41: Intercambio 3

Intercambio 14 y 5. 5 queda en el índice 2 (posición 3).

Arreglo: 1, 3, 5, 7, 25, 10, 18, 29, 12, 14. Comparaciones: 24. Intercambios: 3.

### Diapositiva 46 / paso 42: Índice 2 definitivo (posición 3)

5 ya está en el índice 2 (posición 3). En las siguientes pasadas reviso lo que queda a la derecha.

Arreglo: 1, 3, 5, 7, 25, 10, 18, 29, 12, 14. Comparaciones: 24. Intercambios: 3.

### Diapositiva 47 / paso 43: Comienza la pasada 4

Busco desde el índice 3 (posición 4). Tomo 7 como mínimo provisional.

Arreglo: 1, 3, 5, 7, 25, 10, 18, 29, 12, 14. Comparaciones: 24. Intercambios: 3.

### Diapositiva 48 / paso 44: Comparación 25

Comparo 25 con el mínimo 7. No es menor. Conservo 7 como mínimo.

Arreglo: 1, 3, 5, 7, 25, 10, 18, 29, 12, 14. Comparaciones: 25. Intercambios: 3.

### Diapositiva 49 / paso 45: Comparación 26

Comparo 10 con el mínimo 7. No es menor. Conservo 7 como mínimo.

Arreglo: 1, 3, 5, 7, 25, 10, 18, 29, 12, 14. Comparaciones: 26. Intercambios: 3.

### Diapositiva 50 / paso 46: Comparación 27

Comparo 18 con el mínimo 7. No es menor. Conservo 7 como mínimo.

Arreglo: 1, 3, 5, 7, 25, 10, 18, 29, 12, 14. Comparaciones: 27. Intercambios: 3.

### Diapositiva 51 / paso 47: Comparación 28

Comparo 29 con el mínimo 7. No es menor. Conservo 7 como mínimo.

Arreglo: 1, 3, 5, 7, 25, 10, 18, 29, 12, 14. Comparaciones: 28. Intercambios: 3.

### Diapositiva 52 / paso 48: Comparación 29

Comparo 12 con el mínimo 7. No es menor. Conservo 7 como mínimo.

Arreglo: 1, 3, 5, 7, 25, 10, 18, 29, 12, 14. Comparaciones: 29. Intercambios: 3.

### Diapositiva 53 / paso 49: Comparación 30

Comparo 14 con el mínimo 7. No es menor. Conservo 7 como mínimo.

Arreglo: 1, 3, 5, 7, 25, 10, 18, 29, 12, 14. Comparaciones: 30. Intercambios: 3.

### Diapositiva 54 / paso 50: Sin intercambio

7 ya está al inicio de la zona pendiente. No hace falta intercambiar.

Arreglo: 1, 3, 5, 7, 25, 10, 18, 29, 12, 14. Comparaciones: 30. Intercambios: 3.

### Diapositiva 55 / paso 51: Índice 3 definitivo (posición 4)

7 ya está en el índice 3 (posición 4). En las siguientes pasadas reviso lo que queda a la derecha.

Arreglo: 1, 3, 5, 7, 25, 10, 18, 29, 12, 14. Comparaciones: 30. Intercambios: 3.

### Diapositiva 56 / paso 52: Comienza la pasada 5

Busco desde el índice 4 (posición 5). Tomo 25 como mínimo provisional.

Arreglo: 1, 3, 5, 7, 25, 10, 18, 29, 12, 14. Comparaciones: 30. Intercambios: 3.

### Diapositiva 57 / paso 53: Comparación 31

Comparo 10 con el mínimo 25. 10 es menor. En el siguiente paso actualizo el mínimo.

Arreglo: 1, 3, 5, 7, 25, 10, 18, 29, 12, 14. Comparaciones: 31. Intercambios: 3.

### Diapositiva 58 / paso 54: Nuevo mínimo provisional

El mínimo ahora es 10. Solo cambia el índice min. Los elementos todavía no se mueven.

Arreglo: 1, 3, 5, 7, 25, 10, 18, 29, 12, 14. Comparaciones: 31. Intercambios: 3.

### Diapositiva 59 / paso 55: Comparación 32

Comparo 18 con el mínimo 10. No es menor. Conservo 10 como mínimo.

Arreglo: 1, 3, 5, 7, 25, 10, 18, 29, 12, 14. Comparaciones: 32. Intercambios: 3.

### Diapositiva 60 / paso 56: Comparación 33

Comparo 29 con el mínimo 10. No es menor. Conservo 10 como mínimo.

Arreglo: 1, 3, 5, 7, 25, 10, 18, 29, 12, 14. Comparaciones: 33. Intercambios: 3.

### Diapositiva 61 / paso 57: Comparación 34

Comparo 12 con el mínimo 10. No es menor. Conservo 10 como mínimo.

Arreglo: 1, 3, 5, 7, 25, 10, 18, 29, 12, 14. Comparaciones: 34. Intercambios: 3.

### Diapositiva 62 / paso 58: Comparación 35

Comparo 14 con el mínimo 10. No es menor. Conservo 10 como mínimo.

Arreglo: 1, 3, 5, 7, 25, 10, 18, 29, 12, 14. Comparaciones: 35. Intercambios: 3.

### Diapositiva 63 / paso 59: Intercambio 4

Intercambio 25 y 10. 10 queda en el índice 4 (posición 5).

Arreglo: 1, 3, 5, 7, 10, 25, 18, 29, 12, 14. Comparaciones: 35. Intercambios: 4.

### Diapositiva 64 / paso 60: Índice 4 definitivo (posición 5)

10 ya está en el índice 4 (posición 5). En las siguientes pasadas reviso lo que queda a la derecha.

Arreglo: 1, 3, 5, 7, 10, 25, 18, 29, 12, 14. Comparaciones: 35. Intercambios: 4.

### Diapositiva 65 / paso 61: Comienza la pasada 6

Busco desde el índice 5 (posición 6). Tomo 25 como mínimo provisional.

Arreglo: 1, 3, 5, 7, 10, 25, 18, 29, 12, 14. Comparaciones: 35. Intercambios: 4.

### Diapositiva 66 / paso 62: Comparación 36

Comparo 18 con el mínimo 25. 18 es menor. En el siguiente paso actualizo el mínimo.

Arreglo: 1, 3, 5, 7, 10, 25, 18, 29, 12, 14. Comparaciones: 36. Intercambios: 4.

### Diapositiva 67 / paso 63: Nuevo mínimo provisional

El mínimo ahora es 18. Solo cambia el índice min. Los elementos todavía no se mueven.

Arreglo: 1, 3, 5, 7, 10, 25, 18, 29, 12, 14. Comparaciones: 36. Intercambios: 4.

### Diapositiva 68 / paso 64: Comparación 37

Comparo 29 con el mínimo 18. No es menor. Conservo 18 como mínimo.

Arreglo: 1, 3, 5, 7, 10, 25, 18, 29, 12, 14. Comparaciones: 37. Intercambios: 4.

### Diapositiva 69 / paso 65: Comparación 38

Comparo 12 con el mínimo 18. 12 es menor. En el siguiente paso actualizo el mínimo.

Arreglo: 1, 3, 5, 7, 10, 25, 18, 29, 12, 14. Comparaciones: 38. Intercambios: 4.

### Diapositiva 70 / paso 66: Nuevo mínimo provisional

El mínimo ahora es 12. Solo cambia el índice min. Los elementos todavía no se mueven.

Arreglo: 1, 3, 5, 7, 10, 25, 18, 29, 12, 14. Comparaciones: 38. Intercambios: 4.

### Diapositiva 71 / paso 67: Comparación 39

Comparo 14 con el mínimo 12. No es menor. Conservo 12 como mínimo.

Arreglo: 1, 3, 5, 7, 10, 25, 18, 29, 12, 14. Comparaciones: 39. Intercambios: 4.

### Diapositiva 72 / paso 68: Intercambio 5

Intercambio 25 y 12. 12 queda en el índice 5 (posición 6).

Arreglo: 1, 3, 5, 7, 10, 12, 18, 29, 25, 14. Comparaciones: 39. Intercambios: 5.

### Diapositiva 73 / paso 69: Índice 5 definitivo (posición 6)

12 ya está en el índice 5 (posición 6). En las siguientes pasadas reviso lo que queda a la derecha.

Arreglo: 1, 3, 5, 7, 10, 12, 18, 29, 25, 14. Comparaciones: 39. Intercambios: 5.

### Diapositiva 74 / paso 70: Comienza la pasada 7

Busco desde el índice 6 (posición 7). Tomo 18 como mínimo provisional.

Arreglo: 1, 3, 5, 7, 10, 12, 18, 29, 25, 14. Comparaciones: 39. Intercambios: 5.

### Diapositiva 75 / paso 71: Comparación 40

Comparo 29 con el mínimo 18. No es menor. Conservo 18 como mínimo.

Arreglo: 1, 3, 5, 7, 10, 12, 18, 29, 25, 14. Comparaciones: 40. Intercambios: 5.

### Diapositiva 76 / paso 72: Comparación 41

Comparo 25 con el mínimo 18. No es menor. Conservo 18 como mínimo.

Arreglo: 1, 3, 5, 7, 10, 12, 18, 29, 25, 14. Comparaciones: 41. Intercambios: 5.

### Diapositiva 77 / paso 73: Comparación 42

Comparo 14 con el mínimo 18. 14 es menor. En el siguiente paso actualizo el mínimo.

Arreglo: 1, 3, 5, 7, 10, 12, 18, 29, 25, 14. Comparaciones: 42. Intercambios: 5.

### Diapositiva 78 / paso 74: Nuevo mínimo provisional

El mínimo ahora es 14. Solo cambia el índice min. Los elementos todavía no se mueven.

Arreglo: 1, 3, 5, 7, 10, 12, 18, 29, 25, 14. Comparaciones: 42. Intercambios: 5.

### Diapositiva 79 / paso 75: Intercambio 6

Intercambio 18 y 14. 14 queda en el índice 6 (posición 7).

Arreglo: 1, 3, 5, 7, 10, 12, 14, 29, 25, 18. Comparaciones: 42. Intercambios: 6.

### Diapositiva 80 / paso 76: Índice 6 definitivo (posición 7)

14 ya está en el índice 6 (posición 7). En las siguientes pasadas reviso lo que queda a la derecha.

Arreglo: 1, 3, 5, 7, 10, 12, 14, 29, 25, 18. Comparaciones: 42. Intercambios: 6.

### Diapositiva 81 / paso 77: Comienza la pasada 8

Busco desde el índice 7 (posición 8). Tomo 29 como mínimo provisional.

Arreglo: 1, 3, 5, 7, 10, 12, 14, 29, 25, 18. Comparaciones: 42. Intercambios: 6.

### Diapositiva 82 / paso 78: Comparación 43

Comparo 25 con el mínimo 29. 25 es menor. En el siguiente paso actualizo el mínimo.

Arreglo: 1, 3, 5, 7, 10, 12, 14, 29, 25, 18. Comparaciones: 43. Intercambios: 6.

### Diapositiva 83 / paso 79: Nuevo mínimo provisional

El mínimo ahora es 25. Solo cambia el índice min. Los elementos todavía no se mueven.

Arreglo: 1, 3, 5, 7, 10, 12, 14, 29, 25, 18. Comparaciones: 43. Intercambios: 6.

### Diapositiva 84 / paso 80: Comparación 44

Comparo 18 con el mínimo 25. 18 es menor. En el siguiente paso actualizo el mínimo.

Arreglo: 1, 3, 5, 7, 10, 12, 14, 29, 25, 18. Comparaciones: 44. Intercambios: 6.

### Diapositiva 85 / paso 81: Nuevo mínimo provisional

El mínimo ahora es 18. Solo cambia el índice min. Los elementos todavía no se mueven.

Arreglo: 1, 3, 5, 7, 10, 12, 14, 29, 25, 18. Comparaciones: 44. Intercambios: 6.

### Diapositiva 86 / paso 82: Intercambio 7

Intercambio 29 y 18. 18 queda en el índice 7 (posición 8).

Arreglo: 1, 3, 5, 7, 10, 12, 14, 18, 25, 29. Comparaciones: 44. Intercambios: 7.

### Diapositiva 87 / paso 83: Índice 7 definitivo (posición 8)

18 ya está en el índice 7 (posición 8). En las siguientes pasadas reviso lo que queda a la derecha.

Arreglo: 1, 3, 5, 7, 10, 12, 14, 18, 25, 29. Comparaciones: 44. Intercambios: 7.

### Diapositiva 88 / paso 84: Comienza la pasada 9

Busco desde el índice 8 (posición 9). Tomo 25 como mínimo provisional.

Arreglo: 1, 3, 5, 7, 10, 12, 14, 18, 25, 29. Comparaciones: 44. Intercambios: 7.

### Diapositiva 89 / paso 85: Comparación 45

Comparo 29 con el mínimo 25. No es menor. Conservo 25 como mínimo.

Arreglo: 1, 3, 5, 7, 10, 12, 14, 18, 25, 29. Comparaciones: 45. Intercambios: 7.

### Diapositiva 90 / paso 86: Sin intercambio

25 ya está al inicio de la zona pendiente. No hace falta intercambiar.

Arreglo: 1, 3, 5, 7, 10, 12, 14, 18, 25, 29. Comparaciones: 45. Intercambios: 7.

### Diapositiva 91 / paso 87: Índice 8 definitivo (posición 9)

25 ya está en el índice 8 (posición 9). En las siguientes pasadas reviso lo que queda a la derecha.

Arreglo: 1, 3, 5, 7, 10, 12, 14, 18, 25, 29. Comparaciones: 45. Intercambios: 7.

### Diapositiva 92 / paso 88: Ordenamiento terminado

El último elemento queda en su lugar automáticamente. Terminé con 45 comparaciones y 7 intercambios.

Arreglo: 1, 3, 5, 7, 10, 12, 14, 18, 25, 29. Comparaciones: 45. Intercambios: 7.
