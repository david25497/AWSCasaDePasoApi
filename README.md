# CasaDePasoAWSDemo

Proyecto backend desarrollado en **.NET 8** para la gestión de una casa de paso para pacientes. Implementa una arquitectura limpia (**Clean Architecture**), con capas bien definidas, modularidad y separación de responsabilidades.

🔗 **API en producción:** [https://justodigital.com/swagger/index.html](https://justodigital.com/swagger/index.html)

---

## 📦 Arquitectura del Proyecto

Estructura basada en Clean Architecture:

```
Source/
├── Core/
│   ├── CasaDePasoAWSDemo.Core.Application/
│   │   ├── Config/
│   │   ├── DTOs/
│   │   ├── Interfaces/
│   │   └── Services/
│   └── CasaDePasoAWSDemo.Core.Domain/
│       └── Modules/
│           └── Login/
├── Infrastructure/
│   └── CasaDePasoAWSDemo.Core.Infrastructure/
│       ├── Configurations/
│       ├── Context/
│       └── Repositories/
└── Presentation/
    └── CasaDePasoAWSDemo.Presentation.Api/
        └── Controllers/
```

---

## ⚙️ Tecnologías utilizadas

- .NET 8
- PostgreSQL
- Entity Framework Core
- JWT para autenticación
- GitHub Actions para CI/CD
- NGINX como proxy inverso
- Certificados SSL instalados en EC2
- S3 (AWS) para backups automáticos
- EC2 Linux para hosting de API

---

## 🔐 Seguridad

- Autenticación con **JWT**
- Datos sensibles gestionados con **GitHub Secrets**
- HTTPS mediante certificados SSL en EC2
- Backups `.dump` automáticos enviados a S3 con cron

---

## 🚀 CI/CD

El despliegue se gestiona automáticamente con **GitHub Actions**:

- Build del proyecto
- Generación de `appsettings.json` a partir de secretos
- Copia de archivos por SSH
- Reinicio del servicio en EC2

---

## ☁️ Backups

Se configuró un **bash script** en la instancia EC2 que:

- Genera respaldo de la base de datos PostgreSQL en formato `.dump`
- Envía el archivo al bucket de S3
- Elimina backups antiguos semanalmente
- Programado con `cron`

---

## 🔧 Endpoints activos

- `POST /api/Login`: Autenticación de usuarios (retorna JWT)

> Otros endpoints como gestión de pacientes, acompañantes y transporte serán añadidos próximamente.

---

## 🧑‍🎨 Frontend

Este repositorio contiene solo el backend.  
El frontend se desarrollará por separado usando **Angular** y **Tailwind CSS**.

---

## 📄 Licencia

Proyecto publico temporalmente para gestión interna de casas de paso.
