# Box2D-dotnet-bindings
Box2D 3.x Bindings for dotnet (C#, F#, VB, ...)

## What is it?
This is a "link" from dotnet to Box2D 3.x, with an API that should be more familiar and comfortable to dotnet users.

## How is this better than Box2D.NetStandard?
Box2D 3.x contains significant efficiency improvements that make use of SIMD intrinsics.
While it's not impossible to implement in C# - intrinsics have been available since dotnet 6 - it's probably unlikely that Box2D 3.x will be ported into Box2D.NetStandard: one of the challenges with Box2D.NetStandard has always been keeping it up-to-date with changes to Box2D 2.x, and the performance was never on par. Since Box2D 3.x builds to shared libraries, it makes much more sense all round to simply write bindings to that library than to put time into porting it. It also means I can target .net standard 2.1 instead of dotnet 6 or above.

## Getting things working
1. Clone this repo, then either build it or add a DLL reference, or copy it into your solution and add a project reference, or configure it as a submodule.
  - (If this is too cryptic, you should probably use the NuGet package (if one exists))
2. Clone the main branch of Erin Catto's incredible Box2D project from https://github.com/erincatto/box2d
3. Build Box2D shared library:
  - CD into the box2d repo
  - Execute the commands in build.sh or build.bat, but for the first `cmake` command, add `-DBOX2D_SAMPLES=OFF -DBUILD_SHARED_LIBS=ON` before the `..`
  - (If this is too cryptic, this might not be the project for you.)
4. You fill find the shared object or DLL in ./build/src
5. Make sure that file gets into your output dir
