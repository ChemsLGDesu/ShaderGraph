Trabaja sobre la escena abierta en `Assets/Scenes/ProyectoFinal/ProyectoFinal_ShaderGraph.unity`.
REGLAS ESTRICTAS:
- NO dupliques `Adventure_Island_Flythrough` ni borres los grupos actuales (`Main Camera`, `Island Level`, `Lighting`, `FX`, `Audio`, `3DSkybox`, `Sky`).
- NO leas ni explores las carpetas `Library/`, `Temp/`, `Logs/` ni `obj/`.
- Por ahora NO modifiques ni muevas ningún asset de la escena.
- Incluye también el Shader Graph / Sub-Graph y texturas responsables de las cáusticas (Caustics) proyectadas sobre la arena y el muelle.

Tarea de este paso:
Inspecciona la escena actual mediante Unity MCP y genera el archivo `Assets/ProyectoFinal/Agentes/Analisis_ShaderGraph.md` (y muéstrame un resumen breve en el chat) con:
1. Inventario con rutas exactas de todos los `.shadergraph`, `.shadersubgraph` y shaders HLSL (`.shader`) usados o relacionados con la isla, casas de playa, muelle, rocas, terreno (`Terrain_0_0`, `Terrain_1_0` y sus `TerrainLayers`), vegetación o agua.
2. Lista de todos los materiales (`.mat`), `TerrainData`, `TerrainLayers` y mapas de texturas (`Albedo/BaseMap`, `Normal Map`, `MaskMap`, `Metallic`, `Smoothness`, `AO`, `Height`, `Emission`, `Detail Maps`) asociados a los objetos de esta escena.
3. Propuesta técnica de qué shaders se reutilizarán/adaptarán y cuáles se crearán desde cero diferenciando **URP Lit Shader Graph**, **URP Terrain Lit Shader Graph** (`SG_ArenaTerreno.shadergraph`) y **URP Unlit Shader Graph**.