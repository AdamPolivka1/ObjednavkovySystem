# ObjednavkovySystem

## Požadavky
- PostgreSQL
- Visual Studio (ideálně)
- .NET
- Operační systém Windows

---

## Instalace a zprovoznění

### 1. Vytvoření PostgreSQL databáze
Nejprve je nutné vytvořit databázi v PostgreSQL.

a. Vytvořit databázi s názvem "orderappis"

b. Vytvořit uživatele "orderappis_client" s heslem "Asa123qyx!" a přidělit mu práva k orderappis

c. Spustit příkaz v cmd z adresáře projektu (Dump.sql): `psql -U postgres -d orderappis -f Dump.sql`

Základní Connection string:
Host=localhost;
Database=orderappis;
Username=orderappis_client;
Password=Asa123qyx!


Poznámka:  
Hodnotu `Host` lze při přihlašování do aplikace dynamicky změnit (na IPv4 adresu databázového serveru).

---

### 2. Stažení projektu
Projekt lze stáhnout nebo naklonovat z GitHub repozitáře:
git clone https://github.com/AdamPolivka1/ObjednavkovySystem.git

---
a. Otevřít hlavní adresář aplikace ve Visual Studiu

b. V horní liště změnit z Debug na Release, spouštěný projekt je Orderappis

c. Sestavit > Znovu sestavit řešení

d. Nyní lze složku Orderappis > bin > Release distribuovat (je v ní exe soubor)

b. To je vše, případně vytvořit zástupce na ploše (na exe soubor z Release či už jinak pojmenované složky s exe)

## Autor
Adam Polívka
