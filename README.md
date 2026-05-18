# Activityual Service READMEs
---

# 1. Activityual Activity Service README

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

```
```
