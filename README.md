# ToDoListTracker
## Требования
.Net 6

Postgres с поддержкой UUID.

Установка расширений UUID в PostgreSQL: CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

## Install
Указать строку подключения к БД в файле appsetting.js.

Доступен по url: https://localhost:7068/swagger/index.html

## Методы
Search - имеет встроенные фильтры по полям. Регистрозависимый. 

``` "sortExpressions": [
{
      "direction": 0,
      "propertyName": "IsCompleted"
    },
    {
      "direction": 1,
      "propertyName": "Priority.Level"
    }
  ]
