import os
import numpy as np
import cv2

pathIn = "./Floorplans/Images/Nice/"
pathOut = "./FloorplanToBlender3d/Images/Floor/"


# read files from folder
files = os.listdir(pathIn)
for file in files:
    inputImage = cv2.imread(pathIn + file)        

    hsv = cv2.cvtColor(inputImage, cv2.COLOR_BGR2HSV)

    mask1 = cv2.inRange(hsv, (0, 50, 50), (10, 255, 255))
    mask2 = cv2.inRange(hsv, (80, 50, 50), (200, 255, 255))
    mask = mask1 + mask2    

    # Build mask of non black pixels.
    nzmask = cv2.inRange(hsv, (0, 0, 5), (255, 255, 255))

    # Erode the mask - all pixels around a black pixels should not be masked.
    nzmask = cv2.erode(nzmask, np.ones((10,10)))    

    mask = mask & nzmask

    new_img = inputImage.copy()
    new_img[np.where(mask)] = 255    
    cv2.imwrite(pathOut + file, new_img)

    cv2.waitKey(0)
    cv2.destroyAllWindows()