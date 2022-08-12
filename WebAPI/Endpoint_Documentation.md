# Project Name

This is a Web API application based on REST API developed for a rent a car organization. It contains some endpoints for basic CRUD operations.

Endpoints are accessed via: {GATEWAY_BASE_URL}/api/

An example request to "list" endpoint:
https://localhost:7078/api/list (HTTP GET)

## Step 1: List Cars

Lists the cars. Some filters can be applied, but they are optional.

**HTTP Request Type:** GET

**URL:** {GATEWAY_BASE_URL}/api/list?brand={brand}&model={model}&productionYearMin={productionYearMin}&productionYearMax={productionYearMax}&bodyStyle={bodyStyle}&fuelType={fuelType}

### **Response:**

```json
[
    {
        "id": 67315,
        "slug": "volkswagen-passat-1,6-sedan-automatic-120-67315",
        "brand": "Volkswagen",
        "model": "Passat",
        "productionYear": 2017,
        "engineDisplacement": 1.6,
        "bodyStyle": 1,
        "color": "White",
        "fuelType": 2,
        "transmission": 2,
        "hp": 120
    },
    {
        "id": 34160,
        "slug": "ford-focus-1,5-stationwagon-automatic-120-34160",
        "brand": "Ford",
        "model": "Focus",
        "productionYear": 2020,
        "engineDisplacement": 1.5,
        "bodyStyle": 3,
        "color": "White",
        "fuelType": 2,
        "transmission": 2,
        "hp": 120
    },
    {
        "id": 12736,
        "slug": "peugeot-3008-1,6-suv-automatic-180-12736",
        "brand": "Peugeot",
        "model": "3008",
        "productionYear": 2022,
        "engineDisplacement": 1.6,
        "bodyStyle": 4,
        "color": "White",
        "fuelType": 1,
        "transmission": 2,
        "hp": 180
    },
    {
        "id": 57386,
        "slug": "renault-clio-1,2-hatchback-manual-75-57386",
        "brand": "Renault",
        "model": "Clio",
        "productionYear": 2018,
        "engineDisplacement": 1.2,
        "bodyStyle": 2,
        "color": "Red",
        "fuelType": 1,
        "transmission": 1,
        "hp": 75
    }
]
```

## Step 2: Get Car

You can fetch the details of a car with its ID.

**HTTP Request Type:** GET

**URL:** {GATEWAY_BASE_URL}/api/get/{id}

### **Response:**

```json
{
    "id": 67315,
    "slug": "volkswagen-passat-1,6-sedan-automatic-120-67315",
    "brand": "Volkswagen",
    "model": "Passat",
    "productionYear": 2017,
    "engineDisplacement": 1.6,
    "bodyStyle": 1,
    "color": "White",
    "fuelType": 2,
    "transmission": 2,
    "hp": 120
}
```

If no record is found with the provided ID, returns HTTP 404 Not Found status with an informative message.

## Step 3: Get Car By Slug

**HTTP Request Type:** GET

**URL:** {GATEWAY_BASE_URL}/api/{slug}

### **Response:**

```json
{
    "id": 67315,
    "slug": "volkswagen-passat-1,6-sedan-automatic-120-67315",
    "brand": "Volkswagen",
    "model": "Passat",
    "productionYear": 2017,
    "engineDisplacement": 1.6,
    "bodyStyle": 1,
    "color": "White",
    "fuelType": 2,
    "transmission": 2,
    "hp": 120
}
```

If no record is found with the provided slug, returns HTTP 404 Not Found status with an informative message.

## Step 4: Add A Car

Adds a car with the provided properties. All properties must be included in the URL.

**HTTP Request Type:** POST

**URL:** {GATEWAY_BASE_URL}/api/add?brand={brand}&model={model}&productionYear={productionYear}&engineDisplacement={engineDisplacement}&bodyStyle={bodyStyle}&color={color}&fuelType={fuelType}&transmission={transmission}&hp={hp}

### **Response:**

Returns the slug.

```
volkswagen-golf-1,6-hatchback-automatic-90-43225
```

If parameters are not valid or some are missing, returns Bad Request with an informative message.

## Step 5: Update a Car

Updates the car. Not only the updated properties, but all of them must be included in the URL as it is a PUT type request.

**HTTP Request Type:** PUT

**URL:** {GATEWAY_BASE_URL}/api/update?id={id}&brand={brand}&model={model}&productionYear={productionYear}&engineDisplacement={engineDisplacement}&bodyStyle={bodyStyle}&color={color}&fuelType={fuelType}&transmission={transmission}&hp={hp}

### **Response:**

```json
{
    "id": 43225,
    "slug": "volkswagen-golf-1,6-hatchback-automatic-90-43225",
    "brand": "Volkswagen",
    "model": "Golf",
    "productionYear": 2012,
    "engineDisplacement": 1.6,
    "bodyStyle": 2,
    "color": "Gray",
    "fuelType": 2,
    "transmission": 2,
    "hp": 90
}
```

If no record is found with the provided ID, returns HTTP 404 Not Found status with an informative message.

## Step 6: Delete A Car

Deletes a car.

**HTTP Request Type:** DELETE

**URL:** {GATEWAY_BASE_URL}/api/delete/{id}

### **Response:**

If successful, returns only HTTP 200 OK status, no content.

If no record is found with the provided ID, returns HTTP 404 Not Found status with an informative message.
