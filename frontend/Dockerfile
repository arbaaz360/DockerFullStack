FROM node:alpine

WORKDIR '/app'

COPY ./package.json .

EXPOSE 4200

RUN npm i

COPY . .

CMD ["npm","start"]
