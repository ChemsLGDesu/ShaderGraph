Crea el script `ExploradorCamaraController.cs` en `Assets/ProyectoFinal/Scripts/` y asígnalo al objeto `Main Camera` de `Assets/Scenes/ProyectoFinal/ProyectoFinal_ShaderGraph.unity` (sin agregar ningún modelo 3D de personaje, `NavMesh` ni rutas automáticas).

Requisitos técnicos y de estilo C#:
- Verifica en Project Settings qué sistema de entrada está activo en Unity 6; usa `UnityEngine.InputSystem` (`Keyboard.current` y `Mouse.current`) si el New Input System está activo, asegurando que compile y funcione sin `InvalidOperationException` en Play Mode.
- Mantén `Update()` limpio llamando únicamente a métodos privados bien definidos.
- Evita cadenas largas de `if-else` y evita expresiones lambda; usa callbacks con nombre o lógica directa.
- Formatea todos los números decimales con punto (ej. `10.0f`), nunca con coma.

Funcionalidad requerida:
- Movimiento libre en primera persona con `WASD`, `Shift` izquierdo para acelerar y `Q`/`E` para bajar/subir altura.
- Rotación con el ratón bloqueando el cursor (`CursorLockMode.Locked`) al iniciar Play, liberándolo con `Escape` y volviendo a bloquearlo al hacer clic izquierdo.
- Guarda la escena y verifica en consola de Unity que compile sin errores ni advertencias.