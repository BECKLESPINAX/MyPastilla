
#region {Usings}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;
using MegalÖSoftMyPastillaStructure;
#endregion {Usings}


namespace MyPastilla
{
class ClassPastilla
{
#region {Global}
SQLiteConnection conn = new SQLiteConnection();
SQLiteCommand cmd = new SQLiteCommand();
SQLiteDataAdapter sqlitedataadapter;
SQLiteCommandBuilder sqlitecommandbuilder;
SQLiteDataReader sqlitereader;
string cs="";
string squery="";
StructPastilla stpastilla=new StructPastilla();
#endregion {Global}

public ClassPastilla()
{
cs=ClassConnection.sCONNECTION;
}
 
public bool bInsert(StructPastilla stpastilla)
{
bClose();
string scommand=
"("+
"description_pastilla,"+
"hour_pastilla,"+
"tomada_pastilla,"+
"no_tomada_pastilla"+
")VALUES("+
//stpastilla.icode.ToString()+","+
"'"+stpastilla.sdescription + "'," +
"'"+stpastilla.dthour.ToShortTimeString() + "'," +
"'"+stpastilla.Itomadas.ToString() + "'," +
"'"+stpastilla.Ino_tomadas.ToString()+"'"+
")";


cmd=new SQLiteCommand();
conn = new SQLiteConnection(cs);
conn.Open();
cmd.Connection = conn; 

cmd.CommandText = "INSERT INTO pastillas "+scommand;
//MessageBox.Show(cmd.CommandText);
if(cmd.ExecuteNonQuery()>0)
{
conn.Close();
return true;
}
conn.Close();
return false;
}
public bool bUpdate(StructPastilla stpastilla)
{
bClose();
string scommand =
"description_pastilla='" + stpastilla.sdescription + "'," +
"hour_pastilla='" + stpastilla.dthour.ToShortTimeString() + "'," +
"tomada_pastilla='" + stpastilla.Itomadas.ToString() + "'," +
"no_tomada_pastilla='" + stpastilla.Ino_tomadas.ToString() + "'";

cmd = new SQLiteCommand();
conn = new SQLiteConnection(cs);
conn.Open();
cmd.Connection = conn; 
cmd.CommandText = "UPDATE pastillas SET " + scommand +" WHERE code_pastilla="+stpastilla.icode.ToString();

if (cmd.ExecuteNonQuery() > 0)
{
conn.Close();
return true;
}

conn.Close();
return false;
}

public bool bShow(ref StructPastilla stpastilla)
{
//SELECT *FROM pastillas
return false;
}

public bool bDelete(int icode)
{
bClose();
cmd = new SQLiteCommand();
conn = new SQLiteConnection(cs);
conn.Open();
cmd.Connection = conn;
cmd.CommandText = "DELETE FROM pastillas WHERE code_pastilla="+icode.ToString();
if(cmd.ExecuteNonQuery()>0)
return true;
return false;
}

public bool bShowList(ref List<StructPastilla> ListPastilla)
{
try{

bClose();

ListPastilla.Clear();

squery = @"SELECT * FROM pastillas";
conn = new SQLiteConnection(cs);
conn.Open();
cmd = new SQLiteCommand(squery, conn);
sqlitereader = cmd.ExecuteReader();//Que ejecute la lectura de loq que le dije en la linea de arriba

while (sqlitereader.Read())
{
stpastilla.icode = Convert.ToInt32(sqlitereader["code_pastilla"]);
stpastilla.sdescription = sqlitereader["description_pastilla"].ToString();
stpastilla.dthour = Convert.ToDateTime(sqlitereader["hour_pastilla"]);
stpastilla.Itomadas = Convert.ToInt64(sqlitereader["tomada_pastilla"]);
stpastilla.Ino_tomadas = Convert.ToInt64(sqlitereader["no_tomada_pastilla"]);

ListPastilla.Add(stpastilla);
}
sqlitereader.Close();

return true;
}catch{return false;}
}

public bool bShowDataGrid(ref DataGrid dg)
{
//Uso DataTable para acceder a datos y lo enlazo al DataGrid
try{
//dg.AutoGenerateColumns = true;

sqlitedataadapter = new SQLiteDataAdapter("SELECT *FROM pastillas", cs);

sqlitecommandbuilder = new SQLiteCommandBuilder(sqlitedataadapter);

//llenar el DataTable  
DataTable dt = new DataTable();
sqlitedataadapter.Fill(dt);
System.Data.DataSet ds = new System.Data.DataSet();
ds.Tables.Add(dt);
dg.ItemsSource = ds.Tables[0].DefaultView;
//MessageBox.Show(ds.Tables[0].Rows.Count.ToString());

return true;
}catch{return false;}
}




public bool WarningPastilla(ref List<StructPastilla> ListPast,int i)
{
StructPastilla stp=ListPast[i];

if(!stp.bya_aviso)
{
if (stp.dthour.ToString("tt") == DateTime.Now.ToString("tt"))
 if (stp.dthour.Hour == DateTime.Now.Hour)
  if (stp.dthour.Minute == DateTime.Now.Minute)
return true;
}
else
{
//Si ya avisó y no es la hora, entonces coloco en no avisó
if (stp.dthour.ToString("tt") != DateTime.Now.ToString("tt"))
{stp.bya_aviso=false;
	ListPast[i]=stp;
return false;}


if (stp.dthour.ToString("tt")== DateTime.Now.ToString("tt"))
if (stp.dthour.Hour != DateTime.Now.Hour)
{ stp.bya_aviso=false;
	ListPast[i]=stp;	
	return false;}
 
		
if (stp.dthour.ToString("tt")== DateTime.Now.ToString("tt"))
if (stp.dthour.Hour== DateTime.Now.Hour)
if (stp.dthour.Minute!= DateTime.Now.Minute)
{ stp.bya_aviso=false;
ListPast[i]=stp;	
return false;}
 
	
}


return false;
}

bool bOpen()
{
conn=new SQLiteConnection(cs);
//conn.ConnectionString=cs;
try{conn.Open();return true;}catch{return false;}
//cmd.Connection=conn;
}
bool bClose()
{
try{conn.Close();return true;}catch{return false;}
}

}//End class


}
