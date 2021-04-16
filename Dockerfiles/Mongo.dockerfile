FROM mongo

COPY MongoDB/init_script.js /docker-entrypoint-initdb.d/