**Title of the Project: Create Augmented Reality models of Scientific Experiments**
**Process:**
Following steps were followed in making a working model of an experiment:
1. **3D modelling in Blender**
	Models of all the requied objects are made here. All the experiment apparatus like the Bunsen Burners, Spatulas, Copper Crystals, China Dish etc. are modelled in Blender.
	
2. **Exporting the objects to Unity and adding the required interactivity**
The models are then exported to unity and placed as requied. Here the properties of the exported models can be changed, like adding a material, giving them texture etc. For the simulation of flames and water-bubbles the particle system feature is used. The texture of flame can be made to depend upon user input via a slider. Then a C# Script is attached depending upon the experiment being simulated. This can be used to control the rotation of objects with time, to change the material or color of an object upon user input etc. The Vuforia Package present in Unity has been utilised to convert the files into Android device compatible AR files.

**Experiments Simulated along with their Task Label:**
1. Task 1: Newton’s Cradle
2. Task 2: Oxidation of Copper to Copper Oxide
3. Task 3: Chlor-Alkali Process
4. Task 4: Different types of burner flames at various oxygen levels 
5. Task 5: Ocean Thermal Energy Generator

**Running the .apk Files on Android Devices:**
The .apk can be downloaded from each .zip submission file, installed and run on android devices. The animations begin when the device is pointed to the corresponding target image.
