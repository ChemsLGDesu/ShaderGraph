# Análisis ShaderGraph - ProyectoFinal_ShaderGraph

**Escena inspeccionada:** `Assets/Scenes/ProyectoFinal/ProyectoFinal_ShaderGraph.unity`
**Fecha:** 2026-11-24

---

## 1. Inventario de Shaders (`.shadergraph`, `.shadersubgraph`, `.shader` HLSL)

### 1.1 Shader Graphs Principales (URP)

| Archivo | Ruta | Tipo | Uso en Escena |
|---------|------|------|---------------|
| **SG_ArenaTerreno.shadergraph** | `Assets/ProyectoFinal/ShaderGraphs/SG_ArenaTerreno.shadergraph` | URP Terrain Lit Shader Graph | Terreno principal (Terrain_0_0, Terrain_1_0) |
| **Houses_Jetty.shadergraph** | `Assets/Shaders/Houses_Jetty.shadergraph` | URP Lit Shader Graph | Casas de playa, muelle (JettyLong01, JettySqr01, Houses) |
| **CliffShader.ShaderGraph** | `Assets/Shaders/CliffShader.ShaderGraph` | URP Lit Shader Graph | Acantilados, rocas (Env_Cliffs, Env_Rocks, LargeCliff01-03) |
| **Vegetation.shadergraph** | `Assets/Shaders/Vegetation/Vegetation.shadergraph` | URP Lit Shader Graph | Vegetación (Palmeras, arbustos, Bush cards) |
| **CloudLayer.shadergraph** | `Assets/Shaders/Clouds/CloudLayer.shadergraph` | URP Unlit Shader Graph | Capa de nubes (3DSkybox) |
| **Clouds.shadergraph** | `Assets/Shaders/Clouds/Clouds.shadergraph` | URP Unlit Shader Graph | Nubes volumétricas |
| **CheckpointShader.shadergraph** | `Assets/Shaders/CheckpointShader.shadergraph` | URP Unlit Shader Graph | Checkpoints de carrera |
| **PBR_HUE.ShaderGraph** | `Assets/Shaders/UtilityGraphs/PBR_HUE.ShaderGraph` | URP Lit Shader Graph (Utility) | Variación de hue para props/boats |
| **RaceBoats.ShaderGraph** | `Assets/Shaders/UtilityGraphs/RaceBoats.ShaderGraph` | URP Lit Shader Graph | Barcos de carrera |
| **SG_CausticsProjector.shadergraph** | `Assets/ProyectoFinal/ShaderGraphs/SG_CausticsProjector.shadergraph` | **URP Unlit Shader Graph** | **NUEVO** - Proyector de causticas en world-space desde luz direccional |

### 1.2 Sub-Graphs (`.shadersubgraph`)

| Archivo | Ruta | Descripción |
|---------|------|-------------|
| **ComputeLightmap.shadersubgraph** | `Assets/Shaders/Clouds/ComputeLightmap.shadersubgraph` | Cálculo lightmap para nubes |
| **1D_Noise.shadersubgraph** | `Assets/Shaders/UtilityGraphs/1D_Noise.shadersubgraph` | Ruido 1D |
| **DitherCrossfade.shadersubgraph** | `Assets/Shaders/UtilityGraphs/DitherCrossfade.shadersubgraph` | Crossfade dithering (LOD/fade) |
| **GetMainLight.shadersubgraph** | `Assets/Shaders/UtilityGraphs/GetMainLight.shadersubgraph` | Obtención luz principal URP |
| **MixFog.shadersubgraph** | `Assets/Shaders/UtilityGraphs/MixFog.shadersubgraph` | Mezcla de niebla exponencial |
| **RaceBoatLiveryMixer.shadersubgraph** | `Assets/Shaders/UtilityGraphs/RaceBoatLiveryMixer.shadersubgraph` | Mezcla libreas barcos |
| **SceenSpaceBlueNoise.shadersubgraph** | `Assets/Shaders/UtilityGraphs/SceenSpaceBlueNoise.shadersubgraph` | Blue noise screen-space |
| **SmoothCurve.shadersubgraph** | `Assets/Shaders/UtilityGraphs/SmoothCurve.shadersubgraph` | Curva suave |
| **SmoothTriangleWave.shadersubgraph** | `Assets/Shaders/UtilityGraphs/SmoothTriangleWave.shadersubgraph` | Onda triangular suave |
| **SoftParticles.shadersubgraph** | `Assets/Shaders/UtilityGraphs/SoftParticles.shadersubgraph` | Partículas suaves (depth fade) |
| **TransformWorldToSkybox.shadersubgraph** | `Assets/Shaders/UtilityGraphs/TransformWorldToSkybox.shadersubgraph` | Transform world→skybox |
| **TriangleWave.shadersubgraph** | `Assets/Shaders/UtilityGraphs/TriangleWave.shadersubgraph` | Onda triangular |
| **URPExponentialFog.shadersubgraph** | `Assets/Shaders/UtilityGraphs/URPExponentialFog.shadersubgraph` | Niebla exponencial URP |
| **Z_Reconstruction.shadersubgraph** | `Assets/Shaders/UtilityGraphs/Z_Reconstruction.shadersubgraph` | Reconstrucción depth (Z) |
| **VegetationDeformation.shadersubgraph** | `Assets/Shaders/Vegetation/VegetationDeformation.shadersubgraph` | Deformación viento vegetación |
| **CausticsNoise.shadersubgraph** | `Assets/ProyectoFinal/SubShaders/CausticsNoise.shadersubgraph` | **NUEVO** - Ruido animado multi-capa para causticas (3 octavas, distorsión, contraste, intensidad) |

### 1.3 Shaders HLSL (`.shader`)

| Archivo | Ruta | Tipo |
|---------|------|------|
| **Blocker.shader** | `Assets/Shaders/Blocker.shader` | URP Unlit (occlusion/blocker) |
| **Skybox-Procedural-Universal.shader** | `Assets/Shaders/Skybox-Procedural-Universal.shader` | Skybox procedural |
| **UIPanelFade.shader** | `Assets/Shaders/UI/UIPanelFade.shader` | UI Unlit fade |
| **CustomLighting.hlsl** | `Assets/Shaders/CustomLighting.hlsl` | Include HLSL para lighting custom |

---

## 2. Materiales (`.mat`), TerrainData, TerrainLayers y Mapas de Texturas

### 2.1 TerrainData

| Asset | Ruta | Descripción |
|-------|------|-------------|
| **Terrain_0_0** | `Assets/Objects/Levels/Island/Terrain_0_0.asset` | Terrain principal isla (MainIsland, CentralIsland) |
| **Terrain_1_0** | `Assets/Objects/Levels/Island/Terrain_1_0.asset` | Terrain secundario (SmallIsland, CoveFormation) |

### 2.2 TerrainLayers (5 capas)

| TerrainLayer | Ruta | Textura Albedo/BaseMap | Normal Map | Mask/Metallic/Smoothness |
|--------------|------|------------------------|------------|--------------------------|
| **BeachSand** | `Assets/Objects/Levels/Island/BeachSand.terrainlayer` | `Assets/Textures/Terrain/BeachSand_basecolor.tif` | `Assets/Textures/Terrain/BeachSand_normal.tif` | Integrado en shader terrain |
| **BeachSand_wet** | `Assets/Objects/Levels/Island/BeachSand_wet.terrainlayer` | `Assets/Textures/Terrain/BeachSand_wet_basecolor.tif` | (usa BeachSand_normal) | Variante húmeda para orilla |
| **Bush** | `Assets/Objects/Levels/Island/Bush.terrainlayer` | `Assets/Textures/Terrain/Bush_basecolor.tif` / `Bush.tif` | `Assets/Textures/Terrain/Bush_normal.tif` / `Bush_norm.tif` | Vegetación suelo |
| **RockPlants** | `Assets/Objects/Levels/Island/RockPlants.terrainlayer` | `Assets/Textures/Terrain/RockPlants_basecolor.tif` | `Assets/Textures/Terrain/RockPlants_normal.tif` | Zona rocosa con plantas |
| **SandRocks** | `Assets/Objects/Levels/Island/SandRocks.terrainlayer` | `Assets/Textures/Terrain/SandRocks_basecolor.tif` | `Assets/Textures/Terrain/SandRocks_normal.tif` | Transición arena-roca |

### 2.3 Materiales Principales de la Escena

| Material | Ruta | Shader Asociado | Objetos/Prefabs que lo usan | Texturas Principales |
|----------|------|-----------------|----------------------------|---------------------|
| **Terrain** | `Assets/Materials/Terrain.mat` | **SG_ArenaTerreno** (URP Terrain Lit) | Terrain_0_0, Terrain_1_0 (via TerrainGroup) | Usa TerrainLayers arriba |
| **Env_Cliffs** | `Assets/Objects/environment/Cliffs/Materials/Env_Cliffs.mat` | **CliffShader** (URP Lit) | Env_Cliffs, LargeCliff01-03, Cliff_Full_01-03, Cliff_Wall_01-03 | Albedo + Normal (Rock_normal.tif) |
| **Env_Rocks** | `Assets/Objects/environment/Cliffs/Materials/Env_Rocks.mat` | **CliffShader** (URP Lit) | Env_Rocks, Rock_Large_01-02, Rock_Medium_01-04, Rock_Small_01-04 | Albedo + Normal |
| **Env_HeroLarge** | `Assets/Objects/environment/Cliffs/Materials/Env_HeroLarge.mat` | **CliffShader** (URP Lit) | Hero_Mountain, Hero_Tower, Hero_Cave* | Albedo + Normal |
| **Matr_BuildingsJettys** | `Assets/Objects/props/houses/Materials/Matr_BuildingsJettys.mat` | **Houses_Jetty** (URP Lit) | House01-05, JettyLong01, JettySqr01, CoveHouse, FisherBay, IslandParadise, Town01, DistantVillage | AlbedoTransparency, Normal, MetallicSmoothness, Emission |
| **Matr_Props** | `Assets/Objects/props/props/Materials/Matr_Props.mat` | **PBR_HUE** (URP Lit) | Props_Chair, Buoy, Props_ArrowSign, Props_Paraglider, Props_Umbrella, Windsurfer, KayakRoot | AlbedoTransparency, AO, MetallicSmoothness, Normal |
| **Matr_Props_Hue** | `Assets/Objects/props/props/Materials/Matr_Props_Hue.mat` | **PBR_HUE** (URP Lit) | Variantes coloreadas de props | Mismas texturas + hue shift |
| **Trees** | `Assets/Objects/environment/Trees/Materials/Trees.mat` | **Vegetation** (URP Lit) | Palm_01-03, PalmB_01-02, Bush_Large_01 | Albedo + Normal + Deformación viento |
| **Bushes** | `Assets/Objects/environment/Trees/Materials/Bushes.mat` | **Vegetation** (URP Lit) | Env_BushCards | Albedo + Normal + Alpha cutoff |
| **Seaweed** | `Assets/Materials/Seaweed.mat` | (URP Unlit/Lit custom) | Env_Seaweed | seaweedtemp.png |
| **CloudLayer** | `Assets/Objects/environment/Clouds/CloudLayer.mat` | **CloudLayer** (URP Unlit) | CloudLayer (3DSkybox) | Ruido procedural |
| **Clouds** | `Assets/Objects/environment/Clouds/Clouds.mat` | **Clouds** (URP Unlit) | Nubes volumétricas | Ruido procedural |
| **ClearSky** | `Assets/Objects/Levels/Island/ClearSky/ClearSky.mat` | Skybox/Unlit | Skybox ClearSky | Procedural |
| **_waterFoam** | `Assets/Materials/_waterFoam.mat` | URP Unlit | Espuma agua | WaterSplashes.tif |
| **_foam** | `Assets/Materials/_foam.mat` | URP Unlit | Espuma costa | WaterSplashes.tif |
| **_dispWake_add** / **_dispWake_sub** | `Assets/Materials/_dispWake_*.mat` | URP Unlit | Estela barcos | wakeFXmap.tif |

### 2.4 Mapas de Texturas por Categoría

#### Terreno (TerrainLayers)
- **Albedo/BaseMap:** BeachSand_basecolor.tif, BeachSand_wet_basecolor.tif, Bush_basecolor.tif, Bush.tif, RockPlants_basecolor.tif, SandRocks_basecolor.tif
- **Normal Map:** BeachSand_normal.tif, Bush_normal.tif, Bush_norm.tif, RockPlants_normal.tif, SandRocks_normal.tif
- **Mask/Metallic/Smoothness:** Gestionados por `SG_ArenaTerreno.shadergraph` vía TerrainLayer settings

#### Acantilados/Rocas (CliffShader)
- **Albedo:** Texturas embebidas en FBX o atlas
- **Normal:** `Assets/Textures/Island/Rock_normal.tif`
- **Metallic/Smoothness:** En atlas o canal alpha

#### Casas/Muelle (Houses_Jetty)
- **Albedo/Transparency:** `Assets/Objects/props/houses/Maps/HousesJetty_LOW_Matr_BuildingsJettys_AlbedoTransparency.tif`
- **Normal:** `Assets/Objects/props/houses/Maps/HousesJetty_LOW_Matr_BuildingsJettys_Normal.tif`
- **Metallic/Smoothness:** `Assets/Objects/props/houses/Maps/HousesJetty_LOW_Matr_BuildingsJettys_MetallicSmoothness.tif`
- **Emission:** `Assets/Objects/props/houses/Maps/HousesJetty_LOW_Matr_BuildingsJettys_Emission.tif` (ventanas/luces)

#### Props (PBR_HUE)
- **Albedo/Transparency:** `Assets/Objects/props/props/Maps/Props_LOW_Matr_Props_AlbedoTransparency.tif`
- **Normal:** `Assets/Objects/props/props/Maps/Props_LOW_Matr_Props_Normal.tif`
- **Metallic/Smoothness:** `Assets/Objects/props/props/Maps/Props_LOW_Matr_Props_MetallicSmoothness.tif`
- **AO:** `Assets/Objects/props/props/Maps/Props_LOW_Matr_Props_AO.png`

#### Vegetación (Vegetation)
- **Albedo/Alpha:** Atlas vegetación (Palm, Bush)
- **Normal:** Atlas normal vegetación
- **Deformación:** `VegetationDeformation.shadersubgraph` (viento)

#### Agua/Causticas
- **Base Water:** `Assets/Textures/Water/base.png`
- **Causticas:** No hay textura dedicada encontrada; se generan proceduralmente en shader
- **Estela/Wake:** `Assets/Textures/Water/wakeFXmap.tif`
- **Estela Barco:** `Assets/Textures/Water/WaterBoatTrail.png`
- **Salpicaduras:** `Assets/Textures/Water/WaterSplashes.tif`

---

## 3. Propuesta Técnica: Reutilización vs Creación Nueva

### 3.1 Shaders a REUTILIZAR/ADAPTAR (Mantener y extender)

| Shader | Tipo | Acción | Justificación |
|--------|------|--------|---------------|
| **SG_ArenaTerreno.shadergraph** | **URP Terrain Lit Shader Graph** | **REUTILIZAR y EXTENDER** | Ya implementa blending de 5 TerrainLayers, soporte para causticas proyectadas, wetness en orilla. Base sólida para terreno. |
| **Houses_Jetty.shadergraph** | **URP Lit Shader Graph** | **REUTILIZAR** | Completo: PBR, emission (ventanas), transparency (vidrios), metallic/smoothness. Cubre casas y muelle. |
| **CliffShader.ShaderGraph** | **URP Lit Shader Graph** | **REUTILIZAR** | Optimizado para rocas/acantilados con normal mapping fuerte. Cubre todos los cliff prefabs. |
| **Vegetation.shadergraph** | **URP Lit Shader Graph** | **REUTILIZAR y ADAPTAR** | Incluye `VegetationDeformation` subgraph para viento. Funciona para palmeras y arbustos. |
| **PBR_HUE.ShaderGraph** | **URP Lit Shader Graph** | **REUTILIZAR** | Utility shader para variación de color props. Base para Matr_Props y Matr_Props_Hue. |
| **CloudLayer.shadergraph** / **Clouds.shadergraph** | **URP Unlit Shader Graph** | **REUTILIZAR** | Skybox/volumétricas funcionando correctamente. |

### 3.2 Shaders a CREAR DESDE CERO

| Nuevo Shader | Tipo | Propósito | Detalles |
|--------------|------|-----------|----------|
| **SG_CausticsProjector.shadergraph** | **URP Unlit Shader Graph** | **Causticas proyectadas sobre arena/muelle** | - Proyección world-space desde luz direccional (sol)<br>- Animación temporal (Time + noise)<br>- Mask por TerrainLayer (solo BeachSand, BeachSand_wet, SandRocks)<br>- Receptor en `SG_ArenaTerreno` y `Houses_Jetty` via `Shader Graph Custom Function` o `SubGraph`<br>- Textura: ruido procedural (no requiere asset externo) |
| **SG_WaterSurface.shadergraph** | **URP Lit Shader Graph** | **Superficie agua oceánica** | - Fresnel + refraction + reflection (screen-space)<br>- Gerstner waves / FFT para oleaje<br>- Integración con causticas (receiver)<br>- Foam en orilla (depth-based)<br>- **Nota:** No hay water surface material actual en escena; usar `_waterFoam`/`_foam` solo para partículas |
| **SG_TerrainBlendOptimized.shadergraph** | **URP Terrain Lit Shader Graph** | **Versión optimizada de SG_ArenaTerreno** | - Reducir variants (actualmente 5 layers → max 4 por chunk)<br>- GPU Instancing para terrain details<br>- Support para Rendering Layers (decals causticas) |

### 3.3 Sub-Graphs a CREAR/EXTRAER

| Sub-Graph | Tipo | Origen | Uso |
|-----------|------|--------|-----|
| **CausticsNoise.shadersubgraph** | **URP Unlit** | **NUEVO** (extraer de SG_CausticsProjector) | Ruido animado causticas (reutilizable en water surface) |
| **WorldSpaceProjection.shadersubgraph** | **URP Unlit/Lit** | **NUEVO** | Proyección world-space genérica (causticas, decals, projected shadows) |
| **TerrainLayerMask.shadersubgraph** | **URP Terrain Lit** | **EXTRAER** de SG_ArenaTerreno | Máscara por layer para efectos locales (wetness, causticas, footprints) |
| **FoamDepthFade.shadersubgraph** | **URP Unlit** | **NUEVO** | Espuma basada en depth (orilla, objetos) |

### 3.4 Resumen de Decisiones por Categoría

| Categoría | Shader Actual | Decisión | Shader Final |
|-----------|---------------|----------|--------------|
| **Terreno (Terrain_0_0, Terrain_1_0)** | SG_ArenaTerreno | **Reutilizar + Extender** | SG_ArenaTerreno (v2) + SG_CausticsProjector (receiver) |
| **Casas de playa** | Houses_Jetty | **Reutilizar** | Houses_Jetty + SG_CausticsProjector (receiver en muelle) |
| **Muelle (JettyLong01, JettySqr01)** | Houses_Jetty | **Reutilizar** | Houses_Jetty + SG_CausticsProjector (receiver) |
| **Rocas/Acantilados** | CliffShader | **Reutilizar** | CliffShader (sin causticas) |
| **Vegetación (Palmeras, Arbustos)** | Vegetation | **Reutilizar + Adaptar** | Vegetation (añadir wind zone global) |
| **Props (Sillas, Boyas, etc.)** | PBR_HUE | **Reutilizar** | PBR_HUE / Matr_Props_Hue |
| **Agua Oceánica** | *Ninguno (solo foam particles)* | **CREAR** | **SG_WaterSurface** (URP Lit) |
| **Causticas Proyectadas** | *Ninguno* | **CREAR** | **SG_CausticsProjector** (URP Unlit) + receivers en terrain/muelle |
| **Nubes/Skybox** | CloudLayer/Clouds | **Reutilizar** | Sin cambios |
| **Skybox Procedural** | Skybox-Procedural-Universal | **Reutilizar** | Sin cambios |

---

## 4. Próximos Pasos Recomendados

1. **Crear `SG_CausticsProjector.shadergraph`** (URP Unlit) → Proyecta causticas animadas en world-space
2. **Modificar `SG_ArenaTerreno.shadergraph`** → Añadir entrada `CausticsReceiver` (SubGraph call) para BeachSand/BeachSand_wet/SandRocks
3. **Modificar `Houses_Jetty.shadergraph`** → Añadir receiver causticas solo en partes de muelle (mask por vertex color o texture mask)
4. **Crear `SG_WaterSurface.shadergraph`** (URP Lit) → Superficie agua completa con refraction, fresnel, gerstner waves, foam
5. **Crear subgraphs compartidos**: `CausticsNoise`, `WorldSpaceProjection`, `TerrainLayerMask`
6. **Actualizar materiales**: `Terrain.mat`, `Matr_BuildingsJettys.mat` para usar nuevos shaders/receivers
7. **Configurar Lighting**: Asegurar que Directional Light (Sol) tiene `Render Type = Light` para proyección causticas

---

*Documento generado automáticamente tras inspección de escena via Unity MCP.*