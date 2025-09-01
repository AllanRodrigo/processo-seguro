# Use a Node.js base image, as JSON Server is a Node.js package
FROM node:lts-alpine

# Set the working directory inside the container
WORKDIR /app

# Install JSON Server globally
RUN npm install -g json-server

# Copy the JSON data file into the container
# Replace 'db.json' with the actual name of your JSON data file
COPY JsonServer/db.json /data/db.json

# Expose the port JSON Server will run on (default is 3000)
EXPOSE 3000

# Command to start JSON Server, pointing to the data file
CMD ["json-server", "--watch", "/data/db.json", "--host", "192.168.0.28"]