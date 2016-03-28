FROM microsoft/aspnet:1.0.0-rc1-update1

ARG tag
ARG dnxcache
ARG dnxcacheindocker
ENV TAG=$tag
#ENV DNX_CAHCE=$dnxcache
#ENV DNX_CAHCE_IN_DOCKER=$dnxcacheindocker

COPY . /app
WORKDIR /app

#COPY $DNX_CAHCE $DNX_CAHCE_IN_DOCKER

RUN ["dnu", "restore"]

EXPOSE 5000
CMD sh scripts/start "${TAG}"
