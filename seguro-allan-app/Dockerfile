### STAGE 1:BUILD ###
FROM node:14.20-alpine AS build

WORKDIR /dist/src/app

RUN npm cache clean --force

COPY seguro-allan-app/. .

RUN npm install

RUN npm run build --prod

### STAGE 2:RUN ###
FROM nginx:latest AS ngi

COPY --from=build /dist/src/app/dist/seguro-allan-app /usr/share/nginx/html
COPY seguro-allan-app/nginx.conf  /etc/nginx/conf.d/default.conf

EXPOSE 80
