BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "Export_Type" (
	"id"	INTEGER NOT NULL,
	"name"	TEXT NOT NULL,
	PRIMARY KEY("id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Import_Type" (
	"id"	INTEGER NOT NULL,
	"name"	TEXT NOT NULL,
	PRIMARY KEY("id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Location_Type" (
	"id"	INTEGER NOT NULL,
	"name"	TEXT NOT NULL,
	PRIMARY KEY("id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Animal_Type" (
	"id"	INTEGER NOT NULL,
	"name"	TEXT NOT NULL,
	PRIMARY KEY("id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Land_Addresses" (
	"id"	INTEGER NOT NULL,
	"location_type_id"	INTEGER NOT NULL,
	"branch_name"	TEXT NOT NULL,
	"address"	TEXT NOT NULL,
	FOREIGN KEY("location_type_id") REFERENCES "Location_Type"("id"),
	PRIMARY KEY("id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Export_Warehouse" (
	"id"	INTEGER NOT NULL,
	"export_type_id"	INTEGER NOT NULL,
	"name"	TEXT NOT NULL,
	"quantity"	INTEGER NOT NULL,
	"price_per_kilo"	INTEGER NOT NULL,
	FOREIGN KEY("export_type_id") REFERENCES "Export_Type"("id"),
	PRIMARY KEY("id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Export_Addresses" (
	"id"	INTEGER NOT NULL,
	"location_type_id"	INTEGER NOT NULL,
	"name_companies"	TEXT NOT NULL,
	"address"	TEXT NOT NULL,
	FOREIGN KEY("location_type_id") REFERENCES "Location_Type"("id"),
	PRIMARY KEY("id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Import_Addresses" (
	"id"	INTEGER NOT NULL,
	"location_type_id"	INTEGER NOT NULL,
	"company_name"	TEXT NOT NULL,
	"address"	TEXT NOT NULL,
	FOREIGN KEY("location_type_id") REFERENCES "Location_Type"("id"),
	PRIMARY KEY("id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Export" (
	"id"	INTEGER NOT NULL,
	"export_addresses_id"	INTEGER NOT NULL,
	"export_warehouse_id"	INTEGER NOT NULL,
	"export_type_id"	INTEGER NOT NULL,
	"name"	TEXT NOT NULL,
	"quantity"	INTEGER NOT NULL,
	"price"	INTEGER NOT NULL,
	"sale_date"	TEXT NOT NULL,
	PRIMARY KEY("id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Type_Of_Work" (
	"id"	INTEGER NOT NULL,
	"name"	TEXT NOT NULL,
	"salary"	INTEGER NOT NULL,
	PRIMARY KEY("id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Employees" (
	"id"	INTEGER NOT NULL,
	"type_of_work_id"	INTEGER NOT NULL,
	"land_addresses_id"	INTEGER NOT NULL,
	"full_name"	TEXT NOT NULL,
	"address_of_residence"	TEXT NOT NULL,
	"phone_number"	TEXT NOT NULL,
	FOREIGN KEY("type_of_work_id") REFERENCES "Type_Of_Work"("id"),
	FOREIGN KEY("land_addresses_id") REFERENCES "Land_Addresses"("id"),
	PRIMARY KEY("id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Import" (
	"id"	INTEGER NOT NULL,
	"import_addresses_id"	INTEGER NOT NULL,
	"import_type_id"	INTEGER NOT NULL,
	"name"	TEXT NOT NULL,
	"quantity"	INTEGER NOT NULL,
	"price"	INTEGER NOT NULL,
	"import_date"	TEXT NOT NULL,
	PRIMARY KEY("id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Animals" (
	"id"	INTEGER NOT NULL,
	"land_addresses_id"	INTEGER NOT NULL,
	"animal_type_id"	INTEGER NOT NULL,
	"geneder"	TEXT NOT NULL,
	"quantity"	INTEGER NOT NULL,
	"consumption"	INTEGER NOT NULL,
	FOREIGN KEY("animal_type_id") REFERENCES "Animal_Type"("id"),
	FOREIGN KEY("land_addresses_id") REFERENCES "Land_Addresses"("id"),
	PRIMARY KEY("id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Plantation" (
	"id"	INTEGER NOT NULL,
	"land_addresses_id"	INTEGER NOT NULL,
	"plantation_type_name"	TEXT NOT NULL,
	"quantity"	INTEGER NOT NULL,
	"planting_date"	TEXT NOT NULL,
	FOREIGN KEY("land_addresses_id") REFERENCES "Land_Addresses"("id"),
	PRIMARY KEY("id" AUTOINCREMENT)
);
INSERT INTO "Export_Type" VALUES (1,'Фрукти');
INSERT INTO "Import_Type" VALUES (1,'Інструменти');
INSERT INTO "Import_Type" VALUES (2,'Деталі');
INSERT INTO "Import_Type" VALUES (3,'Зерно');
INSERT INTO "Import_Type" VALUES (4,'Яд');
INSERT INTO "Location_Type" VALUES (1,'Магазин');
INSERT INTO "Location_Type" VALUES (2,'Оптова база');
INSERT INTO "Location_Type" VALUES (4,'Сільськогосподарська ділянка');
INSERT INTO "Location_Type" VALUES (6,'Ринок');
INSERT INTO "Location_Type" VALUES (7,'Торговий центр');
INSERT INTO "Location_Type" VALUES (8,'Супермаркет');
INSERT INTO "Location_Type" VALUES (10,'Гараж');
INSERT INTO "Location_Type" VALUES (11,'Ферма');
INSERT INTO "Location_Type" VALUES (12,'Склад');
INSERT INTO "Location_Type" VALUES (13,'Дилер');
INSERT INTO "Location_Type" VALUES (14,'Завод');
INSERT INTO "Location_Type" VALUES (15,'Офіс');
INSERT INTO "Location_Type" VALUES (16,'Адміністративна будівля');
INSERT INTO "Location_Type" VALUES (17,'Лабораторія');
INSERT INTO "Animal_Type" VALUES (1,'Корова');
INSERT INTO "Animal_Type" VALUES (2,'Страус');
INSERT INTO "Animal_Type" VALUES (3,'Куриця');
INSERT INTO "Animal_Type" VALUES (4,'Перепілка');
INSERT INTO "Animal_Type" VALUES (5,'Свиня');
INSERT INTO "Animal_Type" VALUES (6,'Кролики');
INSERT INTO "Animal_Type" VALUES (7,'Кози');
INSERT INTO "Animal_Type" VALUES (8,'Вівці');
INSERT INTO "Land_Addresses" VALUES (2,4,'Посівна площа №1','м. Черкаси, вул. Зарічна 91');
INSERT INTO "Land_Addresses" VALUES (3,10,'Гараж ремонтний','м. Черкаси, вул. Коцюбинського 129');
INSERT INTO "Land_Addresses" VALUES (4,12,'Склад запчастин №1','м. Черкаси, вул. Шевченка 57');
INSERT INTO "Land_Addresses" VALUES (5,12,'Склад продуктовий №1','м. Черкаси, вул. Кобилянської 186');
INSERT INTO "Land_Addresses" VALUES (6,4,'Посівна площа №2','м. Черкаси, вул. Лесі Українки 123');
INSERT INTO "Land_Addresses" VALUES (7,4,'Оранжерея №1','м. Черкаси, вул. Хрещатик 92');
INSERT INTO "Land_Addresses" VALUES (8,11,'Курник №1','м. Черкаси, вул. Київська 179');
INSERT INTO "Land_Addresses" VALUES (9,11,'Корівник №1','м. Черкаси, вул. Героїв Дніпра 176');
INSERT INTO "Land_Addresses" VALUES (10,10,'Тракторний гараж','м. Черкаси, вул. Бандери 46');
INSERT INTO "Land_Addresses" VALUES (11,10,'Гараж ремонтний №2','м. Черкаси, вул. Котляревського 142');
INSERT INTO "Land_Addresses" VALUES (12,12,'Склад зерновий №1','м. Черкаси, вул. Карпенка-Карого 12');
INSERT INTO "Land_Addresses" VALUES (13,4,'Город №1','м. Черкаси, вул. Гайдара 29');
INSERT INTO "Land_Addresses" VALUES (14,12,'Склад запчастин №2','м. Черкаси, вул. Шевченка 98');
INSERT INTO "Land_Addresses" VALUES (15,11,'Курник №2','м. Черкаси, вул. Соборна 174');
INSERT INTO "Land_Addresses" VALUES (17,10,'Гараж з навісним обладнанням','м. Черкаси, вул. Жовтнева 173');
INSERT INTO "Land_Addresses" VALUES (18,11,'Ферма страусів','м. Черкаси, вул. Господарська 33');
INSERT INTO "Land_Addresses" VALUES (19,11,'Ферма молочна','м. Черкаси, вул. Молодіжна 50');
INSERT INTO "Land_Addresses" VALUES (20,17,'Лабораторія №1','м. Черкаси, вул. Петропавлівська 10');
INSERT INTO "Land_Addresses" VALUES (21,16,'Адміністративна будівля №1','м. Черкаси, вул. Петропавлівська 11');
INSERT INTO "Land_Addresses" VALUES (22,17,'Лабораторія №2','м. Черкаси, вул. Харківська 2');
INSERT INTO "Land_Addresses" VALUES (23,16,'Адміністративна будівля №2','м. Черкаси, вул. Харківська 3');
INSERT INTO "Land_Addresses" VALUES (24,11,'Свинарник №1','м. Черкаси, вул. Героїв Дніпра 177');
INSERT INTO "Land_Addresses" VALUES (25,11,'Перепілковий клітник','м. Черкаси, вул. Київська 179');
INSERT INTO "Land_Addresses" VALUES (26,11,'Кролятник №1','м. Черкаси, вул. Соборна 174');
INSERT INTO "Land_Addresses" VALUES (27,4,'Садок №1','м. Черкаси, вул. Зелена 10');
INSERT INTO "Land_Addresses" VALUES (28,4,'Садок №2','м. Черкаси, вул. Зелена 12');
INSERT INTO "Land_Addresses" VALUES (29,4,'Оранжерея №2','м. Черкаси, вул. Садова 15');
INSERT INTO "Land_Addresses" VALUES (30,4,'Город №2','м. Черкаси, вул. Садова 17');
INSERT INTO "Export_Addresses" VALUES (1,1,'Делікат','апзлоідвлщаот');
INSERT INTO "Import_Addresses" VALUES (1,13,'ЗАЗ','м. Черкаси вул. Чорновола 10');
INSERT INTO "Export" VALUES (4,1,4,1,'Вишні',20,2000,'2023-06-23');
INSERT INTO "Export" VALUES (5,1,5,1,'Яблука',100,2000,'2023-06-24');
INSERT INTO "Type_Of_Work" VALUES (1,'Юрист',10000);
INSERT INTO "Type_Of_Work" VALUES (2,'Бухгалтер',12000);
INSERT INTO "Type_Of_Work" VALUES (3,'Сільськогосподарський інженер',16000);
INSERT INTO "Type_Of_Work" VALUES (4,'Економіст',20500);
INSERT INTO "Type_Of_Work" VALUES (5,'Логіст',14500);
INSERT INTO "Type_Of_Work" VALUES (6,'Менеджер з якості',14250);
INSERT INTO "Type_Of_Work" VALUES (7,'Робітник на фермі',10000);
INSERT INTO "Type_Of_Work" VALUES (8,'Механік',13000);
INSERT INTO "Type_Of_Work" VALUES (9,'Лаборант',13500);
INSERT INTO "Type_Of_Work" VALUES (10,'Тваринник',15500);
INSERT INTO "Type_Of_Work" VALUES (11,'Садівник',13250);
INSERT INTO "Type_Of_Work" VALUES (12,'Ветеринар',15250);
INSERT INTO "Type_Of_Work" VALUES (13,'Машиніст',16500);
INSERT INTO "Type_Of_Work" VALUES (14,'Агроном',16250);
INSERT INTO "Type_Of_Work" VALUES (15,'Агротехнолог',17750);
INSERT INTO "Employees" VALUES (1,1,21,'Олексій Іваненко','м. Черкаси, вул. Зарічна 80','0671234567 ');
INSERT INTO "Employees" VALUES (2,4,21,'Олександр Ковальчук','м. Черкаси, вул. Котляревського 141','0999876543');
INSERT INTO "Employees" VALUES (3,8,11,'Володимир Григоренко','м. Черкаси, вул. Котляревського 140','0502468135');
INSERT INTO "Employees" VALUES (4,8,11,'Михайло Коваленко','м. Черкаси, вул. Котляревського 139','0632349876');
INSERT INTO "Employees" VALUES (5,13,10,'Сергій Литвиненко','м. Черкаси, вул. Соборна 45','0662345678');
INSERT INTO "Employees" VALUES (12,2,23,'Іван Біленький','м. Черкаси, вул. Зарічна 91','0681111111');
INSERT INTO "Employees" VALUES (13,3,22,'Марія Коваленко','м. Черкаси, вул. Коцюбинського 129','0952222222');
INSERT INTO "Employees" VALUES (14,4,23,'Ольга Петренко','м. Черкаси, вул. Шевченка 57','0673333333');
INSERT INTO "Employees" VALUES (15,5,12,'Андрій Лисенко','м. Черкаси, вул. Кобилянської 186','0994444444');
INSERT INTO "Employees" VALUES (16,6,23,'Наталія Савченко','м. Черкаси, вул. Лесі Українки 123','0505555555');
INSERT INTO "Employees" VALUES (17,7,13,'Олексій Мельник','м. Черкаси, вул. Хрещатик 92','0636666666');
INSERT INTO "Employees" VALUES (18,8,17,'Ірина Петренко','м. Черкаси, вул. Київська 179','0667777777');
INSERT INTO "Employees" VALUES (19,9,20,'Сергій Василенко','м. Черкаси, вул. Героїв Дніпра 176','0678888888');
INSERT INTO "Employees" VALUES (20,10,9,'Марина Бондаренко','м. Черкаси, вул. Бандери 46','0689999999');
INSERT INTO "Employees" VALUES (21,11,13,'Олег Шевченко','м. Черкаси, вул. Котляревського 142','0990000000');
INSERT INTO "Employees" VALUES (22,12,22,'Наталія Іванченко','м. Черкаси, вул. Карпенка-Карого 12','0501111111');
INSERT INTO "Employees" VALUES (23,13,10,'Марія Гайдар','м. Черкаси, вул. Гайдара 29','0632222222');
INSERT INTO "Employees" VALUES (24,14,13,'Володимир Шевченко','м. Черкаси, вул. Шевченка 98','0663333333');
INSERT INTO "Employees" VALUES (25,15,20,'Оксана Попова','м. Черкаси, вул. Соборна 174','0674444444');
INSERT INTO "Employees" VALUES (26,15,22,'Ігор Петров','м. Черкаси, вул. Соборна 172','0995555555');
INSERT INTO "Employees" VALUES (27,11,7,'Марина Мельничук','м. Черкаси, вул. Котляревського 76','0992345678');
INSERT INTO "Import" VALUES (1,1,2,'Колеса',4,5000,'2023-06-24');
INSERT INTO "Animals" VALUES (2,25,4,'Самка',50,25);
INSERT INTO "Animals" VALUES (3,8,3,'Самець',10,25);
INSERT INTO "Animals" VALUES (4,25,4,'Самець',13,9);
INSERT INTO "Animals" VALUES (5,9,1,'Самець',20,250);
INSERT INTO "Animals" VALUES (6,9,1,'Самка',40,400);
INSERT INTO "Animals" VALUES (7,18,2,'Самка',18,180);
INSERT INTO "Animals" VALUES (8,18,2,'Самець',9,90);
INSERT INTO "Animals" VALUES (9,15,3,'Самка',55,55);
INSERT INTO "Animals" VALUES (10,15,3,'Самець',20,25);
INSERT INTO "Animals" VALUES (11,19,1,'Самка',60,500);
INSERT INTO "Animals" VALUES (12,24,5,'Самець',66,660);
INSERT INTO "Animals" VALUES (13,24,5,'Самка',45,350);
INSERT INTO "Animals" VALUES (14,26,6,'Самці',60,150);
INSERT INTO "Animals" VALUES (15,26,6,'Самки',70,140);
INSERT INTO "Animals" VALUES (16,24,5,'Самка',20,150);
CREATE TRIGGER delete_type_of_work
BEFORE DELETE ON "Type_Of_Work"
BEGIN
    DELETE FROM "Employees" WHERE "type_of_work_id" = OLD.id;
END;
CREATE TRIGGER delete_location_type
BEFORE DELETE ON "Location_Type"
BEGIN
    DELETE FROM "Land_Addresses" WHERE "location_type_id" = OLD."id";
    DELETE FROM "Export_Addresses" WHERE "location_type_id" = OLD."id";
    DELETE FROM "Import_Addresses" WHERE "location_type_id" = OLD."id";
END;
CREATE TRIGGER delete_land_addresses
BEFORE DELETE ON "Land_Addresses"
BEGIN
    DELETE FROM "Animals" WHERE "land_addresses_id" = OLD.id;
    DELETE FROM "Plantation" WHERE "land_addresses_id" = OLD.id;
    DELETE FROM "Employees" WHERE "land_addresses_id" = OLD.id;
END;
CREATE TRIGGER delete_export_type
BEFORE DELETE ON "Export_Type"
BEGIN
    DELETE FROM "Export_Warehouse" WHERE "export_type_id" = OLD."id";
END;
CREATE TRIGGER delete_animal_type
BEFORE DELETE ON "Animal_Type"
BEGIN
    DELETE FROM "Animals" WHERE "animal_type_id" = OLD.id;
END;
COMMIT;
