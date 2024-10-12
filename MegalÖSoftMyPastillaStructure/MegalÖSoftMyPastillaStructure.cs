using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MegalÖSoftMyPastillaStructure
{
public struct StructPastilla
{
public int icode;
public string sdescription;
public DateTime dthour;

public Int64 Itomadas ;
public Int64 Ino_tomadas;

public bool bya_aviso;
}

public struct StructProperty
{
public int icode;
public bool bsound;
public bool bspeech;

public string subication_sound;
public Int16 i16repetition_speech;

public Int16 i16duration_warning;

public bool bspeech_tomar_pastilla;
}

public struct StructPerson
{
public int icode;
public string sname;

}

public struct StructSession
{
//Cuando se empieza una sesión, se debe borrar el archivo de sesión.
public Int64 Icode;
public Int64 Icode_user;
public Int64 Icode_entity;

public int icode_language;// En lenguages ver de hacer lenguaje 1000 definido por el usuario, por ejemplo, que defina sus propias palabras
}                         // Y que derive de tal lenguaje  




public struct StructConexion
{
public string sdatabase;
public	string sport;
public  string suser;
public  string spass;
public	string sserver;
public  string stable;
public string stable2;
}


}//End namespace
