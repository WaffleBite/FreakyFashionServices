FROM nginx:latest

# Ändrar working directory
WORKDIR /usr/share/nginx/html

# Kopiera över filen till container
COPY . .