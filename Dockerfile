FROM microsoft/aspnet:1.0.0-rc1-update1

COPY . /app
WORKDIR /app

RUN ["dnu", "restore"]
RUN ["dnx", "ef", "migrations", "add", "first"]

CMD ["dnx", "ef", "database", "update"]

EXPOSE 5000
ENTRYPOINT ["dnx", "-p", "project.json", "web"]
