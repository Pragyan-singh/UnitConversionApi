Here is the complete `README.md` content rewritten in an alternative, highly scannable **Grid & Component-Based Format**. This format uses clean visual blocks, technical badges, and structured tables, which developer teams highly favor for quick reading during code reviews.

You can copy and paste this directly into your root `README.md` file:

---

# 📊 Unit Conversion Web API

> **Production-Ready ASP.NET Core Engine for Dynamic Measurement Conversions**

A highly scalable, multi-developer aligned HTTP RESTful API built to handle seamless conversions across distinct units of measurement. The system decouples business math from the hosting infrastructure, satisfying the immediate scope while natively preparing the application to scale to hundreds of custom units.

---

## 🏗️ System Architecture Overview

The solution splits concerns into two isolated, independent compilation layers to ensure modular maintainability:

```
      [ Client Requests ]
              │
              ▼
┌───────────────────────────┐
│  UnitConversionSystem.Api │ <── Handles Routing, Middleware, Validation
└─────────────┬─────────────┘
              │ (Project Reference)
              ▼
┌───────────────────────────┐
│ UnitConversionSystem.Core │ <── Strategy Contracts & Mathematical Engine
└───────────────────────────┘

```

| Component Layer | Responsibility | Technology Highlights |
| --- | --- | --- |
| <br>**`System.Api`** 

 | Request validation, HTTP routing, runtime serialization, and uniform global error handling middleware. | ASP.NET Core Controllers, Swagger/OpenAPI, Custom Exception Pipeline |
| **`System.Core`** | Domain state definitions, strategy execution interfaces, and rigid math processing rules. | Pure C# (No Web Dependencies), Strategy Pattern, LINQ-driven DI Factory |

---

## 🛠️ Deep Dive: Design Decisions & Trade-offs

### 1. The Strategy Pattern for Future-Proof Scalability

* 
**Decision:** Instead of using nested conditional routing (`if/else` or large `switch` blocks) inside the controller layer, every conversion dimension (Length, Temperature, Weight) is isolated inside an autonomous class implementing `IConversionStrategy`.


* **Trade-off:** This introduces more individual files initially. However, it perfectly answers the requirement to support **hundreds of units** in future updates. A developer can introduce a completely new conversion category by dropping in a single class without altering a single line of existing code.



### 2. Isolated Static Dictionaries vs. Database State

* 
**Decision:** Conversion factors are securely hardcoded within static dictionary structures inside their specific domain strategies.


* 
**Trade-off:** While a database provides runtime mutability, hardcoded dictionaries satisfy the baseline specifications with zero external infrastructure overhead (no database setup required to run locally). Because the strategy interfaces isolate this data, swapping this out for an Entity Framework Core SQL layer later requires zero changes to the API endpoints.



### 3. Resilience via Custom Pipeline Middleware

* **Decision:** Bypassed native framework error tracking to insert a global custom `ExceptionMiddleware`.
* **Benefit:** If an invalid unit combination or bad payload is sent, the engine intercepts the runtime error and structures a standard `400 Bad Request` JSON validation block, preventing structural data leaks.

---

## 🚀 Local Deployment Guide

### Prerequisites

* 
**.NET SDK 8.0 / 9.0** (Stable compiler) 


* A standard terminal terminal environment

### Operational Commands

```bash
# 1. Clone and enter project workspace
cd UnitConversionSystem

# 2. Compile solution and verify references
dotnet build

# 3. Launch the API hosting environment
dotnet run --project UnitConversionSystem.Api/UnitConversionSystem.Api.csproj

```

### 🛰️ Interactive API Testing

Once the server boot sequence completes, extract the local hosting port from your terminal console outputs (e.g., `https://localhost:7123`) and access the live API sandbox environment via web browser:

```
https://localhost:<YOUR_PORT>/swagger

```

---

## 📐 Supported Core Capabilities

The engine safely handles standard and shorthand naming conventions across multiple structural dimensions:

| Category 

 | Base Pivot | Supported Unit Identifiers |
| --- | --- | --- |
| 📏 **Length** 

 | Meter | <br>`meter`, `meters`, `m`, `foot`, `feet`, `ft`, `inch`, `inches`, `in` 

 |
| 🌡️ **Temperature** 

 | Celsius | <br>`celsius`, `c`, `fahrenheit`, `f`, `kelvin`, `k` 

 |
| ⚖️ **Weight / Mass** 

 | Kilogram | <br>`kilogram`, `kilograms`, `kg`, `pound`, `pounds`, `lbs`, `gram`, `grams`, `g` 

 |

Example Payload (`POST /api/v1/Conversion/convert`) 

```json
{
  "value": 180,
  "fromUnit": "cm",
  "toUnit": "m",
  "category": "Length"
}

```