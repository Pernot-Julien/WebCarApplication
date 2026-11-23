# WebCarApplication

## Présentation

WebCarApplication est une application web développée avec ASP.NET Core MVC permettant de gérer un parc de véhicules d'occasion.

L'application propose un catalogue de voitures avec leurs caractéristiques, leurs finitions, leurs photos et leur prix de vente.

## Fonctionnalités

- Consultation du catalogue des véhicules.
- Affichage des caractéristiques détaillées d'une voiture.
- Gestion des marques, modèles et finitions.
- Ajout, modification et suppression de véhicules.
- Gestion de la disponibilité et du statut de vente.
- Gestion des photos des véhicules.
- Gestion des réparations et de leurs coûts.
- Calcul automatique du prix de vente à partir du prix d'achat, des réparations et de la marge bénéficiaire.
- Authentification des utilisateurs.

### Gestion des accès

- Les visiteurs non connectés peuvent consulter les véhicules disponibles.
- Un utilisateur connecté dispose des fonctionnalités de gestion des véhicules.

## Technologies utilisées

- **C#**
- **.NET 8**
- **ASP.NET Core MVC**
- **Entity Framework Core**
- **SQL Server Express**
- **ASP.NET Core Identity**
- **Razor / HTML / CSS / JavaScript**

## Architecture du projet

Le projet suit une organisation séparant les différentes responsabilités :

- `Controllers` : gestion des requêtes et des actions de l'application.
- `Models/Entities` : entités métier.
- `Models/Repositories` : accès aux données.
- `Models/Services` : logique métier.
- `Models/ViewModels` : modèles destinés aux vues.
- `Data` : contexte Entity Framework Core et initialisation des données.
- `Views` : interfaces Razor.
- `wwwroot` : fichiers statiques (CSS, JavaScript et images).

## Dépôt Git

Le code source du projet est disponible sur le dépôt Git suivant :

**Lien du dépôt : https://github.com/Pernot-Julien/WebCarApplication

**Branche de développement : `dev`

Pour récupérer le projet depuis cette branche :

```bash
git clone -b dev https://github.com/Pernot-Julien/WebCarApplication.git
```

La branche `dev` contient la version de développement de l'application.

## Prérequis

Avant de lancer le projet, il faut disposer de :

- Visual Studio 2022.
- .NET 8 SDK.
- SQL Server Express.
- SQL Server Management Studio (SSMS), pour consulter et gérer la base de données.

## Installation et lancement

### 1. Récupérer le projet

Cloner le dépôt Git ou ouvrir directement la solution dans Visual Studio.

### 2. Configurer la connexion à la base de données

Dans le fichier `appsettings.json`, vérifier la chaîne de connexion :

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.\\SQLEXPRESS;Database=WebCarApplicationDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
  }
}
```

Adapter le nom du serveur SQL si nécessaire.

### 3. Lancer l'application

Ouvrir la solution dans Visual Studio :

1. Définir `WebCarApplication` comme projet de démarrage.
2. Vérifier la configuration de connexion à SQL Server.
3. Lancer l'application avec **F5** ou **Ctrl + F5**.

Au démarrage, l'application applique automatiquement les migrations Entity Framework Core et initialise les données de démonstration.

## Initialisation de la base de données

La classe `DatabaseSeeder.cs` permet d'initialiser automatiquement la base de données.

Elle crée notamment :

- 11 marques.
- 17 modèles.
- 33 finitions.
- 33 associations entre modèles et finitions.
- 17 véhicules.
- 17 photos.
- 6 réparations.
- 1 compte utilisateur de démonstration.

Les photos sont stockées dans `wwwroot/images/voitures`. Seul leur chemin d'accès est enregistré en base de données.

## Compte de démonstration

Un compte utilisateur est créé automatiquement lors de l'initialisation de la base :

| Information | Valeur |
|---|---|
| Adresse e-mail | admin@admin.com |
| Mot de passe | Admin123! |

**Attention :** ces identifiants sont réservés à la démonstration et ne doivent pas être utilisés en production.

## Calcul du prix de vente

Le prix de vente est calculé automatiquement selon la formule suivante :

**Prix de vente = Prix d'achat + Coût total des réparations + Marge bénéficiaire**

La marge bénéficiaire est définie dans les paramètres de l'application.

## Remarque

Ce projet est réalisé dans le cadre d'une formation au développement .NET. Les données présentes dans la base sont des données de démonstration.