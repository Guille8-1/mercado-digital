<div align="center">

# 🛒 Mercado Digital

### Mercado Digital: Sistema de Inventario para Logística y Control de inventario 

<p align="center">
  <img src=https://raw.githubusercontent.com/Hyuukai/Readme/refs/heads/main/Isologo%20(1).png>
</p>

![C#](https://img.shields.io/badge/C%23-.NET-512BD4?style=for-the-badge&logo=csharp&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual%20Studio-2026-5C2D91?style=for-the-badge&logo=visualstudio&logoColor=white)
![GitHub](https://img.shields.io/badge/GitHub-Repository-181717?style=for-the-badge&logo=github)


---
## DATOS DEL PROYECTO
| Campo  | Informacion
| ------------- |:-------------:|
| Modulo      |Programación II    |
| Docente     | Lic. Andrés Grover Albino Chambi     |
|Período      |             Octubre 2026  |
| Estudiantes |   Aramayo Mengoa Carlos Guillermo   |
|Tecnologías  |    C# (.NET)          |


## Estructura Del Proyecto

<div align="left">

## Índice
- [1. Introducción](#1-introducción)
  - [1.1 Contexto General](#11-contexto-general)
  - [1.2 Problemática](#12-problemática)
  - [1.3 Justificación](#13-justificación)
  - [1.4 Alcance](#14-alcance)
  - [1.5 Limitaciones](#15-limitaciones)
  - [2. Objetivos](#2-objetivos)
  - [2.1 Objetivo General](#21-objetivo-general)
  - [2.2 Objetivos Específicos](#22-objetivos-específicos)

- [3. Marco Teórico](#3-marco-teórico)
  - [3.1 Programación Orientada a Objetos (POO)](#31-programación-orientada-a-objetos-poo)
  - [3.2 Estructuras (Structs)](#32-estructuras-structs)
  - [3.3 Persistencia de Datos en Archivos Planos (CSV y TXT)](#33-persistencia-de-datos-en-archivos-planos-csv-y-txt)
  - [3.4 Matrices Bidimensionales](#34-matrices-bidimensionales)
  - [3.5 Manejo de Excepciones y Validación de Datos](#35-manejo-de-excepciones-y-validación-de-datos)

- [4. Desarrollo del Proyecto](#4-desarrollo-del-proyecto)
  - [4.1 Descripción General del Sistema](#41-descripción-general-del-sistema)
  - [4.2 Estructura del Sistema](#42-estructura-del-sistema)
  - [4.3 Gestión de Puntos de Recolección](#43-gestión-de-puntos-de-recolección)
  - [4.4 Creación y Validación de Rutas Logísticas](#44-creación-y-validación-de-rutas-logísticas)
  - [4.5 Matriz de Cobertura y Control Semanal](#45-matriz-de-cobertura-y-control-semanal)
  - [4.6 Reportes y Estadísticas](#46-reportes-y-estadísticas)

- [5. Tecnologías Utilizadas](#5-tecnologías-utilizadas)

- [6. Conclusiones y Recomendaciones](#6-conclusiones-y-recomendaciones)
  - [6.1 Conclusiones](#61-conclusiones)
  - [6.2 Recomendaciones](#62-recomendaciones)
  
<a id="introduccion"></a>

# 1. Introducción


## 1.1 Contexto General

La gestion, logistica y control de inventarios en los mercados populares de la ciudad de la paz son precarios y carecen de un control optimo. Muchos comerciantes recurren al control manual y rudimentario de los invetarios disponibles a la venta. El presente trabajo propone un sistema que optimice esos procedimientos.

## 1.2 Problematica

La mayoria de comerciantes no conce el impacto de un control de inventarios. Muchos productos no cuentan con un ciclo de vida o un control automatizado y preciso, que permita que el control de los activos de un negocio tengan seguimiento.

## 1.3 Justificacion

El presente trabajo se justifica por el control que ofrece en un negocio dado. El cual optimiza el control de inventarios y caja. En negocios pequnios y medianos.

## 1.4 Alcance

El sistema Mercado Digital tiene por objetivo dos clientes negocios pequenios y medianos. Estos dos clientes representan el flujo de datos para lo que esta pensado Mercado Digital.

## 1.5 Limitaciones

El software Mercado Digital encuentra limitaciones en la cantidad de datos a procesar. Cabe mencionar que se basa en un entorno de consola lo que limita su aplicacion a negocios con inventarios robustos y con mayor trafico de datos.

# 2 Objetivos

## 2.1 Objetivos General

Desarrollo de una aplicacion de consola que premita gestionar y administrar inventarios y caja de negocios pequenios y medianos. Optimizando el control y ciclo de vida de los productos comercializados por el cliente.

## 2.2 Objetivos Especificos

-	Registrar y validar los productos ingresados, determinar el stock disponible por cada producto.
-	Implementar un sistema robusto de Control de inventarios haciendo uso de Estructuras de Datos.
- Establecer un umbral de alerta para notificar a los clientes cuando un producto esta bajo en cantidad disponible.
- Controlar el flujo de productos ejecutando funciones que descuentan inventario.

# 3 Marco Teorico

## 3.1 Programacion Orientada A Objetos (POO)

Es un paradigma de programacion basado la estructura del codigo en clases, structs, atributos y metodos. Esto se consigue haciendo una abstraccion del mundo real, bajo las reglas de la programacion orientada a objetos.

## 3.2 Estructuras o Structs

Existen en otros lenguajes de programcion siendo un concepto comun dentro de la programacion orientada a objetos. Son de utilidad para agrupar datos relacionados.

## 3.3 Estructuras de Datos

Uso amplio de estructuras de datos conocidas como pilas, colas, listas, listas enlazadas, lista doblemente enlazadas. Este proyecto usa estas estructuras de datos para aplicar la logica del negocio.

# 4 Desarrollo del proyecto

## 4.1 Descripcion general del sistema

Esta aplicacion de consola se desarrolla bajo el lenguaje de programacion C# un lenguaje patrocinado por microsoft que no es lo mismo que c++ pero comparte ciertos conceptos. La presente aplicacion presenta soluciones para el manejo de inventarios y promueve la mejora y optimizacion del ciclo de vida de los productos dentro de un negocio comercial pequnio o mediano.

La logica de negocio consiste en optimizar el control tanto de mercancia como de caja, mostrando detalles de venta y detalles sobre el stock restante despues de una venta y registrando movimientos dentro del historial diario de un almacen o negocio.

## 4.2 Descripcion general del sistema

El sistema esta organizado medinate clases y estructuras de datos implementadas para el optimo flujo y procesamiento de datos.
  • MENU DE OPCIONES punto de entrada de la aplicacion.
  • Control de Inventarios Umbral de alertas cuando el stock de un item esta bajo en cantidad.
  • Registro De Caja, un registro que permite tener un registro de los ingresos del negocio.
  • Ciclo de atencion al cliente, cada cliente tiene un turno y un ciclo de atencion.
  • Cierre de venta y opcion a deshacer la venta, funcionalidad que permite ejecutar una venta y tambien revertir en caso de ser necesario

## 4.3 Manejo de Datos

Para fines demostrativos es necesario cargar datos mediante codigo. La applicacion usa los datos (dummy data) dentro de la duracion de la demostracion, una vez la apliacion haya concluido o el usuario haya cerrado la aplicacion no rentendra estos datos.

##  5. Tecnologías Utilizadas
-	Lenguaje: C# (.NET) 
-	Paradigma: Programación Orientada a Objetos
-	Entorno de Desarrollo (IDE): Visual Studio Code Insiders
-	Control de versiones: Git y GitHub

##  6. Conclusiones y Recomendaciones

## 6.1 Conclusiones
El desarrollo de Mercado Digital demuestra la necesidad de los comerciantes de utilizar un sistema que permita el control optimo de cantidades. Asi como el control de caja y la logistica necesaria para mantener un comercio.

##  6.2 Recomendaciones
Se recomienda desarrollar una interfaz gráfica de usuario (GUI) o web que facilite la visualización de los productos y el control de los productos por el usuario. Tambien se necesita una persistencia de datos como ser MySQL o PostgreSQL que permita al usuario acceder a reportes y datos estadisticos.