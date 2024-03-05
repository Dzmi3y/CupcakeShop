FROM node:18 as build
WORKDIR /app
COPY /CupcakeShop.Client/package*.json ./
RUN npm install
COPY ./CupcakeShop.Client .
RUN npm run build
FROM nginx:alpine
COPY --from=build /app/build /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]