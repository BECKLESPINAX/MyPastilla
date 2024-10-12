/*
 * Creado por SharpDevelop.
 * MegalÖSoft
 * Fecha: 03/22/2014
 * Hora: 18:29
 * 
 */
#region {Using}
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Data;
using MegalÖSoftMyPastillaStructure;
#endregion {Using}

namespace MyPastilla
{
/// <summary>
/// Interaction logic for WindowConfiguration.xaml
/// </summary>
public partial class WindowConfiguration : Window
{
#region {Global}
ClassPastilla clpastilla=new ClassPastilla();
StructPastilla stpastilla=new StructPastilla();
StructPerson stperson=new StructPerson();
ClassPerson clperson = new ClassPerson();

bool isedit=false;
string scode="-1";

#endregion {Global}


#region {Constructor}
public WindowConfiguration()
{
InitializeComponent();

SetDataGrid();
//SetName();
}
#endregion {Constructor}

void SetName()
{
if(clperson.bShow(ref stperson))
TextBoxName.Text=stperson.sname;
}


void SetDataGrid()
{

DataGridPastilla.ItemsSource = null;

if(clpastilla.bShowDataGrid(ref DataGridPastilla))
{
SetColumnsNames();
}
else
{
MessageBox.Show("Hubo un error.");
this.Close();
}
}

void SetColumnsNames()
{
//DataGridPastilla.EndInit();
//MessageBox.Show(DataGridPastilla.Columns.Count.ToString());

//DataGridPastilla.Columns[0].Header = "Descripción o pastilla a tomar";
/*DataGridPastilla.Columns[2].Header = "Hora";
DataGridPastilla.Columns[3].Header = "Tomadas";
DataGridPastilla.Columns[4].Header = "No Tomadas";*/

}


#region {Event}
void ClickAdd(object sender, RoutedEventArgs e)
{
stpastilla.sdescription = TextBoxPastilla.Text;
stpastilla.dthour = TimePickerHour.Value.Value;

if(clpastilla.bInsert(stpastilla))
{
MessageBox.Show("Se ha agregado la pastilla correctamente.");
SetDataGrid();
}
			
}		
void ClickUpdate(object sender, RoutedEventArgs e)
{
stpastilla.sdescription=TextBoxPastilla.Text;
stpastilla.dthour = TimePickerHour.Value.Value;

if (clpastilla.bUpdate(stpastilla))
{
MessageBox.Show("Se ha actualizado la pastilla correctamente.");
SetDataGrid();
}
else
 MessageBox.Show("No se ha podido actualizar la pastilla.");

}
void ClickDelete(object sender, RoutedEventArgs e)
{
if(clpastilla.bDelete(stpastilla.icode))
{
MessageBox.Show("Se ha eliminado la pastilla correctamente.");
SetDataGrid();
}
else
 MessageBox.Show("No se ha podido eliminar la pastilla.");


}
void ClickExit(object sender, RoutedEventArgs e)
{
this.Close();
}
void ClickSaveName(object sender, RoutedEventArgs e)
{
if(clperson.bUpdateName(TextBoxName.Text))
MessageBox.Show("Se cambió el nombre exitosamente.");
}
void DataGridPastilla_SelectionChanged(object sender, SelectionChangedEventArgs e)
{

}

private void DobleClick(object sender, MouseButtonEventArgs e)
{

}

private void ClickMouse(object sender, MouseButtonEventArgs e)
{
//try{
stpastilla.icode=Convert.ToInt32(((DataRowView)DataGridPastilla.Items[DataGridPastilla.SelectedIndex]).Row["code_pastilla"]);
stpastilla.sdescription=((DataRowView)DataGridPastilla.Items[DataGridPastilla.SelectedIndex]).Row["description_pastilla"].ToString();
//stpastilla.dthour=Convert.ToDateTime(((DataRowView)DataGridPastilla.Items[DataGridPastilla.SelectedIndex]).Row["hour_pastilla"]);
stpastilla.Itomadas=Convert.ToInt64(((DataRowView)DataGridPastilla.Items[DataGridPastilla.SelectedIndex]).Row["tomada_pastilla"]);
stpastilla.Ino_tomadas=Convert.ToInt64(((DataRowView)DataGridPastilla.Items[DataGridPastilla.SelectedIndex]).Row["no_tomada_pastilla"]);

TextBoxPastilla.Text=stpastilla.sdescription;
TimePickerHour.Value = stpastilla.dthour;

//}catch{}
}

void ClickHelp(object sender, RoutedEventArgs e)
{
	new WindowHelp("HelpConfiguration").ShowDialog();
}
#endregion {Event}

#region {Load}
private void Window_Loaded(object sender, RoutedEventArgs e)
{
TimePickerHour.Value = DateTime.Now;
if(clperson.bShow(ref stperson))
TextBoxName.Text=stperson.sname;

}
#endregion {Load}

/*
if(!isedit)
{
TextBoxPastilla.IsEnabled=true;
TimePickerHour.IsEnabled=true;
ButtonEdit.Content="Guardar";
ButtonAdd.Content = "Cancelar";
isedit=true;
}
else
{
TextBoxPastilla.IsEnabled = false;
TimePickerHour.IsEnabled = false;
ButtonEdit.Content = "Editar";
ButtonAdd.Content = "Agregar";
isedit = true;


}
			*/

	}//End class
}//End namespace