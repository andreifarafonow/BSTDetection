# Команда UNI - проект «Безопасная среда Татарстан»

#### MVP доступно по ссылке https://trashdetect.pagekite.me/  
У.З. оператора 
- operator, qwerty

У.З. пользователей  
- Shophil,  Yuyu_5672
- Tonick,  Think_23451
- Xuxandian,  Many-5675
- Quinsell,  Wawa_4568
- Cardrico,  Qyqy_23455
- Ckyetter,  Ququ_7895
- Ytonal,  34569Green
- Barislo,  Main_2342
- Jenichig,  Yeye_12348
- Phigendana,  Fly-2341



____

Система реализует эмуляцию видеопотока на основе исходных датасетов (в любой момент времени рассматриваются снимки с камер максимально приближенные к текущему времени суток) для проверки в реальных условиях.

Также данный подход позволяет минимизировать трудозатраты при дальнейшем интегрировании реального видеопотока с камер видеонаблюдения.

![Alt-текст](https://raw.githubusercontent.com/andreifarafonow/BSTDetection/master/WebApplication1/Без%20имени-1.png)

Нами были размечены фото из датасетов, а также из открытых источников, содержащие мусорные контейнеры. На основе этих данных была обучена <a href="https://drive.google.com/file/d/1ymdzasB2Q_rCSX_jcpHGbLbaTAOtNuHX/view?usp=sharing">Pixellib модель</a>

![Alt-текст](https://sun9-52.userapi.com/impg/6hGMIUelbpmlASKxeMQXRVF3MOpcZ7QPeVB9Xg/gpca9sMhsDw.jpg?size=230x161&quality=95&sign=68885e1d35fdf16682ed23fccfa29615&type=album)

Добившись необходимой точности детекции мусорных баков, мы решили задачу классификации наполненности баков, попадающих в bounding box при помощи библиотеки ML.NET.

____

На основе модуля CV мы организовали пайплайн в рамках которого инициатором вывоза мусора является обученная модель:

CV => Оператор(валидация результата для дальнейшего дообучения) => Водитель мусоровоза(статус выполнения также отслеживается по камерам)

____

Ссылки на проекты нейронных сетей:
- https://github.com/andreifarafonow/DogDetection
- https://github.com/andreifarafonow/GunDetect
- https://github.com/andreifarafonow/MLTrashDetect


Стек исползованных технологий:
- Pixellib 
- ASP.NET
- ML.NET
- Tenserflow
- Python
