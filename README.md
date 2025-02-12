1.Для запуска необходимо создать базу Postgre, в appsettings.Development.json в ConnectionStrings -> DefaultConnection указать данные от бд.
2. Вызвать миграцию, открываем консоль переходим по пути где лежит библиотека классов "DataBase"
   2.3 Вызвать в консоле команду dotnet ef migrations add InitialCreate  (произойдет подготовка к накату)
   2.4 Вызвать dotnet ef database update (произойдет миграция в базу)

3. Seed лежат в Infrastructure при желании можно их изменить.
