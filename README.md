Torque 3D v3.5 - Physx 3.3
==========================

Check My Projects\testPhysx3 for an example project showcasing PhysX 3.3 features.

Setting up PhysX 3.3
------------------------------------------

 - You will need the latest SDK from nVidia. This requires signing up for their developer program. If you don't already have access to their developer site then sign up now as access is not immediate.
 - Set up a standard Torque3D project, don't include any PhysX or Bullet, just regular Torque Physics in project manager options (if you're using it)
 - Generate Projects and open the source code in Visual Studio ( or the IDE of your choice )
 - In the solution explorer in the DLL for your project you should find Source Files -> Engine -> T3D -> physics
 - Add a new filter "physx3" and then right click on it and add existing item
 - Add all the files found under Engine\Source\T3D\physics\physx3\
 - Now you need to add the PhysX SDK. 
 - Under the properties for the DLL project, under Linker -> Additional Library Directories add the lib\win32 directory for the Physx 3.3 SDK. For example, mine is in: C:\Program Files (x86)\NVIDIA Corporation\NVIDIA PhysX SDK\v3.3.0_win\Lib\win32
 - In the same window under C/C++ you should see Additional Include Directories, you need to add the Include directory for the Physx 3.3 SDK. For example, mine is in: C:\Program Files %28x86%29\NVIDIA Corporation\NVIDIA PhysX SDK\v3.3.0_win\Include
 - You should now be able to compile now without any issues.

Running a project
------------------------------------------

 - To run a release project you will need the following from the SDK bin folder:
   1. PhysX3_x86.dll
   2. PhysX3CharacterKinematic_x86.dll
   3. PhysX3Common_x86.dll
   4. PhysX3Cooking_x86.dll

 - To run a debug project you will need the following from the SDK bin folder:
   1. PhysX3CHECKED_x86.dll
   2. nvToolsExt32_1.dll
   3. PhysX3CookingCHECKED_x86.dll
   4. PhysX3CommonCHECKED_x86.dll
   5. PhysX3CharacterKinematicCHECKED_x86.dll

Place these files along side the exe and this should get you up and running. Check My Projects/testPhysX3 for reference.
