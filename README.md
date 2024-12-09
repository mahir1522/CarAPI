# Car API

A simple API for managing cars using C# Web API

# Endpoints

# 1. Get All Cars 

- `GET /api/cars`
- Response: Returns a list of all cars.

# 2. Get Car by id 

- `GET /api/cars/{id}`
- Returns the car with the specified ID or a 404 if not found

# 3. Add new car with new id 

- `POST /api/cars`
## Body
```
{
    "make": "Toyota",
    "model": "Corolla",
    "year": "2023"
}
```


- Response: Returns the newly created car

# 4. Edit existing car by id

- `PUT /api/cars/{id}`

## Body
```
{
    "make": "Toyota",
    "model": "Corolla",
    "year": "2025"
}
```
- Response: Returns edited car 

# 5. Delete existing car by id

- `DELETE /api/cars/{id}`
- Response: Confirms car has been deleted




