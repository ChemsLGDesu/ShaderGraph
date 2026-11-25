# Bitácora — ProyectoFinal ShaderGraph

## Contexto general
- Proyecto Unity: `ShaderGraph`
- Versión de Unity: `6000.3.23f1`
- Escena de trabajo: `Assets/Scenes/ProyectoFinal/ProyectoFinal_ShaderGraph.unity`
- Sistema de entrada activo: **New Input System** (`activeInputHandler: 1` en `ProjectSettings/ProjectSettings.asset`)
- Paquete instalado: `com.unity.inputsystem` `1.20.0`

## Avances realizados

### 1. Cámara exploradora en primera persona
Archivo creado:
- `Assets/ProyectoFinal/Scripts/ExploradorCamaraController.cs`

Componente asignado a:
- Objeto `Main Camera` de la escena `ProyectoFinal_ShaderGraph`
- Instance ID del GameObject: `-259378`
- Instance ID del componente: `-403314`

Características implementadas:
- Movimiento libre en primera persona:
  - `WASD` para desplazamiento horizontal.
  - `Shift` izquierdo para acelerar (`sprintMultiplier = 2.5`).
  - `Q` para bajar y `E` para subir (`verticalSpeed = 8.0`).
- Rotación con el ratón:
  - Cursor bloqueado al iniciar Play (`CursorLockMode.Locked`).
  - `Escape` libera el cursor.
  - Clic izquierdo vuelve a bloquearlo.
  - Límite de inclinación vertical entre `-85.0` y `85.0` grados.
- Entrada usando `UnityEngine.InputSystem`:
  - `Keyboard.current` y `Mouse.current` con comprobaciones de nulo.
  - Sin uso de la API antigua `UnityEngine.Input`, evitando `InvalidOperationException` en Play Mode.
- Estilo del código:
  - `Update()` solo llama a métodos privados:
    - `UpdateCursorState()`
    - `UpdateLookRotation()`
    - `UpdateMovement()`
  - Sin expresiones lambda.
  - Sin cadenas largas de `if-else`.
  - Todos los valores decimales con punto (`10.0f`, `0.12f`, etc.).

Valores serializados actuales del componente:
- `moveSpeed = 10.0`
- `sprintMultiplier = 2.5`
- `verticalSpeed = 8.0`
- `mouseSensitivity = 0.12`
- `minPitch = -85.0`
- `maxPitch = 85.0`

## Verificaciones realizadas
- Escena guardada correctamente.
- Compilación sin errores ni advertencias en la consola de Unity.
- Prueba en Play Mode: entrada y salida sin excepciones; consola limpia de errores y advertencias.
- Se confirmó que el componente quedó serializado en `Main Camera`.

## Restricciones acordadas para esta tarea
- No agregar modelos 3D de personaje.
- No agregar `NavMesh`.
- No agregar rutas automáticas.
- No leer otros archivos `.md` de la carpeta `Agentes` para esta tarea.

## Pendientes / próximos pasos
- Pendiente por definir según las próximas indicaciones.
