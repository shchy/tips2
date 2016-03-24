FROM microsoft/aspnet:1.0.0-rc1-update1

ARG tag
ARG dnxcache
ENV TAG=$tag
ENV DNX_CAHCE=$dnxcache

COPY . /app
WORKDIR /app

COPY $DNX_CAHCE /root/.dnx/packages

RUN ["dnu", "restore"]

EXPOSE 5000
CMD dnx -p src/TipsWeb/project.json ef migrations add "${TAG}" && \
    dnx -p src/TipsWeb/project.json ef database update && \
    dnx -p src/TipsWeb/project.json web
