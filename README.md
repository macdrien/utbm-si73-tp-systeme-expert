# 1. UTBM SI73 TP Systeme Expert

- [1. UTBM SI73 TP Systeme Expert](#1-utbm-si73-tp-systeme-expert)
  - [1.1. Contributeur](#11-contributeur)
  - [1.2. Documentation](#12-documentation)
    - [1.2.1. Schema](#121-schema)
    - [1.2.2. Faits](#122-faits)
    - [1.2.3. Regles](#123-regles)
    - [1.2.4. Moteur d'inferences](#124-moteur-dinferences)
  - [1.3. Exercice](#13-exercice)
  - [1.4. Algorithme](#14-algorithme)
  - [1.5. Architecture](#15-architecture)
  - [1.6. Utilisation de l'executable de la version 1.0.0](#16-utilisation-de-lexecutable-de-la-version-100)
    - [1.6.1. Fichiers de definition du systeme](#161-fichiers-de-definition-du-systeme)
    - [1.6.2. Fichiers de definition du systeme](#162-fichiers-de-definition-du-systeme)
  - [1.7. Utilisation de l'executable de la version 2.0.0](#17-utilisation-de-lexecutable-de-la-version-200)
    - [1.7.1. Fichiers de definition du systeme](#171-fichiers-de-definition-du-systeme)
    - [1.7.2. Fichiers de definition des hypotheses](#172-fichiers-de-definition-des-hypotheses)
  - [1.8. Releases](#18-releases)
    - [1.8.1. V0.1.0](#181-v010)
    - [1.8.2. V0.2.0](#182-v020)
    - [1.8.3. V1.0.0](#183-v100)
    - [1.8.3. V2.0.0](#183-v200)

## 1.1. Contributeur

- [Macdrien](https://www.github.com/macdrien) (Owner du repository).

## 1.2. Documentation

### 1.2.1. Schema

```plaintext
-----------------
|               |
|  -----------  |
|  | Base de |  |
|  |  faits  |  |           ----------------
|  |---------|  |<--------->|    Moteur    |
|  | Base de |  |           | d'inférences |
|  | règles  |  |           ----------------
|  -----------  |
|               |
-----------------
```

### 1.2.2. Faits

- (not) moteurDemarre
- pharesFonctionnent

### 1.2.3. Regles

1. (not) reservoirVide (and) pharesFonctionnent (and) (not) moteurDemarre => problemeBougie
2. (not) moteurDemarre (and) (not) pharesFonctionnent => problemeBatterie
3. (not) moteurDemarre (and) pharesFonctionnent => problemeStarter

### 1.2.4. Moteur d'inferences

P (and) (P => Q) alors on peut déduire Q.

---

## 1.3. Exercice

Etant donnés un système d’équations logiques S , et un ensemble de faits certains Faits, concevoir l’architecture du programme qui permet de déduire toutes les conclusions vraies.

S = { [A (and) B => X] ; [C (and) E (and) D => F] ; [X (and) D => Z] }

Hypothèses:

{ A , B , D , X , Z }  X , Z

---

## 1.4. Algorithme

- **Pour** chaque *H* de *Hypothèses* **faire**
  - **Pour** chaque *Equation* *E* de *S* **faire**
    - **Si** *H* appartient à *permisse* de *E* **alors**
      - supprimer *H* de *premisse* de *E*
    - **Si** vide(*prémisse* de *E*) **alors**
      - ajouter *conclusion* de *E* à *Hypothèses*

---

## 1.5. Architecture

![Diagramme de classe](./documentations/classDiagram.png)

---

## 1.6. Utilisation de l'executable de la version 1.0.0

**Note importante**: L'exécutable de l'application ne peut être utilisé que sous Windows.

Si aucun paramètre n'est donné à l'exécutable de l'application, alors ce dernier exécute l'algorithme sur l'exemple donné dans la section [Exercice](#12-exercice) de ce document.

Pour pouvoir passer des paramètres à l'application, il faut lancer l'application en ligne de commande.

Les paramètres attendus pour l'application sont les suivants:

1. Un fichier contenant la définition du système à résoudre.
2. Un fichier contenant la définition des hypothèses à utiliser pour résoudre le système.

Des examples de fichiers à fournir sont disponible dans le dossier file_examples à la racine du repository.

Les fichiers doivent être de la forme suivante:

### 1.6.1. Fichiers de definition du systeme

Le fichier doit être de la forme suivante:

```plaintext
premisse 1 * premisse_2 = conclusion1
premisse3 * premisse-4 = CONCLUSION2
```

Les prémisses et conclusions doivent respecter les critères suivants:

- Les caractères '*' et '=' sont interdit. Si ils sont passé alors la lecture correcte du système de sera pas garantie ('*' et '=' étant des séparateurs dans la lecture du systeme).
- Chaque ligne correspond à une équation du système.
- Une équation respecte la forme suivante
  - Chaque prémisse est séparée d'un '*'
  - Les prémisses et la conclusion sont séparés d'un caractère '='
  - Il n'y a qu'une unique conclusion par équation.  
    => Si plusieurs conclusions sont séparés d'un caractères quelconque (y compris '*' et '=') elles seront assimilées à une unique conclusion.

Au cours du processus, toutes les espaces pré/post-élément (prémisses et conclusions) sont retirés.

### 1.6.2. Fichiers de definition du systeme

Le fichier doit être de la forme suivante:

```plaintext
premisse 1 * premisse_2 = conclusion1
premisse3 * premisse-4 = CONCLUSION2
```

Les prémisses et conclusions doivent respecter les critères suivants:

- Les caractères '*' et '=' sont interdit. Si ils sont passé alors la lecture correcte du système de sera pas garantie ('*' et '=' étant des séparateurs dans la lecture du systeme).
- Chaque ligne correspond à une équation du système.
- Une équation respecte la forme suivante:
  - Chaque prémisse est séparée d'un '*'
  - Les prémisses et la conclusion sont séparés d'un caractère '='
  - Il n'y a qu'une unique conclusion par équation.  
    => Si plusieurs conclusions sont séparés d'un caractères quelconque (y compris '*' et '=') elles seront assimilées à une unique conclusion.

## 1.7. Utilisation de l'executable de la version 2.0.0

**Note importante**: L'exécutable de l'application ne peut être utilisé que sous Windows.

Si aucun paramètre n'est donné à l'exécutable de l'application, alors ce dernier exécute l'algorithme sur l'exemple donné dans la section [Règles](#123-regles) de ce document.

Pour pouvoir passer des paramètres à l'application, il faut lancer l'application en ligne de commande.

Les paramètres attendus pour l'application sont les suivants:

1. Un fichier contenant la définition du système à résoudre.
2. Un fichier contenant la définition des hypothèses à utiliser pour résoudre le système.

Des examples de fichiers à fournir sont disponible dans le dossier file_examples à la racine du repository.

Les fichiers doivent être de la forme suivante:

### 1.7.1. Fichiers de definition du systeme

Le fichier doit être de la forme suivante:

```plaintext
premisse 1 * !premisse_2 = conclusion1
!premisse3 * premisse-4 = CONCLUSION2
```

Les prémisses et conclusions doivent respecter les critères suivants:

- Les caractères '!', '*' et '=' sont interdit. Si ils sont passé alors la lecture correcte du système de sera pas garantie ('!', '*' et '=' étant des séparateurs dans la lecture du systeme).
- Chaque ligne correspond à une équation du système.
- Une équation respecte la forme suivante
  - Une prémisse ayant un '!' devant elle est négative.
  - Chaque prémisse est séparée d'un '*'
  - Les prémisses et la conclusion sont séparés d'un caractère '='
  - Il n'y a qu'une unique conclusion par équation.  
    => Si plusieurs conclusions sont séparés d'un caractères quelconque (y compris '!', '*' et '=') elles seront assimilées à une unique conclusion.

Au cours du processus, toutes les espaces pré/post-élément (prémisses et conclusions) sont retirés.

### 1.7.2. Fichiers de definition des hypotheses

Le fichier doit être de la forme suivante:

```plaintext
hypothese 1
HyPotheSE2
```

Chaque ligne du fichier est assimilée a une unique hypothèse.  
Au cours du processus, toutes les espaces pré/post-hypothèses sont retirés.

## 1.8. Releases

Ici sont décrites les realeses disponibles. Elles sont accessibles dans le dossier releases. Chaque release contient un executable de l'application.

### 1.8.1. V0.1.0

La v0.1.0 est un premier exécutable qui utilise l'exemple présent dans la section [Exercice](#12-exercice) de ce document.

### 1.8.2. V0.2.0

Semblable à la V0.1.0 en apparence. Le changement est interne. Dans cette version, la méthode implémentant l'algorithme a été déplacée dans la classe Systeme et a été rendu générique.

### 1.8.3. V1.0.0

Première version complète.  
Cette version permet le passage en paramètre (au lancement de l'application) de deux fichiers. Le premier comprend le systeme à résoudre. Le second fichier fourni les hypothèses à tester.

### 1.8.3. V2.0.0

Ajoute la possibilité d'avoir des prémisses négatives.
