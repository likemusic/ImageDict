# ImageDict
Словарь с поиском на основе отсканированных страниц бумажного словаря

## Возможности
* Использование различных пользовательских отсканированных словарей
* Поиск и открытие нужной страницы (по содержанию из первых слов страниц)
* Масштабирование страниц
* Навигация вперед/назад и по номеру страницы.
* Возможность просмотра введения или вступления к словарю.


## Настройка
В папке с программой должна быть папка `Data` с файлами:
* /Settings.json - файл с настройками словаря в формате json.
* /Content.txt - список из первых слов на отсканированных страницах в кодировке UTF-8.
* /Icon.ico - файл с иконкой словаря, чтобы не путать одновременно запущенные разные словари.
* Файлы с отсканированными страницами бумажного словаря (с расширением `.jpg`).


### Параметры файла Settings.json
* **FileFormatString** - фомат нумерации файлов со сканами. "0000" означает, что файлы будут называться: "0013.jpg", "0014.jpg", "0015.jpg" и т.д.
* **PagesPerFile** - страниц на файл.
* **WordsPerFile** - слов в файле-содержании Content.txt на один файл.(//TODO:сделать WordsPerPage).
* **MinFileNumber** - наименьший номер в имени файла.
* **MaxFileNumber** - наибольший номер в имени файла.
* **MinPage** - номер первой отсканированной страницы (в файле с номером MinFileNumber).
* **StartDictPage** - номер страницы с которой непоследственно начинается словарь.
* **ContentHaveEnds** - не помню за что отвечает этот параметр))
* **ContentColumnSeparator** - разделитель столбцов в файле-содержании Content.txt. Удобно когда словарь в 2 или более колонок на страницу.
* **CultureName** - поределяет порядок символов в алфавите, необходим для правильного нахождения страниц с искомым словом. Например для поиска в датском словаре должен быть равен "da-DK". See [table of Language Culture Names](https://msdn.microsoft.com/en-us/library/ee825488(v=cs.20).aspx).

## Screenshot
![ImageDict screenshot](ImageDict.png?raw=true "ImageDict screenshot")
