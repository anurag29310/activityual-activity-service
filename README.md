# Activityual Service READMEs

# 1. Activityual Identity Service README

````md
# Activityual Identity Service

## Overview

The Identity Service is responsible for authentication and authorization within the Activityual platform.

Features:
- User Registration
- User Login
- JWT Authentication
- Secure Password Handling
- Stateless Authentication

---

## Tech Stack

- ASP.NET Core Web API
- JWT Authentication
- PostgreSQL
- Docker
- Kubernetes

---

## GitHub Repository

https://github.com/anurag29310/activityual-identity-service

---

## API Endpoints

### Register User

POST /api/Auth/register

Request:

```json
{
  "email": "user@test.com",
  "password": "Password@123"
}
````

---

### Login User

POST /api/Auth/login

Request:

```json
{
  "email": "user@test.com",
  "password": "Password@123"
}
```

---

## Run Locally

```bash
 git clone https://github.com/anurag29310/activityual-identity-service
 cd activityual-identity-service
 dotnet restore
 dotnet run
```

---

## Docker Build

```bash
 docker build -t activityual-identity-service .
```

---

## Kubernetes Deployment

```bash
 kubectl apply -f k8s/
```

---

## Environment Variables

| Key               | Description                  |
| ----------------- | ---------------------------- |
| JWT_SECRET        | JWT Secret Key               |
| CONNECTION_STRING | PostgreSQL Connection String |

---

## Features

* JWT Token Generation
* Secure Authentication
* Cloud Native Ready
* Kubernetes Deployable

````

---

# 2. Activityual Activity Service README

```md
# Activityual Activity Service

## Overview

The Activity Service manages user activities, tracking, analytics, and progress monitoring.

Features:
- Activity CRUD Operations
- Daily Tracking
- Weekly Tracking
- Activity Analytics
- Streak Monitoring
- Consistency Analysis

---

## Tech Stack

- ASP.NET Core Web API
- PostgreSQL
- RabbitMQ
- Docker
- Kubernetes

---

## GitHub Repository

https://github.com/anurag29310/activityual-activity-service

---

## API Endpoints

### Activities APIs

| Method | Endpoint |
|---|---|
| GET | /api/Activities/getActivity |
| POST | /api/Activities/addActivity |
| PATCH | /api/Activities/updateActivity |
| DELETE | /api/Activities/removeActivity |

---

### Tracking APIs

| Method | Endpoint |
|---|---|
| POST | /api/Tracking/addTracking |
| GET | /api/Tracking/trackingData |

---

### Analytics APIs

| Method | Endpoint |
|---|---|
| GET | /api/Analytics/summary |
| GET | /api/Analytics/streaks |
| GET | /api/Analytics/consistency |
| GET | /api/Analytics/missed |

---

## Run Locally

```bash
 git clone https://github.com/anurag29310/activityual-activity-service
 cd activityual-activity-service
 dotnet restore
 dotnet run
````

---

## Docker Build

```bash
 docker build -t activityual-activity-service .
```

---

## RabbitMQ Integration

Activity completion events are published to RabbitMQ for:

* Recommendation Engine
* AI Coach Embedding Pipeline
* Analytics Processing

---

## Kubernetes Deployment

```bash
 kubectl apply -f k8s/
```

---

## Features

* Event Driven Architecture
* Real Time Tracking
* Analytics Engine
* RabbitMQ Producer
* Scalable Microservice

````

---

# 3. Activityual Recommendation Service README

```md
# Activityual Recommendation Service

## Overview

The Recommendation Service generates personalized activity timing and frequency recommendations based on user activity history.

Features:
- Timing Recommendations
- Frequency Optimization
- Personalized Suggestions
- Recommendation Acceptance Workflow

---

## Tech Stack

- ASP.NET Core Web API
- PostgreSQL
- RabbitMQ
- Docker
- Kubernetes

---

## GitHub Repository

https://github.com/anurag29310/activityual-recommendation-service

---

## API Endpoints

### Compute Recommendation

POST /api/Recommendations/compute

Request:

```json
{
  "userId": "guid",
  "activityId": "guid"
}
````

---

### Get Recommendations

GET /api/Recommendations/{userId}

---

### Accept Recommendation

POST /api/Recommendations/accept

Request:

```json
{
  "userId": "guid",
  "recommendationId": "guid",
  "accepted": true
}
```

---

## Recommendation Logic

The service analyzes:

* Completion Rate
* Time of Day Patterns
* Weekly Completion Trends
* Missed Activity Frequency

Example:

* Morning workouts perform better than evening workouts.
* Reading habits perform better on weekends.

---

## Run Locally

```bash
 git clone https://github.com/anurag29310/activityual-recommendation-service
 cd activityual-recommendation-service
 dotnet restore
 dotnet run
```

---

## Docker Build

```bash
 docker build -t activityual-recommendation-service .
```

---

## Features

* AI-based Recommendations
* RabbitMQ Consumer
* Event Driven Processing
* Kubernetes Deployable

````

---

# 4. Activityual AI Coach Service README

```md
# Activityual AI Coach Service

## Overview

The AI Coach Service provides conversational AI coaching using user activity history.

Features:
- AI Habit Coaching
- Personalized Guidance
- Retrieval Augmented Generation (RAG)
- Embedding Pipeline
- Activity Pattern Analysis

---

## Tech Stack

- ASP.NET Core Web API
- Ollama
- Chroma / FAISS
- RabbitMQ
- Docker
- Kubernetes

---

## GitHub Repository

https://github.com/anurag29310/activityual-ai-coach-service

---

## API Endpoint

### Ask Coach

POST /api/Coach/askCoach

Request:

```json
{
  "userId": "guid",
  "question": "Why do I keep missing my workout?"
}
````

---

## RAG Workflow

1. User asks a question.
2. Activity logs are converted into embeddings.
3. Relevant embeddings are retrieved.
4. Context is sent to Ollama.
5. AI response is generated.

---

## Embedding Pipeline

Triggered whenever:

* Activity completed
* Activity missed
* Tracking updated

RabbitMQ events are consumed and converted into vector embeddings.

---

## Run Locally

```bash
 git clone https://github.com/anurag29310/activityual-ai-coach-service
 cd activityual-ai-coach-service
 dotnet restore
 dotnet run
```

---

## Docker Build

```bash
 docker build -t activityual-ai-coach-service .
```

---

## Features

* Conversational AI
* Local LLM Integration
* Vector Search
* RAG Architecture
* RabbitMQ Consumer

````

---

# 5. Activityual API Gateway README

```md
# Activityual API Gateway

## Overview

The API Gateway acts as the single entry point for all backend microservices.

Features:
- Centralized Routing
- JWT Authentication Forwarding
- Reverse Proxy
- API Aggregation
- Unified Access Layer

---

## Tech Stack

- ASP.NET Core Gateway
- YARP / Ocelot
- Docker
- Kubernetes

---

## GitHub Repository

https://github.com/anurag29310/activityual-api-gateway

---

## Microservices Connected

- Identity Service
- Activity Service
- Recommendation Service
- AI Coach Service

---

## API Gateway Routes

| Service | Route |
|---|---|
| Identity Service | /api/Auth/* |
| Activity Service | /api/Activities/* |
| Analytics Service | /api/Analytics/* |
| Tracking Service | /api/Tracking/* |
| AI Coach Service | /api/Coach/* |
| Recommendation Service | /api/Recommendations/* |

---

## Run Locally

```bash
 git clone https://github.com/anurag29310/activityual-api-gateway
 cd activityual-api-gateway
 dotnet restore
 dotnet run
````

---

## Docker Build

```bash
 docker build -t activityual-api-gateway .
```

---

## Kubernetes Deployment

```bash
 kubectl apply -f k8s/
```

---

## Features

* Centralized API Management
* Secure Routing
* Scalable Gateway
* Kubernetes Ready

```
```
