Basándote en `Assets/ProyectoFinal/Agentes/Analisis_ShaderGraph.md`, consolida los recursos de `ProyectoFinal_ShaderGraph.unity` dentro de `Assets/ProyectoFinal/`:

REGLA CRÍTICA DE INTEGRIDAD:
- Copia los assets y reasigna referencias EXCLUSIVAMENTE mediante herramientas de Unity MCP / `AssetDatabase` (o scripts de editor temporales ejecutados en Unity). PROHIBIDO usar comandos de consola del sistema (`cp`, `mv`, `Copy-Item`) para copiar archivos `.mat`, `.shadergraph`, `.terrainlayer` o texturas, ya que rompería los GUIDs y dejaría materiales en rosa.
- No arrastres assets de otras escenas que no se utilicen aquí.

Estructura destino:
- `Assets/ProyectoFinal/ShaderGraphs/` -> Copia todos los `.shadergraph` existentes relacionados con la escena (conservando intacto `SG_ArenaTerreno.shadergraph` que ya está ahí).
- `Assets/ProyectoFinal/SubShaders/` -> Copia todos los `.shadersubgraph` existentes relacionados.
- `Assets/ProyectoFinal/Materials/` -> Copia todos los `.mat` utilizados en la escena (si usan un `.shader` HLSL, cópialos igual aquí y anótalo para reemplazar su shader en el siguiente paso).
- `Assets/ProyectoFinal/Texturas/` -> Copia todos los mapas de texturas usados por esos materiales y por los `TerrainLayers` del terreno.

Protección del Terreno (`Terrain-0-0` y `Terrain-1-0`):
- Duplica mediante `AssetDatabase` los `TerrainData` (`Terrain_0_0`, `Terrain_1_0`) y sus `TerrainLayers` dentro de `Assets/ProyectoFinal/` antes de reasignar sus texturas, y vincula esas copias tanto en el componente `Terrain` como en el `Terrain Collider` de ambos objetos para no alterar la escena original.

Al terminar, reasigna las referencias en los materiales copiados y en los objetos de `ProyectoFinal_ShaderGraph.unity` para que apunten exclusivamente a las copias dentro de `Assets/ProyectoFinal/`, guarda la escena y verifica que no existan materiales rosas ni referencias faltantes.