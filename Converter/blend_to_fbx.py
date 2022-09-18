# read Blender folder and convert all .blend files to .fbx

import os
import bpy
import sys

# get the path to the folder containing the .blend files
pathIn = "../FloorplanToBlender3d/Target"
pathOut = "../HackZurich2022/Assets/Resources/Floors"

# get the list of .blend files in the folder
files = os.listdir(pathIn)
blend_files = [f for f in files if f.endswith(".blend")]

# loop through the .blend files
for blend_file in blend_files:
    # load the .blend file
    bpy.ops.wm.open_mainfile(filepath=pathIn + "/" + blend_file)
    # get the name of the .blend file without the extension
    name = blend_file.split(".")[0]
    # export the .fbx file
    bpy.ops.export_scene.fbx(filepath=pathOut + "/" + name + ".fbx")

# quit Blender
bpy.ops.wm.quit_blender()