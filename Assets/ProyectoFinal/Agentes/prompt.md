# Tarea: Migración, Creación de Shader Graphs y Cámara Exploradora en `ProyectoFinal_ShaderGraph`

## 1. Contexto de Escena (Ya creada y limpia)
Trabaja directamente sobre la escena ya existente y limpia en:
`Assets/Scenes/ProyectoFinal/ProyectoFinal_ShaderGraph.unity`

**Regla importante:** NO dupliques `Adventure_Island_Flythrough` ni borres los grupos actuales de la jerarquía (`Main Camera`, `Island Level`, `Lighting`, `FX`, `Audio`, `3DSkybox`, `Sky`). La escena ya fue depurada manualmente; céntrate en auditar, consolidar y mejorar los shaders, materiales, texturas, el plano de agua y la cámara exploradora.

---

## 2. Auditoría del Proyecto y Documento de Estudio (`.md`)
Antes de crear o copiar archivos, inspecciona todo el proyecto con Unity MCP y genera un documento técnico en `Assets/ProyectoFinal/Agentes/Analisis_ShaderGraph.md` (y muéstrame un resumen en chat) con:
1. **Inventario completo de recursos relacionados con la escena**:
   - Todos los `.shadergraph` y `.shadersubgraph` ya existentes en el proyecto que estén vinculados o relacionados con la isla, casas de playa, rocas, terreno, vegetación o agua (con sus **rutas exactas** para poder estudiarlos).
   - Todos los materiales (`.mat`) y **todos los tipos de mapas de texturas** asociados a los objetos de esta escena (`Albedo/BaseMap`, `Normal Map`, `MaskMap`, `Metallic`, `Smoothness`, `Ambient Occlusion (AO)`, `Height/Displacement`, `Emission` y `Detail Maps`).
2. **Justificación técnica (`Lit` vs `Unlit`)**: Explica qué shaders existentes reutilizaste/adaptaste y cuáles creaste nuevos usando **URP Lit Shader Graph** frente a **URP Unlit Shader Graph**, detallando el porqué de cada elección.

---

## 3. Consolidación y Migración a `Assets/ProyectoFinal/` (Obligatorio)
Busca **todos los recursos existentes en el proyecto que se usen o estén relacionados con los objetos de `ProyectoFinal_ShaderGraph.unity`** (tanto los que ya existían en el proyecto como los nuevos que vayas a crear) y **cópialos dentro de las carpetas de `Assets/ProyectoFinal/`** (sin arrastrar basura o assets de otras escenas que no se usen aquí):
- `Assets/ProyectoFinal/ShaderGraphs/` -> Copia aquí **todos los `.shadergraph` existentes en el proyecto relacionados con la escena** + los nuevos `.shadergraph` que crees.
- `Assets/ProyectoFinal/SubsShaders/` -> Copia aquí **todos los `.shadersubgraph` existentes relacionados** + los nuevos `.shadersubgraph` auxiliares que crees.
- `Assets/ProyectoFinal/Materiales/` -> Copia aquí **todos los `.mat` utilizados en la escena** + los nuevos materiales creados con Shader Graph.
- `Assets/ProyectoFinal/Texturas/` -> Copia aquí **absolutamente todos los tipos de mapas de texturas** (`Albedo`, `Normal`, `MaskMap`, `AO`, `Height`, `Smoothness`, `Metallic`, etc.) que alimentan los materiales y terrenos de esta escena.
- `Assets/ProyectoFinal/Scripts/` -> El script C# de cámara exploradora.
- `Assets/ProyectoFinal/Agentes/` -> El archivo `Analisis_ShaderGraph.md` con el estudio del proyecto.

**Reasignación de referencias:** Asegúrate de que todos los materiales, shaders, sub-shaders y objetos dentro de `ProyectoFinal_ShaderGraph.unity` apunten exclusivamente a las copias ubicadas dentro de `Assets/ProyectoFinal/`, sin dejar referencias rotas ni materiales en rosa.

---

## 4. Implementación Visual con Shader Graph (URP)
1. **Agua realista con Shader Graph (Reemplazo del agua eliminada)**:
   - Crea un plano/malla de agua ajustado al nivel de la orilla de la playa (`Island Level`).
   - Implementa un **URP Lit Shader Graph** para el agua con profundidad/transparencia por `Scene Depth`, efecto `Fresnel`, doble capa de `Normal Maps` animados en direcciones cruzadas (encapsulado en un `.shadersubgraph`), espuma en la orilla y reflejo especular con la `Directional Light`.
2. **Superficies de playa, rocas y edificaciones**:
   - Asegura que las **casas de playa (`Buildings`)**, **madera del muelle**, **rocas/acantilados** y **terreno** utilicen materiales respaldados por **Shader Graph (URP Lit)** aprovechando todos sus mapas de texturas (Albedo, Normal, MaskMap/Smoothness/AO).
   - Si algún elemento puntual (como espuma emisiva, brillos atmosféricos o partículas) requiere **URP Unlit Shader Graph**, impleméntalo y documéntalo.

---

## 5. Control de Cámara Exploradora en Modo Play
- **No agregues un modelo 3D de personaje**, ni `NavMesh`, ni rutas automáticas.
- Crea el script `ExploradorCamaraController.cs` dentro de `Assets/ProyectoFinal/Scripts/` y asígnalo a `Main Camera`.
- **Arquitectura C#**: Mantén `Update()` limpio llamando únicamente a métodos privados bien definidos, evita cadenas largas de `if-else` y evita expresiones lambda, usando números decimales con punto (ej. `10.0f`).
- **Funcionalidad**:
  - Movimiento fluido tipo primera persona con `WASD` + `Shift` para acelerar y `Q`/`E` para subir/bajar altura.
  - Rotación libre con el ratón bloqueando el cursor (`CursorLockMode.Locked`) al iniciar Play y liberándolo con `Escape` (volviendo a bloquear al hacer clic izquierdo), permitiendo acercarse a las casas de playa, el muelle, las rocas y la orilla del agua para inspeccionar el acabado de los Shader Graphs y sus mapas de texturas.