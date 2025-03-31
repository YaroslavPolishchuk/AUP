### Опис 

- postCityV2.csv – дані для таблиці міст(City)
- postRAJ.csv – дані для таблиці районів(Raj)
- postOBL.csv – дані для таблиці областей(Obl)
- upostdata – підготовлені дані з https://index.ukrposhta.ua/find-post-index.

## Інструкція для запуску проекту

```docker build -t postgres .```  
```docker run --rm -it -d -p 5432:5432 --name ukrpostgres postgres```  
*В результаті отримуємо базу даних на хості `localhost:5432` з попередньо завантаженими даними з SQL скрипта*  
*Для запуску веб-додатку*  
```dotnet run --project AUP/WebApp.csproj```

--------------------------------------------------------------------------------------------------------------------------------------


### File Description

- postCityV2.csv – data for the cities table(City)
- postRAJ.csv – data for the districts table(Raj)
- postOBL.csv – data for the regions table(Obl)
- upostdata – prepared data from https://index.ukrposhta.ua/find-post-index.

## Instructions to Run the Project  
```docker build -t postgres .```  
```docker run --rm -it -d -p 5432:5432 --name ukrpostgres postgres``` 
*As a result, you'll have a PostgreSQL database running on localhost:5432 with pre-loaded data from the SQL script*  
*To run the web application*  
```dotnet run --project AUP/WebApp.csproj```
