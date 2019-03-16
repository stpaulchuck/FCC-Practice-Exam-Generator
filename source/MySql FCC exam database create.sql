CREATE DATABASE `fcc_exam_data`;

CREATE TABLE `fcc_element_descriptions` (
  `ElementNumber` int NOT NULL,
  `SubElementName` varchar(16) NOT NULL DEFAULT '0',
  `GroupName` varchar(16) NOT NULL DEFAULT '0',
  `DescriptiveText` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `fcc_exam_questions` (
  `ElementNumber` int NOT NULL,
  `QuestionNumber` varchar(8) NOT NULL,
  `TestQuestion` text NOT NULL,
  `AnswerA` text NOT NULL,
  `AnswerB` text NOT NULL,
  `AnswerC` text NOT NULL,
  `AnswerD` text NOT NULL,
  `CorrectAnswer` char(1) NOT NULL,
  `GraphicName` varchar(128) NOT NULL,
  `QuestionReference` varchar(64) NOT NULL,
  PRIMARY KEY (`QuestionNumber`,`ElementNumber`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;