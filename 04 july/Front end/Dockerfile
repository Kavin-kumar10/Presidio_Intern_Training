FROM node:alpine

WORKDIR /app

EXPOSE 3030

RUN npm install -g nodemon

COPY package.json /app

RUN npm install

COPY . /app

CMD [ "npm","run","dev" ]