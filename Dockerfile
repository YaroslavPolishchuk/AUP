FROM postgres:latest

COPY postCity.csv /tmp/
COPY postCityV2.csv /tmp/
COPY postOBL.csv /tmp/
COPY postRAJ.csv /tmp/
COPY upostdata.csv /tmp/
COPY PresetScript.sql /docker-entrypoint-initdb.d/
COPY AUPSeeding.sql /docker-entrypoint-initdb.d/

ENV POSTGRES_USER=admin
ENV POSTGRES_PASSWORD=secret
ENV POSTGRES_DB=nib