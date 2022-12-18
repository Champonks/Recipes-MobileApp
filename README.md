# Recipes-MobileApp
To use the app :

Have Docker Engine on your machine.

`docker-compose up`

The first time, you have to migrate the database. To do so:

`docker exec -it cookus-migration /root/.dotnet/tools/dotnet-ef database update`

Finally, run the CookUs app.
