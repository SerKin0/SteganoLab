import matplotlib.pyplot as plt
import matplotlib.ticker as ticker
import numpy as np

# Настройка размера листа A4 в дюймах (1 дюйм = 25.4 мм)
A4_WIDTH_MM = 210
A4_HEIGHT_MM = 297
MM_TO_INCH = 1/25.4

# Создаем фигуру с точным размером A4
fig, ax = plt.subplots(figsize=(A4_WIDTH_MM * MM_TO_INCH, A4_HEIGHT_MM * MM_TO_INCH))

# Устанавливаем границы графика (оставляем небольшие отступы)
margin_mm = 10
x_min = margin_mm
x_max = A4_WIDTH_MM - margin_mm
y_min = margin_mm
y_max = A4_HEIGHT_MM - margin_mm

ax.set_xlim(x_min, x_max)
ax.set_ylim(y_min, y_max)

# Настраиваем основную сетку (миллиметровая)
ax.grid(True, which='major', color='gray', linestyle='-', linewidth=0.3, alpha=0.7)

# Настраиваем дополнительную сетку (через 5 мм)
ax.grid(True, which='minor', color='lightgray', linestyle='-', linewidth=0.2, alpha=0.5)

# Устанавливаем шаг для основной и дополнительной сетки
major_interval = 10  # основная сетка каждые 10 мм
minor_interval = 1   # миллиметровая сетка

ax.set_xticks(np.arange(x_min, x_max, minor_interval), minor=True)
ax.set_yticks(np.arange(y_min, y_max, minor_interval), minor=True)
ax.set_xticks(np.arange(x_min, x_max, major_interval))
ax.set_yticks(np.arange(y_min, y_max, major_interval))

# Настраиваем отображение делений
ax.tick_params(axis='both', which='major', labelsize=6)
ax.tick_params(axis='both', which='minor', length=2)

# Убираем стандартные отступы
plt.subplots_adjust(left=0, right=1, bottom=0, top=1)

# Добавляем подписи каждые 10 мм (опционально)
for x in np.arange(x_min, x_max, major_interval):
    ax.text(x, y_min - 2, f'{x:.0f}', ha='center', va='top', fontsize=5)
for y in np.arange(y_min, y_max, major_interval):
    ax.text(x_min - 2, y, f'{y:.0f}', ha='right', va='center', fontsize=5)

# Сохраняем в PDF (сохраняет реальные размеры)
plt.savefig('millimetre_paper_a4.pdf', 
            dpi=300, 
            format='pdf', 
            bbox_inches='tight', 
            pad_inches=0)

# Показываем график
plt.show()