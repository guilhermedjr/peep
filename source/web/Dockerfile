# Dockerfile

# base image
FROM node:10

# create & set working directory
RUN mkdir -p /usr/src
WORKDIR /usr/src

# copy source files
COPY . /usr/src

# copy dependencies
COPY package*.json ./

# install dependencies
RUN npm install

# start app
RUN npm run build
EXPOSE 3000
CMD npm run start dev