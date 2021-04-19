FROM nginx:1.18-alpine

WORKDIR /etc/nginx/conf.d

COPY Nginx/nginx.conf .

RUN mv nginx.conf default.conf