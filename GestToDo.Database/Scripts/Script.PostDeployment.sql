/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

EXEC [CSP_RegisterUser] @LastName = 'Morre', @FirstName = 'Thierry', @Email = 'thierry.morre@cognitic.be', @Passwd = 'test1234=';

insert into [ToDo] ([Title], [Description], [UserId]) Values ('Test', 'Test Decription', 1);
insert into [ToDo] ([Title], [Description], [UserId]) Values ('Test 2', 'Test Decription 2', 1);
insert into [ToDo] ([Title], [Description], [UserId]) Values ('Test 3', 'Test Decription 3', 1);