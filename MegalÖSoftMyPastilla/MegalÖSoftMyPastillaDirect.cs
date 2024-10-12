using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using MegalÖSoftMyPastillaStructure;

namespace MegalÖSoftMyPastilla
{
public class MSMyPastillaDirect
{
protected SQLiteCommand sqlitecommand;
protected SQLiteConnection sqliteconnection;
protected SQLiteDataReader sqlitereader;

protected string squery = "";
protected string cs = "";//Cadena de conexión
protected bool breturn=false;
protected int iresult = 0;
protected string scommandinsert = "", scommandupdate = "";
protected string scommandreader = "";
protected StructSession stsession = new StructSession();
protected StructConexion stconexion=new StructConexion();

	}
}
