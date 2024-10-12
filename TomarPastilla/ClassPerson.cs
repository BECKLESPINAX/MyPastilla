#region {Usings}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Data.SQLite;
using MegalÖSoftMyPastillaStructure;
#endregion {Usings}

namespace MyPastilla
{
class ClassPerson
{
#region {Global}
SQLiteConnection conn = new SQLiteConnection();
SQLiteCommand cmd = new SQLiteCommand();
SQLiteDataReader sqlitereader;
//StructPerson stperson=new StructPerson();
string cs="";

#endregion {Global}

public ClassPerson()
{
cs = ClassConnection.sCONNECTION;
}


public bool bInsertName()
{
string scommand =
"(name_person)VALUES('German')";

cmd = new SQLiteCommand();
conn = new SQLiteConnection(cs);
conn.Open();
cmd.Connection = conn; 

cmd.CommandText = "INSERT INTO persons " + scommand;

if (cmd.ExecuteNonQuery() > 0)
 return true;

return false;
}


public bool bUpdateName(string sname)
{
string scommand =
"name_person='" + sname+"'";

cmd = new SQLiteCommand();
conn = new SQLiteConnection(cs);
conn.Open();
cmd.Connection = conn; 

cmd.CommandText = "UPDATE persons SET " + scommand+ " WHERE code_person=1";

if (cmd.ExecuteNonQuery() > 0)
{
conn.Close();
return true;
}

conn.Close();
return false;
}

public bool bShow(ref StructPerson stperson)
{
try
{
cmd = new SQLiteCommand();
conn = new SQLiteConnection(cs);
conn.Open();
cmd.Connection = conn;
cmd.CommandText = "SELECT * FROM persons WHERE code_person=1";

sqlitereader = cmd.ExecuteReader();
if(sqlitereader.Read()){
stperson.sname = Convert.ToString(sqlitereader["name_person"]);
sqlitereader.Close();
}
return true;
}
catch { return false; }

}

 }//End class
}//End namespace
