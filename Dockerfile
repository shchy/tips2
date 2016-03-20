FROM microsoft/aspnet:1.0.0-rc1-update1

COPY . /app
WORKDIR /app

RUN ["dnu", "restore"]
RUN ["dnx", "ef", "migrations", "add", "first"]


EXPOSE 5000
CMD dnx ef database update && dnx -p project.json web
