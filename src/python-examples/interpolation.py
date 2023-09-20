


import matplotlib.pyplot as plt
import scipy.interpolate

x = [2, 4, 6, 8, 10, 12, 14, 16, 18, 20]
y = [4, 7, 11, 16, 22, 29, 38, 49, 63, 80]

y_interp = scipy.interpolate.interp1d(x, y)
x_val = 13

#create plot of x vs. y
plt.plot(x, y, '-ob')

#add estimated y-value to plot
plt.plot(x_val, y_interp(x_val), 'ro')
print(y_interp(x_val))
plt.show()


