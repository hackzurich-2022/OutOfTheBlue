import os
import sys

# import module
from pdf2image import convert_from_path

# read folders recursively until pdf found
def find_pdf(path):
    for root, dirs, files in os.walk(path):
        for file in files:
            if file.endswith(".pdf"):
                print(os.path.join(root, file))
                os.path.join(root, file)         

                # convert pdf to jpg
                convert_to_jpg(os.path.join(root, file))                       
    return None

def convert_to_jpg(path):
    print("Converting " + path + " to jpg")

    # convert pdf to jpg
    images = convert_from_path(path, 500, poppler_path=r'C:/Program Files/poppler-22.04.0/Library/bin')
    #if folder does not exist, create it
    print("cartella", path.replace("PDFs","Images").rsplit('\\', 1)[0])
    if not os.path.exists(path.replace("PDFs","Images").rsplit('\\', 1)[0]):
        os.makedirs(path.replace("PDFs","Images").rsplit('\\', 1)[0])
    images[0].save(path.replace("PDFs","Images").replace(".pdf","") + '.jpg', 'JPEG')
    return None

find_pdf("./PDFs/Easy")