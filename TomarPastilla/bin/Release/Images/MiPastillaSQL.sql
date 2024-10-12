CREATE TABLE properties (
  code_property INTEGER  NOT NULL  ,
  sound_property BOOL    ,
  speech_property BOOL    ,
  ubication_sound_property VARCHAR(400)    ,
  repetition_speech_property SMALLINT    ,
  duration_warning_property SMALLINT    ,
  speech_tomar_pastilla_property BOOL      ,
PRIMARY KEY(code_property));



CREATE TABLE persons (
  code_person INTEGER  NOT NULL  ,
  name_person VARCHAR(200)      ,
PRIMARY KEY(code_person));



CREATE TABLE pastillas (
  code_pastilla INTEGER  NOT NULL  ,
  description_pastilla VARCHAR(400)    ,
  time_pastilla TIME    ,
  tomadas_pastilla BIGINT    ,
  no_tomadas_pastilla BIGINT      ,
PRIMARY KEY(code_pastilla));




