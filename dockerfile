FROM node:14

WORKDIR /app

COPY package*.json ./

RUN npm install

COPY . .

RUN npm run build

EXPOSE 3000

# Comando para iniciar la aplicación
CMD ["npm", "start"]
