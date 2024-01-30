FROM node:16.16-alpine

WORKDIR /orbita-challenge-project

COPY package*.json ./

RUN npm install

COPY . ./

CMD ["npm", "run", "serve"]
