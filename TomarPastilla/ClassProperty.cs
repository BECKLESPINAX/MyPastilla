#region {Usings}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Windows;
using MegalÖSoftMyPastillaStructure;
#endregion {Usings}


namespace MyPastilla
{
class ClassProperty
{
#region {Global}
SQLiteConnection conn = new SQLiteConnection();
SQLiteCommand cmd = new SQLiteCommand();
SQLiteDataReader sqlitereader;
string squery="";
string cs="";
#endregion {Global}
public ClassProperty()
{
cs = ClassConnection.sCONNECTION;
}

public bool bInsert(StructProperty stproperty)
{
string scommand =
"("+
"sound_property,"+
"speech_property,"+ 
"ubication_sound_property,"+ 
"repetition_speech_property,"+ 
"duration_warning_property,"+ 
"speech_tomar_pastilla_property"+ 
")VALUES("+
"'"+stproperty.bsound.ToString() + "'," +
"'"+stproperty.bspeech.ToString() + "'," +
"'"+stproperty.subication_sound + "'," +
"'"+stproperty.i16repetition_speech.ToString() + "'," +
"'"+stproperty.i16duration_warning.ToString() + "'," +
"'"+stproperty.bspeech_tomar_pastilla.ToString()+"'"+
")";

cmd = new SQLiteCommand();
conn = new SQLiteConnection(cs);
conn.Open();
cmd.Connection = conn; 
cmd.CommandText = "INSERT INTO properties "+scommand;

if (cmd.ExecuteNonQuery() > 0)
return true;
return false;
}

public bool bUpdate(StructProperty stproperty)
{
try{
string scommand =
"sound_property='" + Convert.ToInt32(stproperty.bsound).ToString() + "'," +
"speech_property='" + Convert.ToInt32(stproperty.bspeech).ToString() + "'," +
"ubication_sound_property=@stubication,"+//" + stproperty.subication_sound + "'," +
"repetition_speech_property='" + stproperty.i16repetition_speech.ToString() + "'," +
"duration_warning_property='" + stproperty.i16duration_warning.ToString() + "'," +
"speech_tomar_pastilla_property='" + Convert.ToInt32(stproperty.bspeech_tomar_pastilla).ToString()+"'";

cmd = new SQLiteCommand();
conn = new SQLiteConnection(cs);

if (conn.State != System.Data.ConnectionState.Open)
conn.Open();
else
conn.Close();

cmd.Connection = conn; 
cmd.CommandText = "UPDATE properties SET " + scommand +" WHERE code_property='1'";

cmd.Parameters.AddWithValue("@stubication",stproperty.subication_sound);
//.Add(pubication);

//MessageBox.Show(stproperty.subication_sound.Length.ToString());
//MessageBox.Show(cmd.CommandText);
if (cmd.ExecuteNonQuery() > 0)
{
conn.Close();
return true;
}
conn.Close();
return false;

}catch(SQLiteException sq){MessageBox.Show(sq.Message);return false;}


}

public bool bShow(ref StructProperty stproperty)
{
try{
//squery = @"SELECT * FROM properties";
conn = new SQLiteConnection(cs);
conn.Open();
cmd = new SQLiteCommand(conn);
cmd.CommandText = "SELECT * FROM properties WHERE code_property=1";
sqlitereader = cmd.ExecuteReader();//Que ejecute la lectura de loq que le dije en la linea de arriba

if(sqlitereader.Read())
{
stproperty.bsound = Convert.ToBoolean(sqlitereader["sound_property"]);
stproperty.bspeech = Convert.ToBoolean(sqlitereader["speech_property"]);
stproperty.i16duration_warning = Convert.ToInt16(sqlitereader["duration_warning_property"]);
stproperty.i16repetition_speech = Convert.ToInt16(sqlitereader["repetition_speech_property"]);
stproperty.subication_sound = Convert.ToString(sqlitereader["ubication_sound_property"]);
stproperty.bspeech_tomar_pastilla = Convert.ToBoolean(sqlitereader["speech_tomar_pastilla_property"]);

sqlitereader.Close();
return true;
}
return false;
}catch{
try{sqlitereader.Close();}catch{}
return false;}

}



 }//End class
}//End namespace
