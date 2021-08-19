# The bdt0011/Assets/FromStore directory contents

The bdt0011/Assets/FromStore directory has to be created manually. This folder contains free assets from the [Unity asset Store](https://assetstore.unity.com/) that I use to create the game. These assets has to be downloaded manually and added to the game if someone wants to run the project.

These assets are the following.

## Alien and Space Marines Units
The asset store link: https://assetstore.unity.com/packages/3d/alien-and-space-marines-units-36365 .

Only the Ciccio assets are used in this project.
The directory structure should be the following:

![Directory structure](images/AliensAndMarinesDirectory.png)

The Ciccio animation controller should be modified to look like this:

![Ciccio animation controller](images/CiccioAnimationController.png)

The Ciccio_LODNewImport.fbx is used in the game which is a reimport of the Ciccio_LOD.fbx asset with Generic Animation Rig. The DeathSinkBellowGround animation clip is created from the last frame of the Death animation clip, and just makes Ciccio sink bellow the ground. These files has to be created manually. And also the materials has to be converted to URP materials.

## Yughues Free Ground Materials
The asset store link: https://assetstore.unity.com/packages/2d/textures-materials/floors/yughues-free-ground-materials-13001 .

Only 2 assets are used from this package: Grass & dead leafs 02 and the Ground & moss. I am only using the textures from this asset in shader graphs.
The directory structure should be the following:

![Directory structure](images/GroundtexturespackDirectory.png)

## Simple Sci-Fi Turret
The asset store link: https://assetstore.unity.com/packages/3d/environments/sci-fi/simple-sci-fi-turret-25015 .

The materials has to be converted to URP materials.
The directory structure should be the following:

![Directory structure](images/SimpleTurretDirectory.png)

## Foliage Pack Free
The asset store link: https://assetstore.unity.com/packages/3d/vegetation/foliage-pack-free-66155 .

The URP materials used for the meshes are contained in the project's Material folder, so no conversion necessary. However I used derivative images for the color of the material: the ferns_darker.tga and pinetree-albedo_darker.tga files.
The directory structure should be the following:

![Directory structure](images/FoliageFreeDirectory.png)

## Environmental Asset Pack
The asset store link: https://assetstore.unity.com/packages/3d/environments/environmental-asset-pack-170036 .

The URP materials used for the meshes are contained in the project's Material folder, so no conversion necessary. However I used derivative image for the color of the material: the Grass 1adjusted.png file.
The directory structure should be the following:

![Directory structure](images/JPEnvironmentalAssetPackDirectory.png)

## Rocky Meadow Assets
The asset store link: https://assetstore.unity.com/packages/3d/environments/rocky-meadow-assets-24708 .

The material for the rocks has to be converted to URP material. The URP materials used for the plant meshes are contained in the project's Material folder, so no conversion necessary.
The directory structure should be the following:

![Directory structure](images/meadow_assetsDirectory.png)

## Yughues Free Bushes
The asset store link: https://assetstore.unity.com/packages/3d/vegetation/plants/yughues-free-bushes-13168 .

The materials has to be converted to URP materials.
The directory structure should be the following:

![Directory structure](images/YughuesFreeBushes2018Directory.png)

## Material conversion in Unity
Select the material in the project tab. Then select Edit>Render Pipeline>Universal Render Pipeline>Upgrade selected materials to UniversalRP Materials menu.


