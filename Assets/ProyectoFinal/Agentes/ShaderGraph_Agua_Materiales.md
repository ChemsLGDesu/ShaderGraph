Trabaja en la escena `Assets/Scenes/ProyectoFinal/ProyectoFinal_ShaderGraph.unity` respetando la jerarquía existente y guardando todos los archivos nuevos dentro de `Assets/ProyectoFinal/`:

1. **Completar el Shader Graph de Arena del Terreno (`SG_ArenaTerreno.shadergraph`)**:
   - Toma el archivo ya iniciado en `Assets/ProyectoFinal/ShaderGraphs/SG_ArenaTerreno.shadergraph` (que ya tiene configurado `Material: Terrain` y la rama de `Smoothness` con arena húmeda por altura `Y` + destellos con `Simple Noise`). **No borres ni sobrescribas los nodos ya conectados.**
   - Conecta en ese mismo grafo las texturas de las capas del terreno (`TerrainLayers` / arena) hacia `Base Color(3)` y `Normal (Tangent Space)(3)`.
   - Reutiliza la misma salida del nodo `Smoothstep` (máscara de humedad en la orilla `Edge1 = 0.0`, `Edge2 = 1.2`) conectándola a un `Lerp` de color (de `0.45, 0.42, 0.40` en `A` a `1.0, 1.0, 1.0` en `B`) y multiplícalo por el `Base Color` de salida para oscurecer la arena mojada cerca del agua.
   - Crea el material `MAT_ArenaTerreno.mat` en `Assets/ProyectoFinal/Materials/` usando este shader y asígnalo en la propiedad `Material` dentro de **Terrain Settings** (ícono del engranaje) de `Terrain-0-0` y `Terrain-1-0`.

2. **Agua realista con URP Lit Shader Graph**:
   - Crea un `.shadersubgraph` en `Assets/ProyectoFinal/SubShaders/` que encapsule una doble capa de `Normal Maps` animados en direcciones cruzadas.
   - Crea un **URP Lit Shader Graph** (`Surface Type: Transparent`, `Alpha Clipping: Off`) en `Assets/ProyectoFinal/ShaderGraphs/` que integre ese sub-shader, profundidad/transparencia mediante `Scene Depth`, efecto `Fresnel`, espuma en la orilla y respuesta especular con la `Directional Light`. Verifica que `Depth Texture` esté activo en el `UniversalRenderPipelineAsset`.
   - Crea un plano/malla de agua ajustado al nivel de la orilla (`Y ≈ 0`) en `Island Level` y asígnale su nuevo material en `Assets/ProyectoFinal/Materials/`.

3. **Superficies de playa, rocas y edificaciones**:
   - Verifica que las casas de playa (`Buildings`), madera del muelle y rocas/acantilados usen materiales respaldados por **URP Lit Shader Graph** dentro de `Assets/ProyectoFinal/Materials/` aprovechando sus mapas de texturas (`Albedo`, `Normal`, `MaskMap`/`Smoothness`/`AO`).
   - Si algún efecto puntual (espuma emisiva, brillos atmosféricos o partículas) requiere **URP Unlit Shader Graph**, créalo en `Assets/ProyectoFinal/ShaderGraphs/`.

4. Actualiza `Assets/ProyectoFinal/Agentes/Analisis_ShaderGraph.md` documentando los shaders nuevos creados y la justificación `Lit` vs `Unlit`, y guarda la escena.