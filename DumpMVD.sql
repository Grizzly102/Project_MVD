-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: mvd
-- ------------------------------------------------------
-- Server version	8.0.31

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `article`
--

DROP TABLE IF EXISTS `article`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `article` (
  `Article_Id` int NOT NULL,
  `Article_Description` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`Article_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `article`
--

LOCK TABLES `article` WRITE;
/*!40000 ALTER TABLE `article` DISABLE KEYS */;
INSERT INTO `article` VALUES (112,'112 УК РФ. Причинение вреда здоровью средней тяжести'),(158,'158 УК РФ. тайное хищение денежных средств с банковского счёта или электронных денежных средств'),(159,'159 УК РФ. Мошенничество, то есть хищение чужого имущества или приобретение права на чужое имущество путем обмана'),(163,'163 УК РФ. Вымогательство, то есть требование передачи чужого имущества или права на имущество или совершения других действий имущественного характера под угрозой применения насилия либо уничтожения или повреждения чужого имущества');
/*!40000 ALTER TABLE `article` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `case`
--

DROP TABLE IF EXISTS `case`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `case` (
  `Case_Id` int NOT NULL,
  `Case_Opening_Date` date DEFAULT NULL,
  `Crime_Date` date DEFAULT NULL,
  `Crime_Scence` varchar(45) DEFAULT NULL,
  `Crime_Article` int DEFAULT NULL,
  `Crime_Weight` varchar(45) DEFAULT NULL,
  `Case_Conduct` int DEFAULT NULL,
  `DIscription` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Case_Id`),
  KEY `Employer_idx` (`Case_Conduct`),
  KEY `Article_idx` (`Crime_Article`),
  CONSTRAINT `Article` FOREIGN KEY (`Crime_Article`) REFERENCES `article` (`Article_Id`),
  CONSTRAINT `Employer` FOREIGN KEY (`Case_Conduct`) REFERENCES `employer` (`Token_Number`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `case`
--

LOCK TABLES `case` WRITE;
/*!40000 ALTER TABLE `case` DISABLE KEYS */;
INSERT INTO `case` VALUES (1,'2022-02-22','2022-01-11','Г.Уфа, Ленина 21',112,'Средней тяжести',2,NULL),(2,'2021-12-10','2021-11-28','Г.Уфа, Проспект октября 51',159,'Средней тяжести',3,NULL),(3,'2022-05-09','2022-04-14','Г.Уфа, Аксакова 81\\1',158,'Тяжкое',4,NULL),(4,'2022-05-09','2022-02-07','Г.Салават, Карла Маркса 21',163,'Небольшой тяжести',4,NULL),(5,'2023-06-22','2023-06-01','Мелеуз',158,'Средней тяжести',2,NULL),(6,'2023-06-01','2023-04-07','Г.Уфа, Ленина 28',159,'Тяжкое',2,NULL),(7,'2024-05-26','2024-05-03','ufa',112,'Тяжкое',2,NULL),(8,'2024-05-26','2024-05-01','белебей',163,'Средней тяжести',2,NULL);
/*!40000 ALTER TABLE `case` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `criminal`
--

DROP TABLE IF EXISTS `criminal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `criminal` (
  `Passport_Nuber_Serias` bigint NOT NULL,
  `Criminal_Name` varchar(100) DEFAULT NULL,
  `Height` int DEFAULT NULL,
  `Eye_Color` varchar(45) DEFAULT NULL,
  `Hair_Color` varchar(45) DEFAULT NULL,
  `Special_Signs` varchar(150) DEFAULT NULL,
  `Birth_Place` varchar(45) DEFAULT NULL,
  `Birth_Date` date DEFAULT NULL,
  `Last_Residence_Place` varchar(45) DEFAULT NULL,
  `Photo` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Passport_Nuber_Serias`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `criminal`
--

LOCK TABLES `criminal` WRITE;
/*!40000 ALTER TABLE `criminal` DISABLE KEYS */;
INSERT INTO `criminal` VALUES (3101315421,'Пономарев С.Д',188,'Карие','Черные','Шрам у глаза','Г.Уфа','1986-05-15','Г.Уфа','1z.jpg'),(4215527321,'Митряев А.И',166,'Карие','Карие','-','Г.Уфа','1989-09-14','Г.Ташкент',NULL),(4863925322,'Романов Н.Л',199,'Карие','Черные','-','Г.Уфа','1993-04-04','Г.Сочи','2z.jpg'),(5126742391,'Логвинов С.М',162,'Карие','Черные','-','Г.Мелеуз','1994-02-12','Г.Октябрск',NULL),(5243817361,'Батыршин К.А',154,'Зеленые','Черные','-','Г.Уфа','1977-02-12','Руанда','3z.jpg'),(5345634634,'Гунько.С.В',NULL,'Зеленые','Карие','-','Г.Ейск','1984-06-13','Г.Ейск',NULL),(5354432432,'Андреев О.В',165,'Зеленый','Серый','-','Белебей','2001-03-02','Уфа',NULL),(6365566556,'Зиннуров Л.Л',175,'Черный','Рыжий','-','Г.Севастополь','1980-07-18','УКСИВТ',NULL),(6465543647,'Иванов.И.И',198,'Черный','Белый','-','Г.Вологда','2000-06-07','Г.Вологда',NULL),(6635741331,'Исхаков А.Ш',155,'Карие','Черные','-','Д.Каровкино','2000-12-12','Г.Уфа',NULL),(7821467936,'Логвинов М.М',155,'Карие','Блонд','-','Г.Уфа','1974-09-22','Г.Уфа','z4.png'),(8642122631,'Хабибулин Д.П',172,'Голубые','Блонд','Татуировка звезд на коленях','Г.Уфа','2000-07-13','Г.Уфа',NULL);
/*!40000 ALTER TABLE `criminal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `criminale_in_case`
--

DROP TABLE IF EXISTS `criminale_in_case`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `criminale_in_case` (
  `Case_Id` int DEFAULT NULL,
  `Passport_Nuber_Serias` bigint DEFAULT NULL,
  `Case_Status` varchar(45) DEFAULT NULL,
  `CiC_Number` int NOT NULL,
  PRIMARY KEY (`CiC_Number`),
  KEY `Case_idx` (`Case_Id`),
  KEY `pass_idx` (`Passport_Nuber_Serias`),
  KEY `Num_idx` (`Passport_Nuber_Serias`),
  CONSTRAINT `Case` FOREIGN KEY (`Case_Id`) REFERENCES `case` (`Case_Id`),
  CONSTRAINT `Pass` FOREIGN KEY (`Passport_Nuber_Serias`) REFERENCES `criminal` (`Passport_Nuber_Serias`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `criminale_in_case`
--

LOCK TABLES `criminale_in_case` WRITE;
/*!40000 ALTER TABLE `criminale_in_case` DISABLE KEYS */;
INSERT INTO `criminale_in_case` VALUES (1,3101315421,'Обвиняемый',1),(1,4215527321,'Свидетель',2),(2,4863925322,'Обвиняемый',3),(2,5126742391,'Свидетель',4),(3,5243817361,'Обвиняемый',5),(3,6635741331,'Свидетель',6),(4,7821467936,'Обвиняемый',7),(4,8642122631,'Свидетель',8),(5,5243817361,'Обвиняемый',9),(6,5126742391,'Обвиняемый',10),(6,4863925322,'Свидетель',11),(7,8642122631,'Обвиняемый',12),(8,4863925322,'Обвиняемый',13);
/*!40000 ALTER TABLE `criminale_in_case` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `department`
--

DROP TABLE IF EXISTS `department`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `department` (
  `Department_Id` int NOT NULL,
  `Department_Name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Department_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `department`
--

LOCK TABLES `department` WRITE;
/*!40000 ALTER TABLE `department` DISABLE KEYS */;
INSERT INTO `department` VALUES (1,'ФСКН'),(2,'ФСИН'),(3,'Прокуратура');
/*!40000 ALTER TABLE `department` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employer`
--

DROP TABLE IF EXISTS `employer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employer` (
  `Token_Number` int NOT NULL,
  `Employee_Name` varchar(100) DEFAULT NULL,
  `Department_Number` int DEFAULT NULL,
  `Title_Number` int DEFAULT NULL,
  `Login` varchar(45) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  `Police_Photo` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Token_Number`),
  KEY `Dep_idx` (`Department_Number`),
  KEY `Title_idx` (`Title_Number`),
  CONSTRAINT `Dep` FOREIGN KEY (`Department_Number`) REFERENCES `department` (`Department_Id`),
  CONSTRAINT `Title` FOREIGN KEY (`Title_Number`) REFERENCES `title` (`Title_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employer`
--

LOCK TABLES `employer` WRITE;
/*!40000 ALTER TABLE `employer` DISABLE KEYS */;
INSERT INTO `employer` VALUES (1,'Иванов И.И',1,1,'iv','an','p1.jpg'),(2,'Абдулин П.Р',2,2,'ab','dul','p2.png'),(3,'Романов Л.К',1,2,'rom','an','p3.png'),(4,'Юрченко О.Д',3,2,'ur','ch','p4.png'),(5,'Игорь Е.Б',1,2,'test','test',NULL);
/*!40000 ALTER TABLE `employer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `title`
--

DROP TABLE IF EXISTS `title`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `title` (
  `Title_Id` int NOT NULL,
  `Title_Name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Title_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `title`
--

LOCK TABLES `title` WRITE;
/*!40000 ALTER TABLE `title` DISABLE KEYS */;
INSERT INTO `title` VALUES (1,'Администратор'),(2,'Следователь');
/*!40000 ALTER TABLE `title` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-08-01 16:52:31
