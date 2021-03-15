
DROP TABLE IF EXISTS `comment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `comment` (
  `comment_id` int NOT NULL AUTO_INCREMENT,
  `task_id` int NOT NULL,
  `employee_id` int NOT NULL,
  `date` datetime NOT NULL,
  `description` varchar(1000) DEFAULT NULL,
  PRIMARY KEY (`comment_id`),
  UNIQUE KEY `comment_id_UNIQUE` (`comment_id`) /*!80000 INVISIBLE */,
  KEY `employee_id_idx` (`employee_id`),
  KEY `task_id_idx` (`task_id`),
  CONSTRAINT `employee_id_comment` FOREIGN KEY (`employee_id`) REFERENCES `employee` (`employee_id`),
  CONSTRAINT `task_id_comment` FOREIGN KEY (`task_id`) REFERENCES `task` (`task_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `company`
--

DROP TABLE IF EXISTS `company`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `company` (
  `company_id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `creation_date` date DEFAULT NULL,
  `login` varchar(100) DEFAULT NULL,
  `password` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`company_id`),
  UNIQUE KEY `company_id_UNIQUE` (`company_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `employee`
--

DROP TABLE IF EXISTS `employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employee` (
  `employee_id` int NOT NULL AUTO_INCREMENT,
  `company_id` int DEFAULT NULL,
  `first_name` varchar(50) NOT NULL,
  `last_name` varchar(50) NOT NULL,
  `email` varchar(100) DEFAULT NULL,
  `if_manager` int NOT NULL DEFAULT '0',
  `login` varchar(100) DEFAULT NULL,
  `password` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`employee_id`),
  UNIQUE KEY `employee_id_UNIQUE` (`employee_id`),
  KEY `company_id_idx` (`company_id`),
  CONSTRAINT `company_id_employee` FOREIGN KEY (`company_id`) REFERENCES `company` (`company_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;



-- Table structure for table `employeelabel`
--

DROP TABLE IF EXISTS `employeelabel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employeelabel` (
  `employee_id` int NOT NULL,
  `label_id` int NOT NULL,
  PRIMARY KEY (`label_id`,`employee_id`),
  KEY `employee_id_idx` (`employee_id`),
  KEY `label_id_idx` (`label_id`),
  CONSTRAINT `employee_id` FOREIGN KEY (`employee_id`) REFERENCES `employee` (`employee_id`),
  CONSTRAINT `label_id` FOREIGN KEY (`label_id`) REFERENCES `label` (`label_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

-- Table structure for table `employeetask`
--

DROP TABLE IF EXISTS `employeetask`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employeetask` (
  `task_id` int NOT NULL,
  `employee_id` int NOT NULL,
  `status` varchar(50) NOT NULL DEFAULT 'not started',
  PRIMARY KEY (`employee_id`,`task_id`),
  KEY `employee_id_task_idx` (`employee_id`),
  KEY `task_id` (`task_id`),
  CONSTRAINT `employee_id_task` FOREIGN KEY (`employee_id`) REFERENCES `employee` (`employee_id`),
  CONSTRAINT `task_id` FOREIGN KEY (`task_id`) REFERENCES `task` (`task_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

-- Table structure for table `label`
--

DROP TABLE IF EXISTS `label`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `label` (
  `label_id` int NOT NULL AUTO_INCREMENT,
  `company_id` int DEFAULT NULL,
  `label_type_id` int DEFAULT NULL,
  `name` varchar(30) NOT NULL,
  `description` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`label_id`),
  UNIQUE KEY `label_id_UNIQUE` (`label_id`),
  KEY `label_type_id_idx` (`label_type_id`),
  KEY `company_id_idx` (`company_id`),
  CONSTRAINT `company_id_label` FOREIGN KEY (`company_id`) REFERENCES `company` (`company_id`),
  CONSTRAINT `label_type_id` FOREIGN KEY (`label_type_id`) REFERENCES `labeltype` (`label_type_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `labeltype`
--

DROP TABLE IF EXISTS `labeltype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `labeltype` (
  `label_type_id` int NOT NULL AUTO_INCREMENT,
  `company_id` int DEFAULT NULL,
  `name` varchar(50) NOT NULL DEFAULT '<niepodpisany rodzaj etykiety>',
  PRIMARY KEY (`label_type_id`),
  UNIQUE KEY `label_type_id_UNIQUE` (`label_type_id`),
  KEY `company_id_labeltype_idx` (`company_id`),
  CONSTRAINT `company_id_labeltype` FOREIGN KEY (`company_id`) REFERENCES `company` (`company_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;


--
-- Table structure for table `task`
--

DROP TABLE IF EXISTS `task`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `task` (
  `task_id` int NOT NULL AUTO_INCREMENT,
  `company_id` int NOT NULL,
  `name` varchar(50) NOT NULL DEFAULT '<niepodpisane zadanie>',
  `description` varchar(1000) DEFAULT NULL,
  `start_time` datetime DEFAULT NULL,
  `deadline` datetime DEFAULT NULL,
  `status` varchar(50) NOT NULL DEFAULT 'not started',
  `auto_assigned` int NOT NULL DEFAULT '1',
  PRIMARY KEY (`task_id`,`company_id`),
  UNIQUE KEY `task_id_UNIQUE` (`task_id`),
  KEY `company_id_task_idx` (`company_id`),
  CONSTRAINT `company_id_task` FOREIGN KEY (`company_id`) REFERENCES `company` (`company_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tasklabel`
--

DROP TABLE IF EXISTS `tasklabel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tasklabel` (
  `task_id` int NOT NULL,
  `label_id` int NOT NULL,
  PRIMARY KEY (`label_id`,`task_id`),
  KEY `label_id_task_idx` (`label_id`),
  KEY `task_id_FK` (`task_id`),
  CONSTRAINT `label_id_task` FOREIGN KEY (`label_id`) REFERENCES `label` (`label_id`),
  CONSTRAINT `task_id_FK` FOREIGN KEY (`task_id`) REFERENCES `task` (`task_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

