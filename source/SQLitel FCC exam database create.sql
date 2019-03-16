--CREATE DATABASE 'fcc_exam_data';

CREATE TABLE 'fcc_element_descriptions' (
  'ElementNumber' int NOT NULL,
  'SubElementName' varchar(16) NOT NULL DEFAULT '0',
  'GroupName' varchar(16) NOT NULL DEFAULT '0',
  'DescriptiveText' varchar(512) NOT NULL
);

CREATE TABLE 'fcc_exam_questions' (
  'ElementNumber' int NOT NULL,
  'QuestionNumber' varchar(8) NOT NULL,
  'TestQuestion' varchar(512) NOT NULL,
  'AnswerA' varchar(512) NOT NULL,
  'AnswerB' varchar(512) NOT NULL,
  'AnswerC' varchar(512) NOT NULL,
  'AnswerD' varchar(512) NOT NULL,
  'CorrectAnswer' char(1) NOT NULL,
  'GraphicName' varchar(32) NOT NULL,
  'QuestionReference' varchar(64) NOT NULL,
  PRIMARY KEY ('QuestionNumber','ElementNumber')
);