# Recipes-MobileApp
To use the app :

1. Have Docker Engine on your machine.

2. `docker-compose up`

2.1. The first time, you have to migrate the database. To do so:

`docker exec -it cookus-migration /root/.dotnet/tools/dotnet-ef database update`

3. Finally, run the CookUs app.
