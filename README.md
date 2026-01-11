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

a. Vytvořit databázi s názvem "orderappis" (Db.sql)

b. Vytvořit uživatele "orderappis_client" s heslem "Asa123qyx!" k databázi orderappis (Db.sql)

c. Spustit příkaz v cmd z adresáře projektu (Dump.sql): `psql -U postgres -d orderappis -f Dump.sql`

d. V případě, že se chce v databázi zachovávat i historická data, potom v předchozím bodě použít Dump_h.sql

1. V případě chyby smazat částečně vytvořenou db a uživatele, opakovat celý postup znovu

2. Testováno ve verzi (select version();) `PostgreSQL 14.9, compiled by Visual C++ build 1914, 64-bit`

3. příkaz `psql` lze nalézt v instalci PostgreSQL ve složce bin (např. zde:): C:\Program Files\PostgreSQL\14\bin, přidejte cestu do PATH

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

d. Nebo lépe, jen stáhnout projekt a v hlavním adresáři zadat `dotnet publish -c Release`

e. To je vše, případně vytvořit zástupce na ploše (na exe soubor z Release či už jinak pojmenované složky s exe)

f. Příhlášení do systému jako admin: login: a00001 heslo: hsl123

## Autor
Adam Polívka
