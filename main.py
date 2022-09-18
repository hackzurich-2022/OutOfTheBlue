#send different commands to the terminal

import os
import sys
import subprocess

commands = ['conda activate blender', 'python remove_red.py', 'cd FloorplanToBlender3d', 'python main.py', 'cd ..', 'cd Converter', 'python blend_to_fbx.py']

for command in commands:
    # await the next command to finish
    subprocess.run(command, shell=True)    
    