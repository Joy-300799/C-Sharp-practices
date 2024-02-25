## Run MongoDB with Docker
```
docker run -d --name ecomm-db -p 27017:27017 mongo:7
```

## Products-db:

```
docker run -d --name products-db -p 27017:27017 mongo:7
```

## DB Host (products):

```
export DB_HOST="mongodb://localhost:27017/"
```
