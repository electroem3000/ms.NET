# Требования к проекту "Магазин косметики"

В проекте предусмотрены два типа пользователей: покупатель и модератор. Пользователь, не авторизованный в системе, имеет право просмотра всех предложений магазина. Покупатель может как приобретать косметические средства, так и просматривать историю своих покупок. Модератор имеет право создавать, изменять и удалять товары.

▎Основные функции, которые должны быть реализованы в проекте:

1. Регистрация пользователя.
   - На главной странице пользователю предлагается форма регистрации, которую он может пройти позже. Ссылка перехода на форму регистрации доступна неавторизованному пользователю на любой странице, а дополнительная отображается ему при попытке приобрести товар. 
   - Форма регистрации содержит поля для ввода имени пользователя (никнейма), даты рождения, электронной почты и пароля.
   - Учетная запись создается с помощью подтверждения по электронной почте.

2. Авторизация и деавторизация пользователя.
   - Основная ссылка перехода на форму входа доступна неавторизованному пользователю на любой странице, а дополнительная отображается ему при попытке приобрести товар. 
   - Для входа требуется ввести электронную почту и пароль.
   - Пользователь может выйти из системы, нажав на соответствующую ссылку на любой странице.

3. (INDEX) просмотр списка товаров.
   - Реализован поиск товаров по названию и фильтрам: категория (косметика для лица, для тела, для волос), бренд, цена, тип (крем, сыворотка, маска и т.д.).
   - Общий каталог товаров отсортирован по времени добавления.

4. CRUD:

   - (CREATE) создание товара.
     Модератор может добавить новый товар, заполнив поля: название, категория, бренд, цена, тип и описание.

   - (READ) просмотр деталей товара.
     Любой пользователь может просматривать характеристики товара, включая состав, способ применения и отзывы.
     Пользователь также может видеть историю своих покупок.

   - (UPDATE) редактирование товара.
     Модератор имеет право изменять характеристики любого товара при необходимости.

   - (DELETE) удаление товара.
     Модератор может удалить любой товар из каталога.

*Набор характеристик товара, их обязательность и соответствующие фильтры могут быть изменены в ходе разработки проекта.*
# Проектная база
![image](https://github.com/user-attachments/assets/21046190-2cb5-4295-8119-7da4f14abd5a)

