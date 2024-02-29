import matplotlib.pyplot as plt import matplotlib.cbook as cbook
import numpy as np
import regex as re
import cv2


col = ((0,0,0)) # Глобальные переменные необходимые для 1 задания.
rsize = 0
latest_event = False
image = cv2.imread("C:/Users/syrvi/source/repos/PythonApplication5/PythonApplication5/Bingus.jpg")
# ^^^^ Загрузка изображения с помощью cv2.imread.
print("Write down which task you need 20/4/8/1:") 
tsname = str(input()) # Выбор задания.

if (tsname == "4"):
  print("Write down color R/G/B:")
  colRGB = str(input()) # Получение данных пользователя.
  b, g, r = cv2.split(image) # Разбиваем изображение на 3 изображения-спектора. 
  if (colRGB == "B"): cv2.imshow(colRGB,b)
  elif (colRGB == "G"): cv2.imshow(colRGB,r)
  else: cv2.imshow(colRGB, r)
    
if (tsname == "20"):
  b, g, r = cv2.split(image) # Разбиваем изображение на 3 изображения-спектора.
  cv2.imshow("Blue",b[0:int(image.shape[0]/2),0: int(image.shape[1]/2)]) # BыBожу часть изображения-спектра. 
  cv2.imshow("Green", g[int(image.shape[0]/2):image.shape[0],0: int(image.shape[1]/2)]) 
  cv2.imshow("Red",r[0: int(image.shape[0]/2), int(image.shape[1]/2):image.shape[1]])
  cv2.imshow("Gray",cv2.cvtColor(image[int(image.shape[0]/2):image.shape[0], int(image.shape[1]/2):image.shape[1],:], cv2.COLOR_BGR2GRAY))
  # ^^^^ Вывожу часть оригинального изображения применяя к енй сѵ2.COLOR_BGR2GRAY

if (tsname == "8"):
  gray = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY) # Созда "серу" кoпи
  for i in range(0, image.shape[1]):
    for j in range(0, image.shape[0], 2):
      image[j][i] = gray[j][i] #Пpиравниваем соответсвуший пиксель image к gray 
  cv2.imshow("Gray lines",image)

if (tsname == "1"):
  cv2.namedWindow('Point and click') # Coздаeм okнo Point and click.
  cv2.imshow('Point and click',image) # Выводим на окно Роint and click из0бpажение image.
  cv2.createTrackbar('R','Point and click', 0, 255, TrackbarCheck)
  
  #^^^^ Создаем TrackBar с названием R на окне Point and click, с диапозоном от 0 до 255 и функцией Trackbarcheck как функцию получающую значения при изменении
  
  cv2.createTrackbar('G','Point and click', 0, 255, TrackbarCheck)
  cv2.createTrackbar('B','Point and click', 0, 255, TrackbarCheck) 
  cv2.createTrackbar('Radius', 'Point and click', 0, 255, TrackbarCheck)
  cv2.imshow("Point and click',image)
  cv2.setMouseCallback("Point and click", MouseClickHa) # Bыываем через метод setMouseCallback нaшy ункши MouseClickнa.
  cv2.waitKey(0)
  cv2.destroyAllWindows()


def TrackbarCheck(x):
  global col, rsize # Упоминаем, что будут использоваться следующие глобальные переменные.
  r = cv2.getTrackbarPos('R', 'Point and click') # Cчитываем значение на trackbar'e R нaxoдяшегося в окне Point and click. g= cv2.getTrackbarPos('G', 'Point and click')
  b = cv2.getTrackbarPos('B', 'Point and click')
  col = tuple((r,g,b)) # Изменяем глобальные перменнные.
  rsize = cv2.getTrackbarPos('Radius', 'Point and click')
def MouseClickHa(event, x, y, flags, params): # Функция срабатывающая при нажатии по изображению.
  global col, rsize, latest_event
  if event == cv2.EVENT_LBUTTONUP or event == cv2.EVENT_RBUTTONUP:
    latest_event = False # Переменная-флаг, которая отслеживает была ли отпущенна клавиша мыши или нет.
  elif event == cv2.EVENT_LBUTTONDOWN or event == cv2.EVENT_RBUTTONDOWN or latest_event == True: # Данное выражение верно пока не отпушенна мыши. 
    cv2.circle(image, (x,y), rsize, col, -1) # Рисуем оккружность в месте нажатия, отрицательная толщина делает окружность кругом.
    cv2.imshow('Point and click', image)
    latest_event = True

cv2.waitKey(0)
cv2.destroyAllWindows()
