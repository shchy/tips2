FROM microsoft/aspnet:1.0.0-rc1-update1

ARG tag=latest

COPY . /app
WORKDIR /app

RUN ["dnu", "restore"]

EXPOSE 5000
CMD dnx -p src/TipsWeb/project.json ef migrations add ${tag} && \
    dnx -p src/TipsWeb/project.json ef database update && \
    dnx -p src/TipsWeb/project.json web
