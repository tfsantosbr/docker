FROM mongo

COPY players.json /players.json
COPY teams.json /teams.json

CMD mongoimport --host mongodb --db nba --collection players --drop --type json --file /players.json --jsonArray && \
    mongoimport --host mongodb --db nba --collection teams --drop --type json --file /teams.json --jsonArray