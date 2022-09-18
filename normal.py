# Start pipeline    

import os
from re import S
import sys
from tkinter import Frame
import cv2
import pytesseract
import numpy as np


def preprocessing():

    #load images from folder

    pathIn = "./Floor/Images/"
    pathOut = "./FloorplanToBlender3d/Images/Normal/"

    files = os.listdir(pathIn)
    for file in files:

        inputImage = cv2.imread(pathIn + file)
        
        # Conversion to CMYK (just the K channel):

        """

        # Convert to float and divide by 255:
        imgFloat = inputImage.astype(np.float) / 255.

        # Calculate channel K:
        kChannel = 1 - np.max(imgFloat, axis=2)

        # Convert back to uint 8:
        kChannel = (255 * kChannel).astype(np.uint8)

        t = [cv2.THRESH_BINARY, cv2.THRESH_BINARY_INV, cv2.THRESH_TRUNC, cv2.THRESH_TOZERO, cv2.THRESH_TOZERO_INV]
                
        for x in t:
            ret,thresh1 = cv2.threshold(kChannel,127,255,x)
            cv2.imwrite(pathOut + file + str(x) + ".jpg", thresh1)
               
        thres = cv2.adaptiveThreshold(inputImage,255,cv2.ADAPTIVE_THRESH_GAUSSIAN_C, cv2.THRESH_BINARY,11,2)
        cv2.imwrite(pathOut + file + str(x) + ".jpg", thres)
        
        # Use a little bit of morphology to clean the mask:
        # Set kernel (structuring element) size:
        kernelSize = 2
        # Set morph operation iterations:
        opIterations = 2
        # Get the structuring element:
        morphKernel = cv2.getStructuringElement(cv2.MORPH_RECT, (kernelSize, kernelSize))
        # Perform closing:
        binaryImage = cv2.morphologyEx(binaryImage, cv2.MORPH_CLOSE, morphKernel, None, None, opIterations, cv2.BORDER_REFLECT101)

        # Perform an area filter on the binary blobs:
        minArea = 50
        filteredImage = areaFilter(minArea, binaryImage)

        # invert color image
        filteredImage = cv2.bitwise_not(filteredImage)
        
        """      

        filteredImage = cv2.bitwise_not(inputImage)

        #save image
        cv2.imwrite(pathOut +  file, inputImage)
        
def areaFilter(minArea, inputImage):
    # Perform an area filter on the binary blobs:
    componentsNumber, labeledImage, componentStats, componentCentroids = \
        cv2.connectedComponentsWithStats(inputImage, connectivity=4)

    # Get the indices/labels of the remaining components based on the area stat
    # (skip the background component at index 0)
    remainingComponentLabels = [i for i in range(1, componentsNumber) if componentStats[i][4] >= minArea]

    # Filter the labeled pixels based on the remaining labels,
    # assign pixel intensity to 255 (uint8) for the remaining pixels
    filteredImage = np.where(np.isin(labeledImage, remainingComponentLabels) == True, 255, 0).astype('uint8')

    return filteredImage

preprocessing()