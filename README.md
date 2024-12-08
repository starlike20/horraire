# Projet ClassLibrary1

## Description

Ce projet est une application basée sur .NET, combinant une bibliothèque de classes en Visual Basic et une interface WPF (Windows Presentation Foundation). Il est conçu pour les environnements Windows et inclut une architecture modulaire pour les fonctionnalités backend et frontend.

---

## Fonctionnalités

- **Bibliothèque de classes** : Fonctionnalités principales écrites en Visual Basic.
- **Interface WPF** : Interface graphique moderne (GUI) utilisant XAML.
- **Gestion des événements** : Logique pour gérer les interactions utilisateur et la présentation des données.
- **Composants personnalisés** : Conçus pour être réutilisables et modulaires.

---

## Structure du projet

### 1. **Bibliothèque de classes**
- Située dans le répertoire `ClassLibrary1`.
- Les fonctionnalités principales sont implémentées dans `Class1.vb`.

### 2. **Application WPF**
- Située dans le répertoire `horraiview`.
- Éléments de l'interface utilisateur et logique de l'application :
  - `MainWindow.xaml` : Interface utilisateur principale.
  - `calendrier.xaml` : Composants liés au calendrier.
  - `reservation.xaml` : Interface de réservation.

### 3. **Artéfacts de compilation**
- Les binaires de sortie sont générés dans le répertoire `bin/Debug/net8.0-windows`.

---

## Prérequis

- **Système d'exploitation Windows** : Requis pour les applications WPF.
- **SDK .NET 8.0** : Pour compiler et exécuter le projet.
- **Visual Studio** : Recommandé pour le développement et le débogage.

---

## Installation et exécution

### 1. **Cloner le dépôt**
```bash
git clone <url-du-depôt>
```

### 2. **Ouvrir dans Visual Studio**
- Ouvrez le fichier solution ou les fichiers de projet (`.vbproj` et `.csproj`) dans Visual Studio.
- Assurez-vous que le SDK .NET 8.0 est correctement configuré.

### 3. **Compiler et exécuter**
- Utilisez les options de compilation de Visual Studio pour compiler le projet.
- Lancez l'application en utilisant le bouton `Start` ou en exécutant l'exécutable généré dans le dossier `bin/Debug/net8.0-windows`.

---

## Contribution

Les contributions sont les bienvenues. Pour contribuer :
1. Forkez le dépôt.
2. Créez une branche pour votre fonctionnalité : `git checkout -b feature/NouvelleFonctionnalite`.
3. Commitez vos modifications : `git commit -m 'Ajout d\'une nouvelle fonctionnalité'`.
4. Poussez la branche : `git push origin feature/NouvelleFonctionnalite`.
5. Soumettez une Pull Request.

---

## Auteurs
Ce projet a été développé par [Votre Nom/Équipe].

---

## Licence
Ce projet est sous licence MIT. Consultez le fichier `LICENSE` pour plus de détails.

